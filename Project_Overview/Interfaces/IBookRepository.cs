using Project_Overview.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Overview.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        List<Book> GetAvailableBooks();
    }
}
