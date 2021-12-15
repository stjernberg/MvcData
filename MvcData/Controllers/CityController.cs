using Microsoft.AspNetCore.Mvc;
using MvcData.Models;
using MvcData.Models.Service;
using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Controllers
{
    public class CityController : Controller
    {
        private ICityService _cityService;
        private ICountryService _countryService;

        public CityController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
           
        }
        public IActionResult Index()
        {
            return View(_cityService.GetAll());
        }


        [HttpGet]
        public IActionResult Create()
        {
            CreateCityViewModel model = new CreateCityViewModel();
            model.Countries = _countryService.GetAll();
            return View(model);
        }
    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCityViewModel createCity)
        {
            

            if (ModelState.IsValid)
            {
                _cityService.Create(createCity);
                return RedirectToAction(nameof(Index));
            }

            return View(createCity);

        }

        public ActionResult Edit(int id)
        {
            City city = _cityService.FindById(id);
            if (city == null)
            {
                return RedirectToAction(nameof(Index));                
            }

            CreateCityViewModel createCity= new CreateCityViewModel();
            createCity.CityName = city.CityName;
            ViewBag.Id = city.Id;
            return View(createCity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateCityViewModel createCity)
        {
            if (ModelState.IsValid)
            {
                if (_cityService.Edit(id, createCity))
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("Couldn't save", "Unable to save changes");
            }

            ViewBag.Id = id;
            return View(createCity);
        }

        public IActionResult Delete(int id)
        {
            City city = _cityService.FindById(id);

            if (city == null)
            {
                return NotFound();

            }

            _cityService.Remove(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
