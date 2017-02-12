using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookArt.Models
{
    public class Section
    {
        public int Id { get; set; }

        public int Number { get; set; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }    
        
        
        public virtual ICollection<Work> Works { get; set; }

        public Section()
        {
            Works = new List<Work>();
        }
    }
}