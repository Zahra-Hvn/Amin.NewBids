using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;


namespace DataLayer.ViewModels
{
    public class A_LoginViewModel
    {
        [Required]
        [EmailAddress]
        [MinLength(3 , ErrorMessage ="لطفا بیش از 3 کاراکتر وارد کنید"),MaxLength(25)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(5 , ErrorMessage ="لطفا بیش از 5 کاراکتر وارد کنید") , MaxLength(25 , ErrorMessage ="رمز عبور نباید بیش از 25 کاراکتر باشد")]
        public string PassWord { get; set; }
    }
}
