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
    public class ProductController : Controller
    {
        private readonly ProductStorer _productStorer;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductController(ProductStorer productStorer, IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productStorer = productStorer;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.All();

            if (products.Any())
            {
                var viewModel = products.Select(p => new ProductViewModel() { 
                    Id = p.Id, Name = p.Name, CategoryName = p.Category.Name
                });

                return View(viewModel);
            }

            //var productVm = products.Select(c => new ProductViewModel() {
                
            return View();
            
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {

            var productsViewModel = new ProductViewModel();
            var categories = _categoryRepository.All();
            if (categories.Any())
                productsViewModel.Categories = categories.Select(c => new CategoryViewModel(){ Id = c.Id, Name = c.Name });


            if(id > 0) {
                var product = _productRepository.getById(id);
                productsViewModel.Id = product.Id;
                productsViewModel.Name = product.Name;
                productsViewModel.CategoryId = product.Category.Id;
                productsViewModel.Price = product.Price;
                productsViewModel.StockQuantity = product.StockQuantity;
                return View(productsViewModel);
            }
            else
            {
                return View(productsViewModel);
            }
        }   

        [HttpPost]
        public IActionResult CreateOrEdit(ProductViewModel model)
        {
            _productStorer.Store(model.Id, model.Name, model.CategoryId, model.Price, model.StockQuantity);
            return RedirectToAction("Index");
        }   
       
    }
}