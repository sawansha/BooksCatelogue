using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookApp.Models
{
    public class Book
    {
        private string _ISBN = string.Empty;
        public string ISBN
        {
            get { return _ISBN; }
            set
            {
                if (value != null)
                {
                    if (value.Length > 13)
                        _ISBN = value.Trim().Substring(0, 13).ToUpper();
                    else
                        _ISBN = value.Trim().ToUpper();
                }                
                else _ISBN = string.Empty;
            }
        }

        private string _Authors= string.Empty;
        public string Authors
        {
            get { return _Authors; }
            set
            {
                if (value != null)
                {
                    if (value.Length > 100)
                        _Authors = value.Substring(0, 100);
                    else
                        _Authors = value;
                }
                else _Authors = string.Empty;
            }
        }

        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set
            {
                if (value != null)
                {
                    if (value.Length > 30)
                        _Title = value.Substring(0, 30);
                    else
                        _Title = value;
                }
                else _Title = string.Empty;
            }
        }

        public DateTime PublicationDate { get; set; }
    }
}