using System.ComponentModel.DataAnnotations;
using BookExchangeConsoleApp;
using BookExchangeConsoleApp.Repositories;
using BookExchangeConsoleApp.Repositories.Interfaces;
using Unity;
using Xunit;

namespace BookExchangeTestCases
{
    public class UserRepositoryTests
    {
        private IUnityContainer Initialize()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();
            return container;
        }

        [Fact]
        public void ValidateBookOwner_IsBookOwnerExistsAlready_ReturnsTrue()
        {
            IUnityContainer container = Initialize();
            UserRepository userRepository = container.Resolve<UserRepository>();
            string ownerName = "Mark";

            Assert.True(userRepository.IsBookOwnerExistsAlready(ownerName));
        }

        [Fact]
        public void ValidateBookOwner_IfBookOwnerDoesNotExistsTest_ReturnsValidationException()
        {
            IUnityContainer container = Initialize();
            UserRepository userRepository = container.Resolve<UserRepository>();
            string ownerName = "Henry";
            var expectedException = new ValidationException(Constants.BookOwnerNotRegistered);
            var actualException = Assert.Throws<ValidationException>(() => userRepository.IsBookOwnerExistsAlready(ownerName));

            Assert.Equal(expectedException.Message, actualException.Message);
        }
    }
}
