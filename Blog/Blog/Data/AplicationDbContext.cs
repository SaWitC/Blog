using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Blog.Data
{
    public class AplicationDbContext : IdentityDbContext<User>
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ImageModel> Images{get;set;}
        public DbSet<ArticleModel> Blogs { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
