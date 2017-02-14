using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookArt.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets users email. 
        /// </summary>
        [DisplayName("Ваша єлектронна поштова скринька")]
        [Required(ErrorMessage = "Будь ласка, обов'язково заповніть це поле")]
        //[EmailAddress(ErrorMessage = "Єлектронна поштова адреса введена не вірно")]
        [StringLength(80)]
        public string UsersEmail { get; set; }    

        /// <summary>
        /// Gets or sets feedback content.
        /// </summary>
        [DisplayName("Поле для заповнення")]
        [Required(ErrorMessage = "Будь ласка, обов'язково заповніть це поле")]
        [StringLength(5000)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets date of feedback.
        /// </summary>
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
    }
}