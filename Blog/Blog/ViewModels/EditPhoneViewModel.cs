using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class EditPhoneViewModel
    {
        [DataType(DataType.PhoneNumber)]
        [MaxLength(17, ErrorMessage = "телефон не может быть длинее 17 символов."), MinLength(7, ErrorMessage = "слишком короткий номер")]
        [RegularExpression(@"/^\+?(\d{1,3})?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$/", ErrorMessage = "Не корректный номер")]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
