using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Blog.Models.Interfaces;


namespace Blog.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly Icategory _category;
        public CategoryController(Icategory icategory)
        {
            _category = icategory;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_category.AllCategories);
        }
        public IActionResult Create()
        {
            return View();
        }

        // post: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Title,Description")]Category model)
        {
            if (ModelState.IsValid)
            {//save
                _category.AddCategory(model);
                await _category.SaveDataAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult NoFound()
        {
            return View();

            
        }
    }
}
