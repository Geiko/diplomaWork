using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookArt.Models
{
    public class Section
    {
        public int Id { get; set; }

        [DisplayName("Номер")]
        [Required(ErrorMessage = "Будь ласка, обов'язково заповніть це поле")]
        public int Number { get; set; }

        [DisplayName("Ім'я")]
        public string Title { get; set; }
        
        [DisplayName("URL малюнка")]
        [StringLength(300)]
        public string CoverUrl { get; set; }            
        
        public virtual ICollection<Work> Works { get; set; }

        public Section()
        {
            Works = new List<Work>();
        }
    }
}