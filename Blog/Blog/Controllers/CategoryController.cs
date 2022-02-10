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

namespace Blog.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly AplicationDbContext _context;

        public CategoryController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            var x = _context.categories;
            return View(await x.ToListAsync());
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
                _context.Add(model);
                await _context.SaveChangesAsync();
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
