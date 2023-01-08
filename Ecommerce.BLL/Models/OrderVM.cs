using Ecommerce.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Models
{
    public class OrderVM
    {
        public int id { get; set; }
        public DateTime OrderTime { get; set; }
        public IEnumerable<int> ProductsId { get; set; }
        public int CusId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderProduct> orderProducts { get; set; }
    }
}
