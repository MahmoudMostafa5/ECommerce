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
    public class CustomerController : Controller
    {
        private readonly ICustomerRep repo;
        private readonly IMapper mapper;

        public CustomerController(ICustomerRep repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = repo.GetAllProducts();
            return View(mapper.Map<IEnumerable<CustomerVM>>(data));
        }
        public IActionResult Details(int id)
        {
            var data = repo.GetProductById(id);
            return View(mapper.Map<CustomerVM>(data));
        }
        public IActionResult Edit(int id)
        {
            var data = repo.GetProductById(id);
            return View(mapper.Map<CustomerVM>(data));
        }
        [HttpPost]
        public IActionResult Edit(CustomerVM model)
        {
            if (ModelState.IsValid)
            {
                repo.Update(mapper.Map<Customer>(model));
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(CustomerVM model)
        {
            repo.Create(mapper.Map<Customer>(model));
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var data = repo.GetProductById(id);
            repo.Delete(data);
            return RedirectToAction("Index");
        }
        public IActionResult CheckProducts()
        {
            var Customers = repo.GetAllProducts();
            ViewBag.cust = new SelectList(Customers, "id", "name");
            return View();
        }
        [HttpPost]
        public JsonResult CheckProducts(int id)
        {
            var data = repo.productByCustId(id);
            return Json(data);
        }
    }
}
