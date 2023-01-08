using AutoMapper;
using Ecommerce.BLL.Helper;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Models;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Ecommerce.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRep repo;
        private readonly IMapper mapper;
        private readonly ICountryRep cont;
        private readonly ICityRep city;
        private readonly IDistrictRep dis;

        public SupplierController(ISupplierRep repo, IMapper mapper,ICountryRep cont,ICityRep city,IDistrictRep dis)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.cont = cont;
            this.city = city;
            this.dis = dis;
        }

        public IActionResult Index()
        {
            var data = repo.GetAll();
            var res = mapper.Map<IEnumerable<SupplierVM>>(data);
            return View(res);
        }

        public IActionResult Create()
        {
            var data = cont.getAll();
            var res = mapper.Map<IEnumerable<CountryVM>>(data);
            ViewBag.countries = new SelectList(res, "id", "name");

            return View();
        }
        [HttpPost]

        public IActionResult Create(SupplierVM supVm)
        {
            

            var res = mapper.Map<Supplier>(supVm);
            res.photourl = FileUploader.uploadFile("/Files", supVm.Photo);
            res.Fileurl = FileUploader.uploadFile("/Files", supVm.File);

            //FilePath.photourl = FinalPath;
            repo.Create(res);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult getCities(int id)
        {
            var data = city.getAll(id);
            var res = mapper.Map<IEnumerable<CityVm>>(data);
            return Json(res);
        }

        [HttpPost]
        public JsonResult getDistricts(int id)
        {
            var data = dis.getAll(id);
            var res = mapper.Map<IEnumerable<DistrictVM>>(data);
            return Json(res);
        }

        public IActionResult delete(int id)
        {
            var data = repo.getById(id);

            repo.Delete(data);
            FileUploader.DeleteFile("Files/", data.Fileurl);
            FileUploader.DeleteFile("Files/", data.photourl);

            return RedirectToAction("index");

        }
    }
}
