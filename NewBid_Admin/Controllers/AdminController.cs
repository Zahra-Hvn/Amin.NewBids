using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataLayer;
using DataLayer.Repository;
using DataLayer.Irepository;
using DataLayer.ViewModels;
using NewBid_Admin.Models;


namespace NewBid_Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult Profile(int UId = 2)
        {
            UserRepository SP = new UserRepository();
            return View(SP.GetUserById(UId));
        }
        [HttpGet]
        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult AddAdmin()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult AddAdmin(UserViewModel model)
        {
            UserRepository AP = new UserRepository();
            var result = AP.AddAdmin(model);
            if (result)
            {
                return RedirectToAction("Profile");

            }
            AP.AddAdmin(model);
            return View();
        }
    }
}