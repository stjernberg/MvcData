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
    public class AjaxController : Controller
    {
        IPeopleService _peopleService;

      

        public AjaxController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Index()
        {
             return View();
        }

        public IActionResult ShowList()
        {
            List<Person> people = _peopleService.All();

            if (people != null)
            {
                return PartialView("_ListOfPeople", people);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult DetailsAjax(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person != null)
            {
                return PartialView("_PeopleDetails", person);
            }

            return NotFound();

        }

        [HttpPost]
        public IActionResult DeleteAjax(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person != null)
            {
                _peopleService.Remove(id);
                return RedirectToAction(nameof(ShowList));
               
            }

            return NotFound();

        }
    }
}
