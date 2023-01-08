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
    public class District
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City city { get; set; }
    }
}
