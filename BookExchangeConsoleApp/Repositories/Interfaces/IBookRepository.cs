using BookExchangeConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchangeConsoleApp.Repositories.Interfaces
{
    public interface IBookRepository
    {
        List<IBookModel> BookList {get; set;}
        IBookModel CaptureNewBookData();
        bool IsBookAvailable(IBookModel bookModel);
        int AddNewBook(IBookModel bookModel);
    }
}
