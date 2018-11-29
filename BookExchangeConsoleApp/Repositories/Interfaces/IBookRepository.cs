using BookExchangeConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchangeConsoleApp.Repositories.Interfaces
{
    public interface IBookRepository
    {
        List<BookModel> BookList {get; set;}
        bool IsBookAvailable(BookModel bookModel);
        int AddNewBook(BookModel bookModel);
    }
}
