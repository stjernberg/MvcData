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
    public class LanguageController : Controller
    {
        private ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }
        public IActionResult Index()
        {
            return View(_languageService.GetAll());
        }

        public ActionResult Details(int id)
        {
            Language language= _languageService.FindById(id);

            if (language == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateLanguageViewModel createLanguage)
        {
            if (ModelState.IsValid)
            {
                _languageService.Create(createLanguage);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createLanguage);
            }
        }

        public ActionResult Edit(int id)
        {
            Language language = _languageService.FindById(id);
            if (language == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreateLanguageViewModel createLanguage = new CreateLanguageViewModel();
            createLanguage.Name = language.Name;
            ViewBag.Id = language.Id;
            return View(createLanguage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateLanguageViewModel createLanguage)
        {
            if (ModelState.IsValid)
            {
                if (_languageService.Edit(id, createLanguage))
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("Couldn't save", "Unable to save changes");
            }

            ViewBag.Id = id;
            return View(createLanguage);
        }

    }
}
