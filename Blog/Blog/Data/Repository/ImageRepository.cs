using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repository
{
    public class ImageRepository : IImageModel
    {
        private readonly AplicationDbContext _context;
        public ImageRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ImageModel> GetImageByIdAsync(int id)
        {
            return await _context.Images.FirstOrDefaultAsync(o => o.Id == id);
        }

        public ImageModel GetImageByName(string name)
        {
            return _context.Images.FirstOrDefault(o => o.ImageName == name);
        }

        public async Task<ImageModel> GetImageByNameAsync(string name)
        {
            return await _context.Images.FirstOrDefaultAsync(o => o.ImageName == name);
        }

        public void Remove(ImageModel model)
        {
            _context.Images.Remove(model);
        }
    }
}
