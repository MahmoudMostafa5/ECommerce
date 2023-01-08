using AutoMapper;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Models;
using Ecommerce.BLL.Repository;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class ProducController : Controller
    {
        private readonly IProductRep _repo;
        private readonly IMapper mapper;

        //ProductRep _repo = new ProductRep();
        public ProducController(IProductRep repo,IMapper mapper)
        {
            _repo = repo;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = _repo.GetAllProducts();
            return View(mapper.Map<IEnumerable<ProductVM>>(data));
        }

        public IActionResult Details(int id)
        {
            var data = _repo.GetProductById(id);
            return View(mapper.Map<ProductVM>(data));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                _repo.Create(mapper.Map<product>(model));
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

        public IActionResult Edit(int id)
        {
            var data = _repo.GetProductById(id);
            return View(mapper.Map<ProductVM>(data));
        }
        [HttpPost]
        public IActionResult Edit(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(mapper.Map<product>(model));
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

        public IActionResult Delete(int id)
        {
            var data = _repo.GetProductById(id);
            _repo.Delete(data);
            return RedirectToAction("Index");
        }
        
        public IActionResult InStock()
        {
            var data = _repo.GetAllProducts();
            ViewBag.prod = new SelectList(data, "id", "name");
            return View();
        }
        [HttpPost]
        public IActionResult InStock(int id)
        {
            var data = _repo.GetProductById(id);
            return Json(data.Quantity);
        }
    }
}
