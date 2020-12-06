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
    [Table("About")]
    public class About : MyEntityBase
    {
        [DisplayName("Metin")]
        [Required(ErrorMessage ="{0} alanı boş geçilemez."),StringLength(2000,ErrorMessage ="{0} alanı max {1} karakter olmalıdır.")]
        public string Text { get; set; }

        [DisplayName("Resim"), Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string Image { get; set; }
    }
}
