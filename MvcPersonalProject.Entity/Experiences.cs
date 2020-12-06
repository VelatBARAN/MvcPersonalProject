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
    [Table("Experiences")]
    public class Experiences : MyEntityBase
    {
        [DisplayName("Kurum/Şirket")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Institution { get; set; }

        [DisplayName("Birim")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Department { get; set; }

        [DisplayName("Çalışma Süresi")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Time { get; set; }

        public bool IsActive { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Text { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string City { get; set; }
    }
}
