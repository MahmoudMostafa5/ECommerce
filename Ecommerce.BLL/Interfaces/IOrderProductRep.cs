using Ecommerce.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interfaces
{
    public interface IOrderProductRep
    {
        IEnumerable<OrderProduct> GetAllProducts();
        OrderProduct GetProductById(int id);
        public void Create(int orderId, int productId);
        void Update(OrderProduct model);

        void Delete(OrderProduct model);
    }
}
