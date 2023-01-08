using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Models
{
    public class ProductCustom
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public IEnumerable<ProductVM> Records { get; set; }
    }
}
