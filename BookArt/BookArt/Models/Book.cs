using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookArt.Models
{
    public class Book
    {
        public int Id { get; set; }

        private const int MAX_DESCRIPTION_LENGHT = 5000;
        private const int MAX_COVER_URL_LENGHT = 300;

        private string _description;        
        private string _coverURL;

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > MAX_DESCRIPTION_LENGHT)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format($"Book description isn't valid - \"{_description}\""));
                }

                this._description = value;
            }
        }
        

        public string CoverURL
        {
            get
            {
                return _coverURL;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > MAX_COVER_URL_LENGHT)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format($"Cover URL isn't valid - \"{_coverURL}\""));
                }

                this._coverURL = value;
            }
        }



        public IList<string> PageURLs { get; set; }
    }
}