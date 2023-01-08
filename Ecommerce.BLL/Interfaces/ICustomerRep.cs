using Ecommerce.DAL.Database;
using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interfaces
{
    public interface ICustomerRep
    {
        IEnumerable<Customer> GetAllProducts();
        Customer GetProductById(int id);

        void Create(Customer model);
        void Update(Customer model);
        void Delete(Customer model);

        IEnumerable<product> productByCustId(int custId);
    }
}
