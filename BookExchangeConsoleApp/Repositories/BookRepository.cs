using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookExchangeConsoleApp.Models;
using BookExchangeConsoleApp.Repositories.Interfaces;

namespace BookExchangeConsoleApp.Repositories
{
    public sealed class BookRepository : IBookRepository
    {
        private readonly IUserRepository _userRepository;

        public BookRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<IBookModel> BookList { get; set; } = new List<IBookModel>();

        private bool ValidateNewBookModel(IBookModel bookModel)
        {
            if (bookModel == null)
            {
                throw new ValidationException(Constants.InvalidBookDetails);
            }
            if (string.IsNullOrEmpty(bookModel.BookName))
            {
                throw new ValidationException(Constants.InvalidBookName);
            }
            if (string.IsNullOrEmpty(bookModel.OwnerName))
            {
                throw new ValidationException(Constants.InvalidBookOwnerName);
            }
            if(!_userRepository.IsBookOwnerExistsAlready(bookModel.OwnerName))
            {
                throw new ValidationException(Constants.BookOwnerNotRegistered);
            }
            else
            {
                if (BookList.Count > 0)
                {
                    var bookAlreadyExists = BookList.Where(n => n.BookName == bookModel.BookName);

                    if (bookAlreadyExists != null)
                    {
                        throw new ValidationException(Constants.InvalidBookAlreadyExists);
                    }
                }
            }

            return true;
        }

        public IBookModel CaptureNewBookData()
        {
            IBookModel newBookdetails = new BookModel();

            Console.WriteLine("Please Enter Book name");
            newBookdetails.BookName = Console.ReadLine();

            Console.WriteLine("Please Enter Book Owner name");
            newBookdetails.OwnerName = Console.ReadLine();
            newBookdetails.AvailabilityStatus = false;

            return newBookdetails;
        }

        public bool IsBookAvailable(IBookModel bookModel)
        {
            return bookModel.AvailabilityStatus;
        }

        public int AddNewBook(IBookModel bookModel)
        {
            if (ValidateNewBookModel(bookModel))
            {
                if (bookModel.ID == 0)
                {
                    bookModel.ID = BookList.Count + 1;
                }
                
                BookList.Add(bookModel);
                return bookModel.ID;
            }

            return 0;
        }
    }
}
