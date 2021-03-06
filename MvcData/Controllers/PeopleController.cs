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
        private readonly ICityService _cityService;

        
        public PeopleController(IPeopleService peopleService, ICityService cityService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
        }


        [HttpGet]
        public IActionResult Create()
        {
            CreatePersonViewModel model = new CreatePersonViewModel();
            model.Cities = _cityService.GetAll();
            return View(model);
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
                    createPerson.Cities = _cityService.GetAll();
                    return View(createPerson);
                }
                return RedirectToAction(nameof(Index));

            }
            createPerson.Cities = _cityService.GetAll();
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            CreatePersonViewModel editPerson = new CreatePersonViewModel()
            {
                Name = person.Name,
                PhoneNr = person.PhoneNr,
                CityId = person.Id,
            };
            editPerson.Cities = _cityService.GetAll();

            ViewBag.Id = id;

            return View(editPerson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreatePersonViewModel editPerson)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, editPerson);

                return RedirectToAction("Index");
            }
            editPerson.Cities = _cityService.GetAll();
            ViewBag.Id = id;

            return View(editPerson);
        }
        public IActionResult LanguageConnection(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
              
            }

            return View(_peopleService.LanguageConnection(person));
        
        }
        public IActionResult AddLanguage(int personId, int langId)
        {
            Person person = _peopleService.FindById(personId);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _peopleService.AddLanguage(person, langId);

            return RedirectToAction(nameof(LanguageConnection), new { id = person.Id });
        }

        public IActionResult RemoveLanguage(int personId, int langId)
        {
            Person person = _peopleService.FindById(personId);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _peopleService.RemoveLanguage(person, langId);

            return RedirectToAction(nameof(LanguageConnection), new { id = person.Id });
        }

        public IActionResult Delete(int id)
        {
            
            _peopleService.Remove(id);

            return RedirectToAction(nameof(Index));
          
        }

    }
}
