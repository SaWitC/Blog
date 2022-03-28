using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels.AccountVM
{
    public class ChangePasswordNonAuthorise
    {
        [Required(ErrorMessage = "поле не может быть пустым")]
        [Display(Name = "Новый пароль")]
        [DataType(DataType.Password)]
        [MinLength(7, ErrorMessage = "Пароль должен содержать минимум 7 символов"), MaxLength(25)]
        public string NewPass { get; set; }
        [Required(ErrorMessage = "поле не может быть пустым")]
        [Compare("NewPass", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверите пароль")]
        [MinLength(7, ErrorMessage = "Пароль должен содержать минимум 7 символов"), MaxLength(25)]
        public string NewPassConfirm { get; set; }

        public string userId { get; set; }
    }
}
