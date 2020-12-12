using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPersonalProject.Entity
{
    [Table("Contact")]
    public class Contact : MyEntityBase
    {
        [DisplayName("Konum")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(200, ErrorMessage = "{0} alanı max {1} karakter olmalıdır.")]
        public string Location { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max {1} karakter olmalıdır."),
            DataType(DataType.EmailAddress,ErrorMessage ="Lütfen geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(11, ErrorMessage = "{0} alanı max {1} karakter olmalıdır.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Geçersiz telefon numarası")]
        public string Phone { get; set; }
    }
}
