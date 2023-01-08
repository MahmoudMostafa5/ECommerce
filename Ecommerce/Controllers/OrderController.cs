using AutoMapper;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Models;
using Ecommerce.DAL.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRep repo;
        private readonly IMapper mapper;
        private readonly IProductRep p;
        private readonly ICustomerRep c;
        private readonly IOrderProductRep or;

        public OrderController(IOrderRep repo , IMapper mapper,IProductRep p , ICustomerRep c,IOrderProductRep or)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.p = p;
            this.c = c;
            this.or = or;
        }
        public IActionResult Index()
        {
            var data = repo.GetAllProducts();
            return View(mapper.Map<IEnumerable<OrderVM>>(data));
        }
        public IActionResult Create()
        {
            var customer = c.GetAllProducts();
            var products = p.GetAllProducts();

            ViewBag.cust = new SelectList(customer, "id", "name");
            ViewBag.prod = new SelectList(products, "id", "name");

            return View();
        }
        [HttpPost]
        public IActionResult Create(OrderVM model)
        {
            var data = repo.Create(mapper.Map<Order>(model));

            foreach (var item in model.ProductsId)
            {
                or.Create(data, item);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var data = repo.GetProductById(id);
            repo.Delete(data);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var data = repo.GetProductById(id);
            return View(mapper.Map<OrderVM>(data));
        }
        public JsonResult Count()
        {
            var data = repo.Count();
            return Json(data);
        }
    }
}
