using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain.Dtos;
using StoreOfBuild.Web.Models;

namespace StoreOfBuild.Web.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateOrEdit()
        {
            return View();
        }   

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryDto dto)
        {
            return View();
        }   
       
    }
}