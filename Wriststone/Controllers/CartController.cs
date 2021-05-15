using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.Context;
using Wriststone.Models.DAO;
using Wriststone.Models.Table;
using Wriststone.Models.ViewModel;
using Wriststone.Static_Methods;

namespace Wriststone.Controllers
{
    public class CartController : Controller
    {
        readonly AccountDAO accountDAO = new AccountDAO();
        readonly OrderDAO orderDAO = new OrderDAO();
        readonly OrderDetailsDAO orderDetailsDAO = new OrderDetailsDAO();
        readonly ProductDAO productDAO = new ProductDAO();
        private Payment payment;
        // GET: Cart
        public ActionResult Cart()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(long? id)
        {
            List<Product> cart = HttpContext.Session.Get<List<Product>>("cart");
            for (int i = 0; i < cart.Count; i++) if (cart[i].Id == id) cart.RemoveAt(i);
            if (cart.Count <= 1) HttpContext.Session.Add<List<Product>>("cart", null);
            else
            {
                HttpContext.Session.Add<List<Product>>("cart", null);
                HttpContext.Session.Add("cart", cart);
            }
            return RedirectToAction("Cart");
        }

        public Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var listItems = new ItemList() { items = new List<Item>() };
            List<ProductCartModel> cart = HttpContext.Session.Get<List<ProductCartModel>>("cart");
            foreach (var item in cart) listItems.items.Add(new Item
            { 
                name = item.Product.Name, 
                currency = item.Currency.Symbol, 
                price = item.ProductCurrency.Price.ToString(), 
                quantity = "1", 
                sku = "sku" 
            });
            var payer = new Payer { payment_method = "paypal" };
            var details = new Details { tax = "0", shipping = "0", subtotal = cart.Sum(e => e.ProductCurrency.Price).ToString() };
            var amount = new Amount { currency = listItems.items.First().currency, total = Convert.ToDecimal(details.subtotal).ToString(), details = details };
            var redirectUrls = new RedirectUrls { return_url = redirectUrl, cancel_url = redirectUrl };


            var transactionList = new List<Transaction>
            {
                new Transaction
                {
                    description = "Wriststone test",
                    invoice_number = Convert.ToString(new Random().Next(100000)),
                    amount = amount,
                    item_list = listItems
                }
            };
            var payment = new Payment { intent = "sale", payer = payer, transactions = transactionList, redirect_urls = redirectUrls };
            return payment.Create(apiContext);
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution { payer_id = payerId };
            payment = new Payment { id = paymentId };
            return payment.Execute(apiContext, paymentExecution);
        }

        public ActionResult PaymentWithPaypal()
        {
            APIContext apiContext = PayPalConfiguration.GetAPIContext();
            try
            {
                string payerId = HttpContext.Request.Query["PayerId"].ToString();
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseURI = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + "/Cart/PaymentWithPaypal?";
                    var guid = Guid.NewGuid().ToString();
                    var createdPayment = CreatePayment(apiContext, baseURI + "guid=" + guid);
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;

                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url")) paypalRedirectUrl = link.href;
                    }
                    HttpContext.Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var guid = HttpContext.Request.Query["guid"].ToString();
                    var executedPayment = ExecutePayment(apiContext, payerId, HttpContext.Session.Get<string>(guid));
                    if (!executedPayment.state.ToLower().Equals("approved"))
                    {
                        HttpContext.Session.Add<List<Product>>("cart", null);
                        return View("Failure");
                    }
                }
            }
            catch (Exception)
            {
                HttpContext.Session.Add<List<Product>>("cart", null);
                return View("Failure");
            }
            AcceptOrder();
            HttpContext.Session.Add<List<Product>>("cart", null);
            return View("Success");
        }

        private void AcceptOrder()
        {
            var account = accountDAO.SelectItemByLogin(User.Identity.Name).Id.Value;
            var date = DateTime.Now;
            var order = new Models.Table.Order
            {
                Account = account,
                Payment = "Paypal",
                Guid = HttpContext.Request.Query["guid"].ToString(),
                Currency = HttpContext.Session.Get<List<ProductCartModel>>("cart").Sum(e => e.Currency.Id),
                Price = HttpContext.Session.Get<List<ProductCartModel>>("cart").Sum(e => e.ProductCurrency.Price),
                Date = date,
                IsCompleted = true
            };
            orderDAO.Insert(order);
            var cart = HttpContext.Session.Get<List<ProductCartModel>>("cart");
            foreach (var item in cart)
            { orderDetailsDAO.Insert(new OrderDetails { Order = order.Id, Price = item.ProductCurrency.Price, Product = item.Product.Id }); }
        }

        [HttpPost]
        public ActionResult FreeProduct(long id)
        {
            var account = accountDAO.SelectItemByLogin(User.Identity.Name).Id.Value;
            var product = productDAO.Select(id);
            var order = new Models.Table.Order 
            { 
                Account = account, 
                Payment = "Free", 
                Guid = Guid.NewGuid().ToString(),
                Price = 0, 
                Currency = 1, 
                Date = DateTime.Now, 
                IsCompleted = true 
            };
            orderDAO.Insert(order);
            orderDetailsDAO.Insert(new OrderDetails { Order = order.Id, Price = 0, Product = product.Id });
            return View("Success");
        }
    }
}