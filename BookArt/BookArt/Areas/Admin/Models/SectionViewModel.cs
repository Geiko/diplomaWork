using BookArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookArt.Areas.Admin.Models
{
    public class SectionViewModel
    {
        public Section Section { get; set; }
        public SelectList Works { get; set; }
    }
}