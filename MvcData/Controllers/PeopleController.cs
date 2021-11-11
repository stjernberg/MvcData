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
        public IActionResult PersonData()
        {
            return View(_peopleService.All());
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
                _peopleService.Add(createPerson);

                return RedirectToAction(nameof(PersonData));
                //return View(PeopleData);

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
                return RedirectToAction(nameof(Details));
            }

            //Om det inte går att ta bort personen????

            return RedirectToAction(nameof(Details));

        }

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        public IActionResult Search(string search)
        {
            //List<Person> searchList;

            //if (!string.IsNullOrEmpty(search))
            //{
            //    searchList = _peopleService.Search(search);

            //    return RedirectToAction("PersonData", searchList);
            //}

            //    return RedirectToAction(nameof(PersonData));



        }
    }
}
