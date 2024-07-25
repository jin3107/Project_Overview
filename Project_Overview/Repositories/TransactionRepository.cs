using Project_Overview.Classes;
using Project_Overview.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Overview.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void Add(Transaction transaction) => transactions.Add(transaction);
        public void Update(Transaction transaction)
        {
            var existing = GetById(transaction.Id);
            if (existing != null)
            {
                existing.ReturnDate = transaction.ReturnDate;
            }
        }
        public void Delete(Guid id) => transactions.RemoveAll(t => t.Id == id);
        public Transaction GetById(Guid id) => transactions.FirstOrDefault(t => t.Id == id);
        public List<Transaction> GetAll() => transactions;
        public List<Transaction> GetTransactionsByMember(Guid memberId) => transactions.Where(t => t.MemberId == memberId).ToList();
        public List<Transaction> GetTransactionsByBook(Guid bookId) => transactions.Where(t => t.BookId == bookId).ToList();
    }
}
