using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels
{
    public class AuctionViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public TimeSpan Auction_Time { get; set; }
        public string Image { get; set; }
        public string Title{ get; set; }
        public string Str_AuctionTime { get; set; }


    }
    public class AuctionAddViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public TimeSpan Auction_Time { get; set; }
        public int Close_Time { get; set; }
        public int Reserve_Price { get; set; }
        public int CurrentBid_Id { get; set; }
        public int Current_UserId { get; set; }
        public bool StartStatus { get; set; }
        public bool IsClose { get; set; }
        public int BuyPrice { get; set; }
        public bool IsActive { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
    }
}
