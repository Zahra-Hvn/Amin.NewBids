using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*-----------*/
using DataLayer;
using DataLayer.IRepository;
using DataLayer.ViewModels;
using DataLayer.Utilites;

namespace DataLayer.Repository
{
    public class UserRepository : IUsers
    {
        public UserRepository()
        {
        }
        public List<User> GetUsers()
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                return db.Users.ToList();
            }
        }
        public User GetUserById(int UserId)
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                return db.Users.Where(a => a.Id == UserId).FirstOrDefault();
            }
        }
        public bool AddAdmin(UserViewModel model)
        {
            var result = false;
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                var pass = new Helpers().Encryption(model.PassWord);
                User tb = new User
                {
                    Email = model.Email,
                    Password = new Helpers().Encryption(model.PassWord),
                    Fname = model.FirstName,
                    Lname = model.LastName,
                    Address = model.Address,
                    Mobile = model.PhonNumber,
                    //Image = model.Imageurl
                };
                db.Users.Add(tb);
                result = db.SaveChanges() == 1 ? true : false;

                return result;
            }
        }

        public int GetAdminId(string Username)
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                var q = db.Users.Where(a => a.Email == Username).FirstOrDefault();
                if (q != null)
                {
                    return q.Id;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool Login(string Email, string PWord)
        {
            using (QuiBidsEntities1 db = new QuiBidsEntities1())
            {
                var q = db.Users.Where(a => a.Email == Email && a.Password == PWord).FirstOrDefault();
                if (q != null)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }
    }
}