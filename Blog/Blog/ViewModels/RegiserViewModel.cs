using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class RegiserViewModel
    {
        [Required]
        [Display(Name ="Электорнная почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Повторите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
        [Required]
        [Display(Name = "Имя Автора")]
        [StringLength(30,ErrorMessage ="Имя пользователя должно содержать от 2 до 30 символов"),MinLength(2)]
        public string UserName {get;set;}
    }
}
