using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookArt.Areas.Admin.Models
{
    public class AboutViewModel
    {
        [AllowHtml]
        [StringLength(5000)]
        public string AboutContent { get; set; }

        public string Result { get; set; }
    }
}