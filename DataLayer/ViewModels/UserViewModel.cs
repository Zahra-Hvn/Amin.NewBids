using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.IRepository;

using System.ComponentModel.DataAnnotations;


namespace DataLayer.ViewModels
{
    public class UserViewModel 
    {
        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhonNumber { get; set; }
        //public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Address { get; set; }
        public string Imageurl { get; set; }
        public string Email { get; set; }

    }
}