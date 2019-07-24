using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class AuctionRepository
    {
        public List<Auction> GetAuctions()
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                return db.Auctions.ToList();
            }
        }
        public Auction GetAuctionById(int id)
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                return db.Auctions.Find(id);
            }
        }
        public List<AuctionViewModel> GetViewModel()
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                var q = (from p in db.Auctions
                         
                        join im in db.Images on p.ProductId equals im.ProductId into img
                        from image in img.DefaultIfEmpty()
                        group new {p,image} by p.Id into gr
                        select new 
                        {
                            Auction_Time = gr.FirstOrDefault().p.Auction_Time,
                            Id = gr.FirstOrDefault().p.Id,
                            IsActive = gr.FirstOrDefault().p.IsActive,
                            Image = gr.FirstOrDefault().image,
                            Title= gr.FirstOrDefault().p.Product.Name
                        }).OrderByDescending(x=>x.Auction_Time).ToList();
                var q2 = q.Select(x => new AuctionViewModel
                {
                    Id = x.Id,
                    Str_AuctionTime = ConvertAuctionTimeToStr(x.Auction_Time),
                    Image =x.Image!=null? x.Image.ImageTitle:"",
                    IsActive = x.IsActive,
                    Title = x.Title
                }).ToList();
                return q2;
            }
        }
        public string ConvertAuctionTimeToStr(TimeSpan time)
        {
            Int64 truncated1 = time.Ticks;
            Int64 adjusted = truncated1 << 24;
            TimeSpan actual = TimeSpan.FromTicks(adjusted);
            var h = (time.Days * 24) + time.Hours;
            var str = ((actual.Days * 24) + actual.Hours) + ":" + actual.Minutes + ":" + actual.Seconds;
            return str;
        }
        public bool ChangeStatus(int id)
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                var auction = db.Auctions.Find(id);
                auction.IsActive=auction.IsActive? false : true;
                db.Entry(auction).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges()==1?true:false;
            }
        }
        public bool AddAuction(AuctionAddViewModel model)
        {
            using(QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                var auction = new Auction
                {
                    
                    Auction_Time = model.Auction_Time,
                    BuyPrice = model.BuyPrice,
                    Close_Time = model.Close_Time,
                    IsActive = true,
                    ProductId = model.ProductId,
                };
                db.Auctions.Add(auction);
                return db.SaveChanges() == 1 ? true : false;
            }
        }
    }
}
