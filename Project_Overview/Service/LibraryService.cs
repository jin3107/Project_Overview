using Project_Overview.Classes;
using Project_Overview.Interfaces;
using Project_Overview.Repositories;

public class LibraryService
{
    private readonly IBookRepository bookRepository;
    private readonly IMemberRepository memberRepository;
    private readonly ITransactionRepository transactionRepository;

    public LibraryService(IBookRepository bookRepo, IMemberRepository memberRepo, ITransactionRepository transactionRepo)
    {
        bookRepository = bookRepo;
        memberRepository = memberRepo;
        transactionRepository = transactionRepo;
    }

    public void AddBook(string title, string author)
    {
        var book = new Book(title, author);
        bookRepository.Add(book);
    }

    public void AddMember(string name)
    {
        var member = new Member(name);
        memberRepository.Add(member);
    }

    public void BorrowBook(Guid bookId, Guid memberId)
    {
        var book = bookRepository.GetById(bookId);
        var member = memberRepository.GetById(memberId);

        if (book != null && member != null && !book.IsBorrowed)
        {
            book.IsBorrowed = true;
            member.BorrowedBooks.Add(bookId);

            var transaction = new Transaction(bookId, memberId);
            transactionRepository.Add(transaction);

            bookRepository.Update(book);
            memberRepository.Update(member);
        }
    }

    public void ReturnBook(Guid bookId, Guid memberId)
    {
        var book = bookRepository.GetById(bookId);
        var member = memberRepository.GetById(memberId);
        var transaction = transactionRepository.GetTransactionsByBook(bookId).FirstOrDefault(t => t.MemberId == memberId && t.ReturnDate == null);

        if (book != null && member != null && transaction != null)
        {
            book.IsBorrowed = false;
            member.BorrowedBooks.Remove(bookId);

            transaction.ReturnDate = DateTime.Now;
            transactionRepository.Update(transaction);

            bookRepository.Update(book);
            memberRepository.Update(member);
        }
    }

    public List<Book> GetAvailableBooks() => bookRepository.GetAvailableBooks();
    public List<Member> GetAllMembers() => memberRepository.GetAll();
    public List<Transaction> GetAllTransactions() => transactionRepository.GetAll();
    public void DeleteBook(Guid bookId)
    {
        bookRepository.Delete(bookId);
    }
    public void DeleteMember(Guid memberId)
    {
        memberRepository.Delete(memberId);
    }
    public void DeleteTransaction(Guid transactionId)
    {
        transactionRepository.Delete(transactionId);
    }
}
