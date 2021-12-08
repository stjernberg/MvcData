using Microsoft.AspNetCore.Mvc;
using MvcData.Models;
using MvcData.Models.Repos;
using MvcData.Models.Service;
using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;



        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePersonViewModel());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _peopleService.Add(createPerson);
                }

                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Name & City", exception.Message);
                    return View(createPerson);
                }
                return RedirectToAction(nameof(Index));

            }
            return View(createPerson);
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Person> peopleList = _peopleService.All();
            if (peopleList != null)
            {
                return View(peopleList);
            }
            return View();

        }

        [HttpPost]
        public IActionResult Index(string search, string type)
        {
            List<Person> peopleList = _peopleService.Search(search, type);
            if (peopleList != null)
            {
                return View(peopleList);
            }
            return View();

        }

        public IActionResult AjaxSearch(string search, string type)
        {
            List<Person> peopleList = _peopleService.Search(search, type);


            if (peopleList != null)
            {
                return View(peopleList);
                //return PartialView("_ListOfPeople", peopleList);
            }

            return View();
        }

        public IActionResult SortList(string sorting)
        {
            List<Person> peopleList = _peopleService.Sort(sorting);
            if (peopleList != null)
            {
                return View("Index", peopleList);
            }
            return View("Index");
        }


        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return NotFound();
                
            }

            _peopleService.Remove(id);

            return RedirectToAction(nameof(Index));

          

        }

    }
}
