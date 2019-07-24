using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Text;
using DataLayer.ViewModels;
using DataLayer;

namespace DataLayer.IRepository
{
    public interface IUsers
    {
        bool Login(string Email, string Pass);
        int GetAdminId(string Username);
        bool AddAdmin(UserViewModel AddA);
        List<User> GetUsers();
    }

}