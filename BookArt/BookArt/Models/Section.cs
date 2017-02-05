using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookArt.Models
{
    public class Section
    {
        public int Id { get; set; }


        public string Title { get; set; }
        public string CoverURL { get; set; }    
        

        public virtual ICollection<Work> Works { get; set; }
        
        public Section()
        {
            Works = new List<Work>();
        }
    }
}