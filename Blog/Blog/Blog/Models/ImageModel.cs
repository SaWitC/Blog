using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Blog.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string ImageName { get; set; }
        [NotMapped]
        [Display(Name ="Загрузить файл поддерживаемы форматы (jpg,jpeg)")]
        public IFormFile ImageFile { get; set; }
    }
}
