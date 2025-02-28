﻿using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Models
{
    public class CityVm
    {
        public int id { get; set; }
        public string name { get; set; }
        public int CountyId { get; set; }

        [ForeignKey("CountyId")]
        public Country country { get; set; }
    }
}
