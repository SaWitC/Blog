using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Поле не может быть пустым")]
        //[DataType(DataType.EmailAddress)]
        [Display(Name = "Имя автора(Псевдоним)")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить ?")]
        public bool Rememberme { get; set; }
        public string ReturnUrl { get; set; }//
    }
}
