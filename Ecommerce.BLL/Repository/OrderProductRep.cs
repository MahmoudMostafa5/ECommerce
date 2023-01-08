using Ecommerce.BLL.Interfaces;
using Ecommerce.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Repository
{
    public class OrderProductRep : IOrderProductRep
    {
        private readonly ProductContext db;

        public OrderProductRep(ProductContext db)
        {
            this.db = db;
        }
        public void Create(int orderId , int productId)
        {
            db.OrderProducts.Add(new OrderProduct() { OrderId=orderId,ProductId=productId});
            db.SaveChanges();
        }

        public void Delete(OrderProduct model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderProduct> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public OrderProduct GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderProduct model)
        {
            throw new NotImplementedException();
        }
    }
}
