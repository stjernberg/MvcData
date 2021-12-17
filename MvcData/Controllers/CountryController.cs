using Microsoft.AspNetCore.Mvc;
using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Controllers
{
    public class CountryController : Controller
    {
        private  ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            return View(_countryService.GetAll());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCountryViewModel createCountry)
        {
            if (ModelState.IsValid)
            {
                _countryService.Create(createCountry);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createCountry);
            }
           
        }


        public ActionResult Details(int id)
        {
            Country country = _countryService.FindById(id);

            if (country == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        public ActionResult Edit(int id)
        {
            Country country = _countryService.FindById(id);
            if (country == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreateCountryViewModel createCountry = new CreateCountryViewModel();
            createCountry.Name = country.Name;
            ViewBag.Id = country.Id;
            return View(createCountry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateCountryViewModel createCountry)
        {
            if (ModelState.IsValid)
            {
                if (_countryService.Edit(id, createCountry))
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("Couldn't save", "Unable to save changes");
            }

            ViewBag.Id = id;
            return View(createCountry);
        }

        public IActionResult Delete(int id)
        {
            

            _countryService.Remove(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
