using BookArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookArt.Areas.Admin.Models
{
    public class WorkViewModel
    {
        public Work Work { get; set; }
        public List<Work> Works { get; set; }
        public SelectList Sections { get; set; }
        public SelectList Pages { get; set; }
        public string SectionTitle { get; set; }
    }
}