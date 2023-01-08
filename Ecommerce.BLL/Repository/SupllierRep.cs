using Ecommerce.BLL.Interfaces;
using Ecommerce.DAL.Database;
using Ecommerce.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Repository
{
    public class SupllierRep : ISupplierRep
    {
        private readonly ProductContext db;

        public SupllierRep(ProductContext db)
        {
            this.db = db;
        }

        public void Create(Supplier model)
        {
            db.Suppliers.Add(model);
            db.SaveChanges();
        }

        public void Delete(Supplier model)
        {
            db.Suppliers.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<Supplier> GetAll()
        {
            var data = db.Suppliers.Include(a => a.district).ToList();
            return data;
        }

        public Supplier getById(int id)
        {
            var data = db.Suppliers.Where(a => a.id == id).FirstOrDefault();
            return (data);
        }
    }
}
