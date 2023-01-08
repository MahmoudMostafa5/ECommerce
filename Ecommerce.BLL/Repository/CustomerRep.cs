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
    public class CustomerRep : ICustomerRep
    {
        private readonly ProductContext db;

        public CustomerRep(ProductContext db)
        {
            this.db = db;
        }
        
        public IEnumerable<Customer> GetAllProducts()
        {
            var data = db.Customers.Select(a => a);
            return data;
        }

        public Customer GetProductById(int id)
        {
            var data = db.Customers.Where(a => a.id == id).FirstOrDefault();
            return data;
        }
        
        public void Create(Customer model)
        {
            db.Customers.Add(model);
            db.SaveChanges();
        }
        public void Update(Customer model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Customer model)
        {
            db.Customers.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<product> productByCustId(int custId)
        {
            var data = db.Customers.Where(a => a.id == custId).Join(
                db.OrderProducts,
                a => a.id,
                b => b.Order.CusId,
                (a, b) => new product()
                {
                    id = b.product.id,
                    name = b.product.name,
                    color = b.product.color,
                    price = b.product.price,
                    Quantity = b.product.Quantity,
                    size = b.product.size,
                    description = b.product.description,
                    productUser = b.product.productUser
                });
            return (data);
        }
    }
}
