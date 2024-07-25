using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Overview.Classes
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Transaction(Guid bookId, Guid memberId)
        {
            Id = Guid.NewGuid();
            BookId = bookId;
            MemberId = memberId;
            BorrowDate = DateTime.Now;
            ReturnDate = null;
        }
    }
}
