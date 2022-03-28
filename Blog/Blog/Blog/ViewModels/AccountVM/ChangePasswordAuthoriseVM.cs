using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.AccountVM
{
    public class ChangePasswordAuthoriseVM
    {
        public string name { get; set; }
        [Required(ErrorMessage ="поле не может быть пустым")]
        [Display(Name ="Старый пароль")]
        [MinLength(7,ErrorMessage ="пароль должен содержать от 7 символов"),MaxLength(25, ErrorMessage = "Максимальная длинна пароля 25 символов")]
        public string oldPass { get; set; }
        [Required(ErrorMessage = "поле не может быть пустым")]
        [Display(Name = "Новый пароль")]
        [DataType(DataType.Password)]
        [MinLength(7, ErrorMessage = "пароль должен содержать от 7 символов"), MaxLength(25, ErrorMessage = "Максимальная длинна пароля 25 символов")]
        public string NewPass { get; set; }
        [Required(ErrorMessage = "поле не может быть пустым")]
        [Compare("NewPass",ErrorMessage ="Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверите пароль")]
        [MinLength(7, ErrorMessage = "пароль должен содержать от 7 символов"), MaxLength(25,ErrorMessage ="Максимальная длинна пароля 25 символов")]
        public string NewPassConfirm { get; set; }

    }
}
