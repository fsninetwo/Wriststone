using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using Wriststone.Models.DAO;
using Wriststone.Models.Table;
using Wriststone.Models.ViewModel;
using Wriststone.Static_Methods;

namespace Wriststone.Controllers
{
    public class ProfileController : Controller
    {
        readonly AccountDAO accountDAO = new AccountDAO();
        readonly AccountProductDAO accountProductDAO = new AccountProductDAO();
        readonly AccountOrderDAO accountOrderDAO = new AccountOrderDAO();
        readonly AccountStatusDAO accountStatusDAO = new AccountStatusDAO();
        readonly AccountGroupDAO accountGroupDAO = new AccountGroupDAO();
        readonly OrderProductDAO orderProductDAO = new OrderProductDAO();
        readonly ProductDAO productDAO = new ProductDAO();
        readonly OrderDAO orderDAO = new OrderDAO();

        public ProfileController()
        {

        }

        [HttpGet]
        public ActionResult Profile(string id)
        {
            if (id == null) return View("NotFound");
            ViewBag.User = id;
            return View(accountDAO.SelectItemByLogin(id));
        }

        public ActionResult SignUp()
        {
            RequestHeaders header = Request.GetTypedHeaders();
            Uri UriReferer = header.Referer;
            return View(UriReferer);
        }

        [HttpPost]
        public ActionResult SignUp(string login, string password, Uri redirect)
        {
            Account user;
            try
            {
                user = accountDAO.SelectItemByCreditals(login, password);
            }
            catch (InvalidOperationException)
            {
                ViewData["error"] = "Your login and/or password is invaild. Please try again!";
                return View(redirect);
            }
            if (User.Identity.Name != null) HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var identity = new ClaimsIdentity(new[]
                { new Claim(ClaimTypes.Name, user.Login) }, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            if (redirect == null) return View("Profile");
            return Redirect(redirect.ToString());
        }

        public ActionResult Logout()
        {
            try
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (NullReferenceException) { }
            return RedirectToAction("Store", "");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string login, string email, string password, string fullname)
        {
            if (accountDAO.SelectItemByLogin(login) != null)
            {
                ViewData["error"] = "This login is already exists. Try different login!";
                return View();
            }
            else if (accountDAO.SelectItemByEmail(login) != null)
            {
                ViewData["error"] = "This email is already exists. Try different email!";
                return View();
            }
            accountDAO.Insert(new Account { 
                Login = login, 
                Email = email, 
                Password = password, 
                Fullname = fullname, 
                Created = DateTime.Now,
                Status = accountStatusDAO.SelectByName("Idle"),
                Group = accountGroupDAO.SelectByName("User")
            });
            return View("SignUp");
        }

        public ActionResult Edit()
        {
            if (User.Identity.Name == null) return View("NotFound");
            return View(accountDAO.SelectItemByLogin(User.Identity.Name));
        }

        [HttpPost]
        public ActionResult Edit(string id, IFormFile file, string email, string password, string fullname)
        {
            string avatarPath = "";
            if(file != null)
            {
                System.IO.File.Delete(accountDAO.SelectItemByLogin(User.Identity.Name).Avatar);
                var newFileName = "avatar" + Path.GetExtension(Path.GetFileName(file.FileName));
                using (FileStream fs = System.IO.File.Create(new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "avatars", User.Identity.Name.ToLower())).Root + $@"\{newFileName}"))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                avatarPath = $"{newFileName}";
            }
            accountDAO.UpdateById(accountDAO.SelectItemByLogin(id).Id.Value, new Account 
            { 
                Email = email, 
                Password = password, 
                Fullname = fullname, 
                Avatar = avatarPath 
            });
            return RedirectToAction("Profile");
        }

        public ActionResult Order(long? id)
        {
            if (User.Identity.Name == null) return View("NotFound");
            return View(orderProductDAO.SelectItemByAccount(User.Identity.Name, id));
        }
        public ActionResult Orders()
        {
            if (User.Identity.Name == null) return View("NotFound");
            return View(accountOrderDAO.SelectItemsByAccount(User.Identity.Name));
        }
        public ActionResult Products()
        {
            if (User.Identity.Name == null) return View();
            return View(accountProductDAO.SelectItemsByAccount(User.Identity.Name));
        }

        public ActionResult Recovery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recovery(string email, string password, string confirmpassword)
        {
            try
            {
                if (password.Equals(confirmpassword)) accountDAO.UpdatePassword(email, password);
                else
                {
                    ViewData["error"] = "Your password is invaild. Please try again!";
                    return View();
                }
            }
            catch (InvalidOperationException)
            {
                ViewData["error"] = "Your email is invaild or absent. Please try again!";
                return View();
            }
            return RedirectToAction("SignUp");
        }
    }
}
