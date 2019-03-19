using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core_WebApp.Models;
using Core_WebApp.Repositories;
using Core_WebApp.CustomSessionProvider;
namespace Core_WebApp.Controllers
{
    public class CategoryController : Controller
    {
        IRepository<Category, int> catRepository;

        public CategoryController(IRepository<Category, int> catRepository)
        {
            
            this.catRepository = catRepository;
        }
        public IActionResult Index()
        {
            var cats = catRepository.Get();
            return View(cats);
        }
        // default HttpGet
        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (category.BasePrice < 0)
                        throw new Exception("Base Price Cannot be -Ve");
                    catRepository.Create(category);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(category);
                }
            }
            catch (Exception ex)
            {
                return View("Error",new ErrorViewModel() {
                     ControllerName=this.RouteData.Values["controller"].ToString(),
                     ActionName= this.RouteData.Values["action"].ToString(),
                     Exception = ex
                });
            }
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.Keys.Count() > 0)
            {
                var cat = HttpContext.Session.Get<Category>("CatData");
                HttpContext.Session.Remove("CatData");
                return View(cat);
            }
            else
            {
                var cat = catRepository.Get(id);
                return View(cat);
            }

        }

        [HttpPost]
        public IActionResult Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.BasePrice < 0)
                {
                    HttpContext.Session.Set<Category>("CatData", category);
                    throw new Exception("Base Price cannot be -Ve");
                }
                   
                catRepository.Update(id, category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Details(int id)
        {
         //  TempData["CatRowId"] = id;
             var data = new byte[] { (byte)id };
          HttpContext.Session.Set("CatRowId",data);
        
            return RedirectToAction("Index","Product");
        }
    }
}