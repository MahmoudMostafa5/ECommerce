using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Please Enter Your Name")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
