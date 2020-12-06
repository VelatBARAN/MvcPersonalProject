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
    [Table("Services")]
    public class Services : MyEntityBase
    {
        [DisplayName("Hizmet Alanı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Title { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Text { get; set; }

        public virtual List<ProjectsDones> ProjectsDones { get; set; }
        public Services()
        {
            ProjectsDones = new List<ProjectsDones>();
        }
    }
}
