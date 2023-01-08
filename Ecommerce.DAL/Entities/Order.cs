using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Database
{
    //[Keyless]
    public class Order
    {
        public Order()
        {
            this.orderProducts = new HashSet<OrderProduct>();
        }
        [Key]
        public int id { get; set; }
        public DateTime OrderTime { get; set; }
        [ForeignKey("Customer")]
        public int CusId { get; set; }
        public virtual Customer Customer { get; set; }

        public ICollection<OrderProduct> orderProducts { get; set; }
    }
}
