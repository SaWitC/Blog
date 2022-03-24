using Blog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class indexArticleViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        [StringLength(100, ErrorMessage = "Название должно содержать минимум 3 символа"), MinLength(3)]
        public string Title { get; set; }
        public string BlogName { get; set; }

        [Display(Name = "Краткое описание")]
        [MaxLength(400, ErrorMessage = "краткое описание должно быть не больше 400 символов")]
        public string ShortDesk { get; set; }

        [Required]
        [Display(Name = "Дата последнего обновления")]
        public DateTime ReleseDate { get; set; }
        public string ImageURL { get; set; }

        [Display(Name = "Картинка болга")]
        public ImageModel HelloImage { get; set; }

        [Display(Name = "Категория")]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Display(Name = "Категория")]
        public int? CategoryId { get; set; }
        [Display(Name = "Теги")]
        [StringLength(100, ErrorMessage = "теги должны состоять не больше чем из 100 символов")]


        public string Tags { get; set; }
        public bool IsFavorit { get; set; } = false;
        [Display(Name = "Автор_")]
        public User Avtor { get; set; }
        //[Required]
        [Display(Name = "Автор")]
        public string AvtorName { get; set; }
    }
}
