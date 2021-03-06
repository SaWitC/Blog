using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Blog.ViewModels;
using System.Text.RegularExpressions;
using Blog.Components;
using Blog.Models.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace Blog.Controllers
{
    //done: create Index MyBlog Error Delete Edit SmallWidth
    public class ArticleModelController :BaseController<ArticleModelController>
    {
        //readonly IWebHostEnvironment _hostEnvironment;
        //readonly ILogger<ArticleModelController> _logger;
        //readonly IArticle _article;
        //readonly Icategory _category;
        //readonly IImageModel _image;
        //readonly IUser _userManager;
        //readonly ICommentRepository _comment;

        //private readonly UserManager<User> _userManager;

        public ArticleModelController(IUser user,
            IWebHostEnvironment hostEnvironment,
            IArticle article,Icategory category,
            IImageModel imageModel,
            ILogger<ArticleModelController> logger,
            UserManager<User> userManager,
            ICommentRepository comment):base(article,category,imageModel,user,comment,userManager,null,logger,hostEnvironment)
        {

        }
        [Authorize]
        public async Task<IActionResult> MyBlogs(int page =1)
        {
            int pageSize = 10;
            IQueryable<ArticleModel> source = _article.GetArticleByAvtor(User.Identity.Name);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                ArticleModels = items
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Find(FindViewModel model)
        {
            //ViewBags
            ViewBag.CategoryList =_category.AllCategories; //categoryList
            ViewBag.CategoryListCount = _category.AllCategories.Count(); //categoryList

            var blogs = _article.GetAllBlogs();

            if ((model.SecondDate!=null&& model.FirstDate != null) && model.FirstDate < model.SecondDate)
            {
                ModelState.AddModelError("",model.SecondDate.ToString());
                ModelState.AddModelError("", model.FirstDate.ToString());

                blogs = blogs
                    .Where(o => o.ReleseDate < model.SecondDate)
                    .Where(o => o.ReleseDate > model.FirstDate);
                model.ArticleModels = await blogs.ToListAsync();
            }
            //tags
            if (!string.IsNullOrEmpty(model.TagsString))
            {
                string[] arr = model.TagsString.Split(",");
                foreach(var x in arr)
                {
                    blogs = blogs.Where(o => o.Tags.Contains(x));
                    model.ArticleModels = await blogs.ToListAsync();
                }
            }

            //category
            if (model.SelectedCategory!=null)
            {
                blogs = blogs.Where(o => o.CategoryId== model.SelectedCategory);
                model.ArticleModels = await blogs.ToListAsync();
            }

            //Title
            if (!string.IsNullOrEmpty(model.SearshString))
            {
                blogs = blogs.Where(o => o.Title.ToLower().Contains(model.SearshString.ToLower()));
                model.ArticleModels = await blogs.ToListAsync();
            }
            // model.ArticleModels = await blogs.ToListAsync();
            return View(model);
        }
        // GET: ArticleModel
        public async Task<IActionResult> Index(int page=1)
        {
            //viewBags
            ViewBag.CategoryList = _category.AllCategories; //categoryList
            ViewBag.CategoryListCount = _category.AllCategories.Count(); //categoryList

            //Page Settings and enter data
            int pageSize = 10 ;
            IQueryable<ArticleModel> source = _article.GetAllBlogs(); 
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                ArticleModels = items
            };
            return View(viewModel);
        }

        // GET: ArticleModel/Details/5
        public async Task<ActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ArticleDetailsVM model =new ArticleDetailsVM();
            model.Article=_article.GetBlogById(Id);
            model.Comments = await _comment.GetCommentsByArticleIdSkipAsync(model.Article.Id, 10, 0);

            if (model.Article != null)
            {
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: ArticleModel/Create
        [HttpGet]
        [Authorize]        
        public ActionResult Create(string width)
        {
            //ViewBags  
            ViewBag.response = width;

            //ViewBag.category = new SelectList(item, nameof(Category.Id), nameof(Category.Title));
            ViewBag.Category = _category.AllCategories;
            int Width;
            try
            {
                Width =Convert.ToInt32(width);
            }
            catch
            {
                _logger.LogError("Can not get with");
                return View();
            }

            if (Width < 600)
                return RedirectToAction(nameof(SmallWidth));
            return View();
        }

        // POST: ArticleModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create([Bind("Id,Tags,Description,ShortDesk,Title,HelloImage,AvtorName,CategoryId")]ArticleModel model)
        {
            //View Bags
            ViewBag.category = new SelectList(_category.AllCategories, nameof(Category.Id), nameof(Category.Title));  

            //Edit text  
            string text = model.Title;
            model.BlogName = WWWrootFile.NormaliseFileName(model.Title);
            try
            {
                //Set Values
                
                model.Avtor =await _userManager.FindByNameAsync(User.Identity.Name.ToString());
                model.AvtorName = User.Identity.Name;
                model.Category = await _category.GetCategoryByIdAsync(model.CategoryId);

                //Add Data
                if (ModelState.IsValid)
                {
                    //removeExtraSpase
                    model.ShortDesk = StringEdit.RemoveExtraSpase(model.ShortDesk);
                    model.Description = StringEdit.RemoveExtraSpase(model.Description);

                    string wwwRootPath = _hostEnvironment.WebRootPath;//get wwwrootpath

                    //create directory
                    string dictionaryPath = $"{model.BlogName}_{User.Identity.Name}";
                    DirectoryInfo dirInfo = new DirectoryInfo(wwwRootPath + "/Image");
                    if (!dirInfo.Exists)
                    {
                        dirInfo.Create();
                    }
                    dirInfo.CreateSubdirectory(dictionaryPath);
                    model.ReleseDate = DateTime.Now;

                    //save image
                    if (model.HelloImage != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(model.HelloImage.ImageFile.FileName);//имя файла
                        string extenshion = Path.GetExtension(model.HelloImage.ImageFile.FileName);//расширение
                        model.HelloImage.ImageName = fileName + DateTime.Now.ToString("ssmmhhdd") + extenshion;
                        string path = Path.Combine(wwwRootPath + "/Image" + $"/{model.BlogName}_{User.Identity.Name}/" + model.HelloImage.ImageName);

                        using (var filestrem = new FileStream(path, FileMode.Create))
                        {
                            await model.HelloImage.ImageFile.CopyToAsync(filestrem);
                        }
                    }

                    //save data
                    await _article.AddNewArticle(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //print error
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (var x in allErrors)
                    {
                        ModelState.AddModelError(string.Empty, x.ErrorMessage);
                    }
                    ModelState.AddModelError(string.Empty, ModelState.ErrorCount.ToString());
                    _logger.LogError("exception with creating article");

                }
                return View(model);
            }
            catch
            {
                ModelState.AddModelError("","Операция не может быть выполнена возможно вы использует не подходящую HTML разметку пожалусто проверьте корректность данных");
                return RedirectToAction("Error");
            }   
        }

        // GET: ArticleModel/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id,string width)
        {
            var item = _category.AllCategories;
            int Width;
            if (!string.IsNullOrEmpty(width)) HttpContext.Session.SetString("width", width);

            try
            {
                Width = Convert.ToInt32(HttpContext.Session.GetString("width"));
            }
            catch
            {
                _logger.LogError("Can not get with");
                return View();
            }
            if (Width < 600)
            {
                return RedirectToAction(nameof(SmallWidth));
            }
            //HttpContext.Session.SetString("width", width);
            //SessionExtensions.SetString("width",width);

            //viewBags
            ViewBag.Category = item;

            if (id == null)
            {
                return NotFound();
            }

            var oldModel = await _article.GetBlogByIdAsync(id);
            if (oldModel.HelloImage != null)
            {
                ViewBag.OldModelName = oldModel.HelloImage.ImageName;
            }     

            return View(oldModel);
        }

        // POST: ArticleModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit(int id,[Bind("Id,Tags,BlogName,Description,ShortDesk,Title,HelloImage,AvtorName,CategoryId")]ArticleModel model,string OldName)
        {
            var item = _category.AllCategories;

            //viewBags
            ViewBag.Category = item;     

            if (id != model.Id)
            {
                return NotFound();
            }

            string wwwRootPath = _hostEnvironment.WebRootPath;

            //set values
            model.Avtor = _userManager.FindByNameAsync(User.Identity.Name.ToString()).Result;
            model.AvtorName = User.Identity.Name;
            model.Category = await _category.GetCategoryByIdAsync(model.CategoryId);

            if (model.HelloImage != null)
            {      
                if (model.BlogName != "")
                {

                    //Save Image
                    string fileName = Path.GetFileNameWithoutExtension(model.HelloImage.ImageFile.FileName);//имя файла
                    string extenshion = Path.GetExtension(model.HelloImage.ImageFile.FileName);//расширение
                    model.HelloImage.ImageName = fileName + DateTime.Now.ToString("ssmmhhdd") + extenshion;
                    string path = Path.Combine(wwwRootPath + "/Image" + $"/{model.BlogName}_{User.Identity.Name}/" + model.HelloImage.ImageName);

                    using (var filestrem = new FileStream(path, FileMode.Create))
                    {
                        await model.HelloImage.ImageFile.CopyToAsync(filestrem);
                    }

                    //delete old image from db
                    var imgModel = await _image.GetImageByNameAsync(OldName);

                    //delete old image
                    FileInfo fi = new FileInfo($"{wwwRootPath}/Image/{model.BlogName}_{User.Identity.Name}/{OldName}");
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                }           
            }       
            if (ModelState.IsValid)
            {
                //removeExtraSpase
                model.ShortDesk = StringEdit.RemoveExtraSpase(model.ShortDesk);
                model.Description = StringEdit.RemoveExtraSpase(model.Description);

                //save data
                _article.UpdateModel(model);
                await _article.SaveDataAsync();
                return RedirectToAction(nameof(MyBlogs));
            }
            return View(model);
        }

        // GET: ArticleModel/Delete/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model =await _article.GetBlogByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: ArticleModel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)//edit
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            var model = _article.GetBlogById(id);
            var imageModel = await _image.GetImageByIdAsync(model.HelloImage.Id);

            //delete old Directory
            DirectoryInfo df = new DirectoryInfo($"{wwwRootPath}/Image/{model.BlogName}_{User.Identity.Name}");
            df.Delete(true);

            //save 
            _image.Remove(model.HelloImage);
            _article.Remove(model);
            await _article.SaveDataAsync();
            return RedirectToAction(nameof(MyBlogs));
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult SmallWidth()
        {
            return View();
        }
    }
}
