using Ecommerce.BLL.Interfaces;
using Ecommerce.DAL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Repository
{
    public class OrderRep : IOrderRep
    {
        private readonly ProductContext db;
        public OrderRep(ProductContext db)
        {
            this.db = db;
        }
        public IEnumerable<Order> GetAllProducts()
        {
            var data = db.Orders.Include(a => a.Customer)
                                .Include(a => a.orderProducts)
                                .ThenInclude(a => a.product)
                                .Select(a => a);
            return data;
        }

        public Order GetProductById(int id)
        {
            var data = db.Orders.Include(a => a.Customer).Where(a => a.id == id).FirstOrDefault();
            return data;
        }
                
        public int Create(Order model)
        {
            db.Orders.Add(model);
            db.SaveChanges();
            return model.id;
        }
        public void Delete(Order model)
        {
            db.Orders.Remove(model);
            db.SaveChanges();
        }

        public int Count()
        {
            return db.Orders.Count();
        }
    }
}
