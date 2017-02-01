using System;

namespace BookArt.Models
{
    public class Feedback
    {
        private const int MAX_USER_EMAIL = 300;
        private const int MAX_CONTENT = 300;

        public int Id { get; set; }

        private string _usersEmail;
        private string _content;

        /// <summary>
        /// Gets or sets users email. 
        /// </summary>
        public string UsersEmail
        {
            get
            {
                return _usersEmail;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > MAX_USER_EMAIL)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format($"User email isn't valid - //{value}//"));
                }

                _usersEmail = value;
            }
        }

        /// <summary>
        /// Gets or sets feedback content.
        /// </summary>
        public string Content
        {
            get
            {
                return _content;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > MAX_CONTENT)
                {
                    throw new ArgumentException(
                        string.Format($"Feedback content isn't valid - //{value}//"));
                }

                _content = value;
            }
        }

        /// <summary>
        /// Gets or sets date of feedback.
        /// </summary>
        public DateTime Date { get; set; }
    }
}