using Project_Overview;
using Project_Overview.Repositories;
using System;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        var bookRepo = new BookRepository();
        var memberRepo = new MemberRepository();
        var transactionRepo = new TransactionRepository();
        var libraryService = new LibraryService(bookRepo, memberRepo, transactionRepo);

        var userInputHandler = new UserInputHandler(libraryService);
        userInputHandler.ShowMenu();
    }
}
