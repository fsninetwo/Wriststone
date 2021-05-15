using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.DAO;
using Wriststone.Models.Table;
using Wriststone.Models.ViewModel;
using Wriststone.Static_Methods;

namespace Wriststone.Controllers
{
    public class StoreController : Controller
    {
        readonly AccountDAO AccountDAO = new AccountDAO();
        readonly ProductDAO ProductDAO = new ProductDAO();
        readonly ProductCategoryDAO ProductCategoryDAO = new ProductCategoryDAO();
        readonly RatingDAO RatingDAO = new RatingDAO();
        readonly OrderDetailsDAO OrderDetailsDAO = new OrderDetailsDAO();
        readonly AccountRatingDAO AccountRatingDAO = new AccountRatingDAO();
        readonly ProductCartDAO ProductCartDAO = new ProductCartDAO();
        readonly ProductCurrencyDAO ProductCurrencyDAO = new ProductCurrencyDAO();
        readonly CategoryProductDAO CategoryProductDAO = new CategoryProductDAO();
        readonly CurrencyDAO currencyDAO = new CurrencyDAO();
        IHttpContextAccessor httpContextAccessor;

        public StoreController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        // GET: Store
        public ActionResult Store()
        {
            if (Request.Cookies["Currency"] == null) InitializeCurrency();
            return View(ProductCategoryDAO.SelectItemsByCategory(null));
        }

        [HttpGet]
        public ActionResult Search(string search, long page = 0, int capacity = 20)
        {
            if (Request.Cookies["Currency"] == null) InitializeCurrency();
            if (search == null) search = "";
            var products = CategoryProductDAO.FindProducts(search, Request.Cookies["Currency"]);
            CategoryProductsModel categoryProducts = new CategoryProductsModel
            {
                Products = products.Skip(capacity * (int)page).Take(capacity),
                Search = search,
                Page = page,
                Pages = (products.Count() - 1) / capacity,
            };
            ViewData["Search"] = search;
            return View(categoryProducts);
        }

        [HttpGet]
        public ActionResult Category(long? id, long page = 0, int capacity = 20)
        {
            if (Request.Cookies["Currency"] == null) InitializeCurrency();
            if (id == null) return View("NotFound");
            var products = CategoryProductDAO.SelectProductsByHierarchy(ProductCategoryDAO.Select(id).Id.Value, Request.Cookies["Currency"]);
            var categories = ProductCategoryDAO.SelectItemsByCategory(id).AsEnumerable();
            CategoryProductsModel categoryProducts = new CategoryProductsModel
            {
                Categories = categories,
                Products = products.Skip(capacity * (int)page).Take(capacity),
                Page = page,
                Pages = (products.Count() - 1) / capacity,
                Category = ProductCategoryDAO.Select(id)
            };
            return View(categoryProducts);
        }

        [HttpGet]
        public ActionResult Ratings(long? id, long page = 0, int capacity = 20)
        {
            if (id == null) return View("NotFound");
            var ratings = AccountRatingDAO.SelectItemsByProduct(id.Value);
            ProductRatingModel categoryProducts = new ProductRatingModel
            {
                Ratings = ratings.Skip(capacity * (int)page).Take(capacity).ToList(),
                Page = page,
                Pages = (ratings.Count() - 1) / capacity,
                RatingId = id.Value
            };
            return View(categoryProducts);
        }

        [HttpGet]
        public ActionResult Product(long? id)
        {
            if (Request.Cookies["Currency"] == null) InitializeCurrency();
            if (id == null) return View("NotFound");
            var product = new ProductCartModel { Product = ProductDAO.Select(id.Value) };
            product.Currency = currencyDAO.SelectBySymbol(Request.Cookies["Currency"]);
            product.ProductCurrency = ProductCurrencyDAO.SelectByProductAndCurrencyId(product.Product.Id, product.Currency.Id);
            ProductModel productModel = new ProductModel { Product = product };
            if(User.Identity.Name != null) productModel.Account = AccountDAO.SelectItemByLogin(User.Identity.Name);
            try
            {
                productModel.Rate = RatingDAO.SelectAverageRateByProduct(productModel.Product.Product);
            }
            catch (InvalidOperationException)
            {
                productModel.Rate = 0.0;
            }
            if (User.Identity.Name != null)
                if (OrderDetailsDAO.SelectItemsByAccountAndProduct(User.Identity.Name, id.Value).ToList().Count() > 0)
                    productModel.Bought = true;
            productModel.Ratings = AccountRatingDAO.SelectItemsByProduct(id.Value).Take(5).ToList();
            return View(productModel);
        }

        [HttpPost]
        public ActionResult Rate(int rank, string comment, long product)
        {
            var user = User.Identity.Name;
            var account = AccountDAO.SelectItemByLogin(user).Id;
            var rating = RatingDAO.SelectItemByAccount(account.Value);
            if (rating == null) RatingDAO.Insert(new Rating 
            { 
                Message = comment,
                Rate = rank, 
                Account = account, 
                Product = product, 
                Created = DateTime.Now,
                Updated = DateTime.Now
            });
            else RatingDAO.UpdateById(rating.Id.Value, new Rating { Message = comment, Rate = rank, Updated = DateTime.Now });
            return RedirectToAction("Product", new { Id = product });
        }

        public ActionResult Cart(long? id)
        {
            if (id == null) return View("NotFound");
            List<ProductCartModel> cart;
            if (HttpContext.Session.Get<List<ProductCartModel>>("cart") == null)
            {
                cart = new List<ProductCartModel> { ProductCartDAO.SelectProduct(id, httpContextAccessor.HttpContext.Request.Cookies["Currency"]) };
            }
            else
            {
                cart = HttpContext.Session.Get<List<ProductCartModel>>("cart");
                if (!CheckExist(id)) cart.Add(ProductCartDAO.SelectProduct(id, httpContextAccessor.HttpContext.Request.Cookies["Currency"]));
            }
            HttpContext.Session.Add("cart", cart);
            return RedirectToAction("Product", new { Id = id });
        }

        private bool CheckExist(long? id)
        {
            List<ProductCartModel> cart = HttpContext.Session.Get<List<ProductCartModel>>("cart");
            for (int i = 0; i < cart.Count; i++) if (cart[i].Product.Id == id) return true;
            return false;
        }

        private void InitializeCurrency()
        {
            CookieOptions option = new CookieOptions
            { Expires = DateTime.Now.AddYears(1), IsEssential = true, Secure = true };
            Response.Cookies.Append("Currency", "USD", option);
        }

    }
}
