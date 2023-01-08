using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Please Enter Your Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Your ConfirmPassword")]
        [Compare("Password",ErrorMessage ="Not Match")]
        public string ConfirmPassword { get; set; }
    }
}
