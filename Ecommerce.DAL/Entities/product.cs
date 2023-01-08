using Ecommerce.DAL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    [Table("Product")]
    //[Keyless]
    public class product
    {
        public product()
        {
            this.OrderProducts = new HashSet<OrderProduct>();
        }
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public string size { get; set; }
        public double price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string description { get; set; }
        public string productUser { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
