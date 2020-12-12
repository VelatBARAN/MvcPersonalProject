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
    public class MyEntityBase
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Kayıt Tarihi"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Güncelleme Tarihi"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public DateTime ModifiedOn { get; set; }
    }
}
