using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Interfaces
{
    public interface IImageModel
    {
        ImageModel GetImageByName(string name);
        Task<ImageModel> GetImageByNameAsync(string name);

        Task<ImageModel> GetImageByIdAsync(int id);

        void Remove(ImageModel model);

    }
}
