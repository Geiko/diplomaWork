using BookArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookArt.Areas.Admin.Models
{
    public class PageViewModel
    {
        public Page Page { get; set; }
        public List<Page> Pages { get; set; }
        public SelectList Sections { get; set; }
        public SelectList Works { get; set; }
        public string WorkName { get; set; }
    }
}