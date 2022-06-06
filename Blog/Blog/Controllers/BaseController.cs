using Blog.Models;
using Blog.Models.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Controllers
{
    public abstract class BaseController<T>:Controller
    {
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;

        protected readonly IWebHostEnvironment _hostEnvironment;

        protected readonly IArticle _article;
        protected readonly Icategory _category;
        protected readonly IImageModel _image;
        protected readonly IUser _userRepository;
        protected readonly ICommentRepository _comment;
        protected readonly ILogger<T> _logger;

        private protected BaseController(IArticle article = null,
            Icategory category = null,
            IImageModel imageModel = null,
            IUser userrepo = null,
            ICommentRepository commentRepo=null,
            UserManager<User> userManager=null,
            SignInManager<User> signInManager=null,
            ILogger<T> logger=null,
            IWebHostEnvironment hostEnvironment=null
            
        )
        {
            _hostEnvironment = hostEnvironment;
            _article = article;
            _category = category;
            _userRepository = userrepo;
            _comment = commentRepo;

            _signInManager = signInManager;
            _userManager = userManager;

            _logger = logger;
        }
    }
}
