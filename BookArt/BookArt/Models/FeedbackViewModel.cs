using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookArt.Models
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }

        [DisplayName("Ваша єлектронна поштова скринька")]
        [Required(ErrorMessage = "Будь ласка, обов'язково заповніть це поле")]
        [EmailAddress(ErrorMessage = "Єлектронна поштова адреса введена не вірно")]
        [StringLength(80)]
        public string UsersEmail { get; set; }

        [DisplayName("Поле для заповнення")]
        [Required(ErrorMessage = "Будь ласка, обов'язково заповніть це поле")]
        [StringLength(5000)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string CaptchaResponse { get; set; }
    }
}