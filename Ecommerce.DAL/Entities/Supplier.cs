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
    //[Keyless]
    public class Supplier
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District district { get; set; }
        public string photourl { get; set; }
        public string Fileurl { get; set; }
    }
}
