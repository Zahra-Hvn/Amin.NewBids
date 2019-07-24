using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Irepository;
using DataLayer.Repository;
using DataLayer;
using DataLayer.ViewModels;
using NewBid_Admin.Models;




namespace NewBid_Admin.Controllers
{
    public class ProductController : Controller
    {

        // GET: Product
        public ActionResult Index()
        {
            var vp = new ProductRepository().GetAllProduct();

            return View(vp);
        }
        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult Details(int ProductId)
        {
            var vpd = new ProductRepository().GetProductById(ProductId);

            return View(vpd);
        }
        [HttpPost]
        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult UpDateProduct(ProductViewModel EProduct)
        {
            ProductRepository UP = new ProductRepository();
            UP.UpDateproduct(EProduct);
            ViewBag.message = "محصول مورد نظر به روز رسانی شد";
            return RedirectToAction("Index");
        }
        [HttpPost]
        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int DProduct)
        {
            ProductRepository EP = new ProductRepository();
            EP.DeleteProduct(DProduct);
            ViewBag.message = "محصول با موفقیت حذف شد";
            return RedirectToAction("Index");
        }
        [HttpGet]
        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult AddProduct()
        {
            MainViewModel MVM = new MainViewModel();
            //ViewBag.GP = MVM.getProduct ;
            MVM.getCategory = new CategoryRepository().GetCategoryViewModel();
            return View(MVM);
        }
        [HttpPost]
        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult AddProduct(MainViewModel model)
        {
            ProductRepository AP = new ProductRepository();
            var result= AP.Addproduct(model);
            if (result)
            {
                ViewBag.message = "محصول جدید اضافه شد";
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }
        public ActionResult Categorise()
        {
            var Ca = new CategoryRepository().GetCategorise();

            return View(Ca);
        }

        public ActionResult Category()
        {
            var Ca = new CategoryRepository().GetCategorise();

            return View(Ca);
        }

        [HttpPost]
        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult AddCategory(CategoryViewModel AC)
        {
            CategoryRepository AddC = new CategoryRepository();
            AddC.AddCategory(AC);
            return RedirectToAction("Category");
        }

        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult DeleteCategory(int DCategory)
        {
            CategoryRepository DC = new CategoryRepository();         
            DC.DeleteCategory(DCategory);

            return RedirectToAction("Category");
        }

        [HttpGet]
        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult EditeCategory(int CateId)
        {
            var ShowC = new CategoryRepository().GetCategoryById(CateId);
            ViewBag.m1 = ShowC.CategoryName;
            ViewBag.m2 = ShowC.Id;
            return View();
        }

        [HttpPost]
        [AdminPanelAuthorize(Roles = "Admin")]
        public ActionResult EditeCategory(int CateId, string CName)
        {
            bool Test = new CategoryRepository().EditeCategory(CateId, CName);
            if (Test)
            {
                return RedirectToAction("Category");

            }
            else
            {
                return RedirectToAction("index","ErrorHandler");

                //return RedirectToAction("Error");
            }
        }

    }
}