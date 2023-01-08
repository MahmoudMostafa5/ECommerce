using AutoMapper;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Models;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductRep _repo;
        private readonly IMapper mapper;

        // Ex
        public ProductApiController(IProductRep repo, IMapper mapper)
        {
            _repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Display1")]
        public IActionResult Display1()
        {
            try
            {
                string[] Names = { "Mahmoud", "Ahmed", "Mohamed", "Mostafa" };
                ProductCustom custom = new ProductCustom() { Code = "200", Message = "Success" };
                return Ok(custom);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // CRUD on Product

        [HttpGet]
        [Route("Display2")]
        public IActionResult Display2()
        {
            try
            {
                string[] Names = { "Raina", "Norhan", "Reda", "Rawan" };
                return Ok(Names);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Product")]
        public IActionResult Index()
        {
            try
            {
                var data = _repo.GetAllProducts();
                var res = mapper.Map<IEnumerable<ProductVM>>(data);
                ProductCustom custom = new ProductCustom() { Code = "200", Message = "Success", Records = res };
                return Ok(custom);
            }
            catch (Exception)
            {
                ProductCustom custom = new ProductCustom() { Code = "404", Message = "Failed" };
                return NotFound(custom);
            }
            
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult Create(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                _repo.Create(mapper.Map<product>(model));
                var data = _repo.GetAllProducts();
                return Ok(data);
            }
            else
                return  NotFound();
        }

        [HttpPut]
        [Route("EditProduct")]
        public IActionResult Edit(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(mapper.Map<product>(model));
                var data = _repo.GetAllProducts();
                return Ok(data);
            }
            else
                return NotFound();
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var prod = _repo.GetProductById(id);
                _repo.Delete(prod);

                var data = _repo.GetAllProducts();
                return Ok(data);
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }
    }
}
