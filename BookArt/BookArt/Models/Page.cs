using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookArt.Models
{
    public class Page
    {
        public int Id { get; set; }

        public int WorkId { get; set; }


        public int Number { get; set; }
        public string CoverUrl { get; set; }
    }
}