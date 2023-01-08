using Ecommerce.BLL.Models;
using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interfaces
{
    public interface IProductRep
    {
        IEnumerable<product> GetAllProducts();
        product GetProductById(int id);
        void Create(product model);
        void Update(product model);

        void Delete(product model);
    }
}
