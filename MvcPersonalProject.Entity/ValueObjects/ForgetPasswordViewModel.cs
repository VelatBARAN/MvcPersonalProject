using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPersonalProject.Entity.ValueObjects
{
    public class ForgetPasswordViewModel
    {
        [DisplayName("EMail"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır"),
DataType(DataType.EmailAddress, ErrorMessage = "Lütfen geçerli formatta bir email adresi giriniz")]
        public string Email { get; set; }
    }
}
