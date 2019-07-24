using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Irepository;
using DataLayer.Repository;
using NewBid_Admin.Models;
using DataLayer;
using DataLayer.ViewModels;
using DataLayer.Utilites;


namespace NewBid_Admin.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(A_LoginViewModel LVM )
        {
            string pass =  new Helpers().Encryption(LVM.PassWord);
            UserRepository LI = new UserRepository();
            if (LI.Login(LVM.Email , pass) )
            {
                //var s = LI.GetAdminId(UName).ToString();
                Session["UserId"] = "Admin";
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.message = "نام کاربری یا رمز اشتباه است";
                return View();
            }

        }
        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session["UserId"] = null;
            return RedirectToAction("login");
        }
        
    }
}