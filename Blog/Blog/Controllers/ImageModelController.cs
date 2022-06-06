using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class ImageModelController : BaseController<ImageModelController>
    {
        private readonly AplicationDbContext _context;

        public ImageModelController(AplicationDbContext context,
            IWebHostEnvironment hostEnvironment) : base(null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            hostEnvironment)
        {
            _context = context;
        }
        // GET: ImageModelController
        public async Task<ActionResult> Index()
        {
            var item = from m in _context.Images select m;
            return View(await item.ToListAsync());
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // GET: ImageModelController/Create
        [HttpPost]//mothod for testimg
        public async Task<ActionResult> Create([Bind("Id,Title,ImageFile")]ImageModel model)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);//имя файла
                string extenshion = Path.GetExtension(model.ImageFile.FileName);//расширение
                model.ImageName = fileName + DateTime.Now.ToString("ssmmhhdd")+extenshion;
                string path = Path.Combine(wwwRootPath + "/Image"+ $"/{User.Identity.Name}/"+model.ImageName);

                using (var filestrem = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(filestrem);
                }
                _context.Add(model);
                await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            return View() ;
        }
    }
}
