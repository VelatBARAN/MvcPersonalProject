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
    [Table("ProjectDones")]
    public class ProjectsDones : MyEntityBase
    {
        [DisplayName("Proje Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır")]
        public string ProjectName { get; set; }

        [DisplayName("Hizmet"), Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public int ServicesId { get; set; }

        [DisplayName("Resim-1"), Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string Image1 { get; set; }
        [DisplayName("Resim-2"), Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string Image2 { get; set; }
        [DisplayName("Resim-3"), Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string Image3 { get; set; }

        [DisplayName("Teknolojiler"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(200, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır")]
        public string Teknologies { get; set; }

        [DisplayName("Müşteri"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır")]
        public string Customer { get; set; }

        [DisplayName("Açıklama"), StringLength(250, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır")]
        public string Description { get; set; }

        [DisplayName("Proje Tarihi"), Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public DateTime ProjectDoneDate { get; set; }

        public virtual Services Services { get; set; }
    }
}
