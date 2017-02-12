using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookArt.Models
{
    public class Work
    {
        public int Id { get; set; }

        public int SectionId { get; set; }


        public int Number { get; set; }
        public string Name { get; set; }
        public string CoverUrl { get; set; }


        public virtual ICollection<Page> Pages { get; set; }

        public Work()
        {
            Pages = new List<Page>();
        }
    }
}