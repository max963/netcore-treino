using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.Models;
using StoreOfBuild.Web.ViewModels;

namespace StoreOfBuild.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryStorer _categoryStorer;
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(CategoryStorer categoryStorer, IRepository<Category> categoryRepository)
        {
            _categoryStorer = categoryStorer;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepository.All();
            var categoryVm = categories.Select(c => new CategoryViewModel() { Id = c.Id, Name = c.Name });
            return View(categoryVm);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {
            if(id > 0) {
                var categories = _categoryRepository.getById(id);
                var categoryVm = new CategoryViewModel() { Id = categories.Id, Name = categories.Name };
                return View(categoryVm);
            }
            else
            {
                return View();
            }
        }   

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel model)
        {
            _categoryStorer.Store(model.Id, model.Name);
            return View();
        }   
       
    }
}