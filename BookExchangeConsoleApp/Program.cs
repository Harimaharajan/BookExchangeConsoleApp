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

            IBookModel newBookDetails = bookRepository.CaptureNewBookData();

            int result = bookRepository.AddNewBook(newBookDetails);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
