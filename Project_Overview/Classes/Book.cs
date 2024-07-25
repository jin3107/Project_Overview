using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Overview.Classes
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public bool IsBorrowed { get; set; }

        public Book(string title, string author)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            IsBorrowed = false;
        }
    }
}
