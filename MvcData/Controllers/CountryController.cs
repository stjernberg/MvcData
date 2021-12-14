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
        private readonly ICountryService _countryService;

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
            return View(new CreateCountryViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCountryViewModel createCountry)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _countryService.Create(createCountry);
                }

                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Name", exception.Message);
                    return View(createCountry);
                }

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

        public IActionResult Delete(int id)
        {
            Country country = _countryService.FindById(id);

            if (country == null)
            {
                return NotFound();

            }

            _countryService.Remove(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
