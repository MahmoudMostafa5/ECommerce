using AutoMapper;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Models;
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
    public class ProductRep : IProductRep
    {
        private readonly ProductContext db;
        private readonly IMapper mapper;

        //ProductContext db = new ProductContext();
        public ProductRep(ProductContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public IEnumerable<product> GetAllProducts()
        {
            var data = db.Products.Select(s => s);
            //new ProductVM()
            //{
            //    id = s.id,
            //    name = s.name,
            //    color = s.color,
            //    size = s.size,
            //    description = s.description,
            //    price = s.price,
            //    Quantity = s.Quantity,
            //    productUser = s.productUser
            //});
            return data;
        }
        public product GetProductById(int id)
        {
            var data = db.Products.Where(s => s.id == id).FirstOrDefault();
            //ProductVM res = new ProductVM()
            //{
            //    id = data.id,
            //    name = data.name,
            //    color = data.color,
            //    size = data.size,
            //    description = data.description,
            //    price = data.price,
            //    Quantity = data.Quantity,
            //    productUser = data.productUser
            //};
            return data;
        }

        public void Create(product model)
        {
            //product p = new product();
            //p.id = model.id;
            //p.name = model.name;
            //p.color = model.color;
            //p.size = model.size;
            //p.price = model.price;
            //p.description = model.description;
            //p.Quantity = model.Quantity;
            //p.productUser = model.productUser;

            db.Products.Add(model);
            db.SaveChanges();
        }
        public void Update(product model)
        {
            //product p = new product();
            //p.id = model.id;
            //p.name = model.name;
            //p.color = model.color;
            //p.size = model.size;
            //p.price = model.price;
            //p.description = model.description;
            //p.Quantity = model.Quantity;
            //p.productUser = model.productUser;

            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(product model)
        {
            //product m = new product();
            //m.id = model.id;
            //m.name = model.name;
            //m.color = model.color;
            //m.size = model.size;
            //m.price = model.price;
            //m.description = model.description;
            //m.Quantity = model.Quantity;
            //m.productUser = model.productUser;

            db.Products.Remove(model);
            db.SaveChanges();
        }

    }
}
