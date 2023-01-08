using Ecommerce.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interfaces
{
    public interface IOrderRep
    {
        IEnumerable<Order> GetAllProducts();
        Order GetProductById(int id);

        int Create(Order model);
        //void Update(Order model);
        void Delete(Order model);

        int Count();
    }
}
