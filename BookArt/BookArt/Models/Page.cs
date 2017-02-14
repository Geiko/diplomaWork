using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookArt.Models
{
    public class Page
    {
        public int Id { get; set; }

        [DisplayName( "Id роботи" )]
        [Required(ErrorMessage = "Будь ласка, обов'язково заповніть це поле")]
        public int WorkId { get; set; }

        [DisplayName("Номер")]
        [Required(ErrorMessage = "Будь ласка, обов'язково заповніть це поле")]
        public int Number { get; set; }

        [DisplayName("URL малюнка")]
        [StringLength(300)]
        public string ImgUrl { get; set; }
    }
}