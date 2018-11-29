using System;
using BookExchangeConsoleApp.Models;
using BookExchangeConsoleApp.Repositories;
using BookExchangeConsoleApp.Repositories.Interfaces;
using Unity;

namespace BookExchangeConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterSingleton<IBookRepository, BookRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            BookRepository bookRepository = container.Resolve<BookRepository>();

            Console.WriteLine("Book Exchange");
            BookModel newBook = new BookModel();
            string bookName, bookOwner;
            bool bookAvailability = false;

            Console.WriteLine("Please Enter Book name");
            bookName = Console.ReadLine();
            
            Console.WriteLine("Please Enter Book Owner name");
            bookOwner = Console.ReadLine();

            newBook.BookName = bookName;
            newBook.OwnerName = bookOwner;
            newBook.AvailabilityStatus = bookAvailability;
            
            int result = bookRepository.AddNewBook(newBook);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
