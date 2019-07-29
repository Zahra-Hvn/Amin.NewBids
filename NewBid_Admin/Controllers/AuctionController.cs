using DataLayer.Repository;
using DataLayer.Utilites;
using DataLayer.ViewModels;
using MD.PersianDateTime;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewBid_Admin.Controllers
{

    public class AuctionController : Controller
    {
        private AuctionRepository repo = new AuctionRepository();
        private ProductRepository ProRepo = new ProductRepository();
        // GET: Auction
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var list = repo.GetViewModel();
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult AddAuction()
        {
            var allProduct = ProRepo.GetProForDop();
            var persianDateTime = new PersianDateTime(DateTime.Now);
            ViewBag.PDate = persianDateTime.Date;
            ViewBag.PTime = persianDateTime.GetTime();
            string PersianDate = persianDateTime.ToLongDateTimeString();

            return View(allProduct);
        }
        [HttpPost]
        public ActionResult AddAuction(AuctionAddViewModel model)
        {
            TimeSpan tooBig = new TimeSpan(2, 8, 8, 8);
            

            //yourDbEntity.timeValue = temp;



            PersianDateTime persianDate = new PersianDateTime();
            var dd = model.Date.Split('-');
            persianDate = new PersianDateTime(int.Parse(dd[0]), int.Parse(dd[1]), int.Parse(dd[2]), model.Auction_Time.Hours, model.Auction_Time.Minutes, 0);
            var dateMi = persianDate.ToDateTime();//convert datetime Persian  to miladi
            var cur = DateTime.Now.AddSeconds(-DateTime.Now.Second);//datetime without seconde
            var def = dateMi.Subtract(cur);//get def
            var auction_Time = new TimeSpan(def.Days, def.Hours, def.Minutes,0,0);
            var h = auction_Time.Days * 24;
            var hh = h + auction_Time.Hours;
            var timestring = auction_Time.TotalHours;
            //to database
            Int64 tooBigBits = auction_Time.Ticks;
            Int64 truncated = tooBigBits >> 24;
            TimeSpan temp = TimeSpan.FromTicks(truncated);

            //from database
            //Int64 truncated1 = temp.Ticks;
            //Int64 adjusted = truncated1 << 24;
            //TimeSpan actual = TimeSpan.FromTicks(adjusted);


            model.Auction_Time = temp;
            var result = repo.AddAuction(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var allProduct = ProRepo.GetProForDop();
                return View(allProduct);
            }
        }
        public ActionResult ShowAuctions()
        {
            return View();
        }
        public ActionResult GetAuctiontime(int id)
        {
            var res = repo.GetAuctionById(id).Auction_Time.ToString();
            return Json(res);
        }
        public ActionResult ChangeStatus(int id)
        {
            var res = repo.ChangeStatus(id);
            return Json(res);
        }
    }
}