using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels.AccountVM
{
    public class ChangePasswordNonAuthoriseGetEmail
    {
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Введенные данные не являются Email адресом")]
        [Required(ErrorMessage ="поле должно быть заполнено")]
        public string Email { get; set; }
    }
}
