using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Overview.Classes
{
    public class Member
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<Guid> BorrowedBooks { get; set; }

        public Member(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            BorrowedBooks = new List<Guid>();
        }
    }
}
