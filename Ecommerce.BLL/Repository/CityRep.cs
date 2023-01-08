using Ecommerce.BLL.Interfaces;
using Ecommerce.DAL.Database;
using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Repository
{
    public class CityRep : ICityRep
    {
        private readonly ProductContext db;

        public CityRep(ProductContext db)
        {
            this.db = db;
        }
        public IEnumerable<City> getAll(int id)
        {
            var data = db.Cities.Where(a => a.CountryId == id).ToList();
            return data;
        }

        //public IEnumerable<City> GetAll(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
