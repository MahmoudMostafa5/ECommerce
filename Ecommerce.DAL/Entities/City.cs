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
    public class City
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country country { get; set; }
    }
}
