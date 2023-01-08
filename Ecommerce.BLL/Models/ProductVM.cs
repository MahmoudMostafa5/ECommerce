using Ecommerce.DAL.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Models
{
    public class ProductVM
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        public string name { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public double price { get; set; }
        public int Quantity { get; set; }
        public string description { get; set; }
        public string productUser { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
