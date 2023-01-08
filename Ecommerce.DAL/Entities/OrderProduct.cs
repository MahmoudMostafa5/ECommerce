using Ecommerce.DAL.Entities;
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
    public class OrderProduct
    {
        [Key]
        [ForeignKey("order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("product")]
        public int ProductId { get; set; }
        public product product { get; set; }
    }
}
