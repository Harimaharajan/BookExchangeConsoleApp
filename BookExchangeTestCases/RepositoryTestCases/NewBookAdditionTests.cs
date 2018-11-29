using System.ComponentModel.DataAnnotations;
using AutoFixture;
using BookExchangeConsoleApp;
using BookExchangeConsoleApp.Models;
using BookExchangeConsoleApp.Repositories;
using BookExchangeConsoleApp.Repositories.Interfaces;
using Unity;
using Xunit;

namespace BookExchangeTestCases
{
    public class NewBookAdditionTests
    {
        private IUnityContainer Initialize()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            return container;
        }

        [Fact]
        public void AddNewBook_IsBookNameEmptyTest_ReturnsValidationException()
        {
            IUnityContainer container = Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            var expectedException = new ValidationException(Constants.InvalidBookName);
            var fixture = new Fixture();
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.BookName, string.Empty).Create();
            var actualException = Assert.Throws<ValidationException>(() => bookRepository.AddNewBook(bookModel));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public void AddNewBook_IsBookOwnerNameEmptyTest_ReturnsValidationException()
        {
            IUnityContainer container = Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            var expectedException = new ValidationException(Constants.InvalidBookOwnerName);
            var fixture = new Fixture();
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.OwnerName, string.Empty).Create();
            var actualException = Assert.Throws<ValidationException>(() => bookRepository.AddNewBook(bookModel));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public void AddNewBook_IsBookAlreadyExistsTest_ReturnsTrue()
        {
            IUnityContainer container = Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            var fixture = new Fixture();
            BookModel bookModel1 = fixture.Build<BookModel>().With(x => x.BookName, "C#").With(x => x.OwnerName, "Mark").Create();
            bookRepository.AddNewBook(bookModel1);
            
            BookModel bookModel2 = fixture.Build<BookModel>().With(x => x.BookName, "C#").With(x => x.OwnerName, "Mark").Create();
            var expectedException = new ValidationException(Constants.InvalidBookAlreadyExists);
            var actualException = Assert.Throws<ValidationException>(() => bookRepository.AddNewBook(bookModel2));

            Assert.Equal(expectedException.Message, actualException.Message);
        }

        [Fact]
        public void AddNewBook_BookAdditionSuccessTest_ReturnsSuccessMessage()
        {
            IUnityContainer container = Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            var fixture = new Fixture();
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.OwnerName, "Mark").Create();
            int expectedID = bookModel.ID;

            Assert.Equal(expectedID, bookRepository.AddNewBook(bookModel));
        }

        [Fact]
        public void AddNewBook_IsValidBookModelTest_ReturnsValidationString()
        {
            IUnityContainer container = Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            BookModel bookModel = null;
            var expectedException = new ValidationException(Constants.InvalidBookDetails);
            var actualException = Assert.Throws<ValidationException>(() => bookRepository.AddNewBook(bookModel));

            Assert.Equal(expectedException.Message,actualException.Message);
        }

        [Fact]
        public void AddNewBook_IsBookAvailableTest_ReturnsValidationString()
        {
            IUnityContainer container = Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            var fixture = new Fixture();
            bool expectedResult = true;
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.AvailabilityStatus, true).Create();

            Assert.Equal(expectedResult, bookRepository.IsBookAvailable(bookModel));
        }

        [Fact]
        public void AddNewBook_IsBookInAvailableTest_ReturnsValidationString()
        {
            IUnityContainer container = Initialize();
            BookRepository bookRepository = container.Resolve<BookRepository>();
            var fixture = new Fixture();
            bool expectedResult = false;
            BookModel bookModel = fixture.Build<BookModel>().With(x => x.AvailabilityStatus, false).Create();

            Assert.Equal(expectedResult, bookRepository.IsBookAvailable(bookModel));
        }
    }
}
