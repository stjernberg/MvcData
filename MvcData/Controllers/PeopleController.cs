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

        public PeopleController()
        {
            _peopleService = new PeopleService(new InMemoryPeopleRepo());
        }
        public IActionResult PersonData(PeopleViewModel searchViewModel)
        {
            List<Person> searchList;

            if (!string.IsNullOrEmpty(searchViewModel.Search))
            {
                searchList = _peopleService.Search(searchViewModel.Search);
            }
            else
            {
                searchList = _peopleService.All();
            }

            return View(searchList);
           
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
                return RedirectToAction(nameof(PersonData));
              
            }
            return View(createPerson);
        }

        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person == null)
            {
                return RedirectToAction(nameof(PersonData));
            }

            return View(person);
        }

        public IActionResult Delete(int id)
        {
            
            if (_peopleService.Remove(id))
            {
                return RedirectToAction(nameof(PersonData));
            }

        
            return RedirectToAction(nameof(PersonData));

        }

    }
}
