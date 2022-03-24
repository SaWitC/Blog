using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Category
    {     
        public int Id { get; set; }
        [Required]
        [Display(Name ="Название")]
        //[StringLength(20,ErrorMessage ="Название должно содержать от 2 до 20 символов"),MinLength(2)]
       
        public string Title { get; set; }
        
        [Display(Name = "Описание")]
        [StringLength(200, ErrorMessage = "Описание должно содержать от 20 до 200 символов"), MinLength(20)]
        public string Description { get; set; }

        //IsFavorit
    }
}
