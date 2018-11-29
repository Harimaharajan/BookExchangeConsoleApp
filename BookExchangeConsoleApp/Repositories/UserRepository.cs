using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookExchangeConsoleApp.Models;
using BookExchangeConsoleApp.Repositories.Interfaces;

namespace BookExchangeConsoleApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<Users> Users { get; set; } = new List<Users>();

        public UserRepository()
        {
            Users user1 = new Users(1, "Mark");
            Users user2 = new Users(2, "John");
            Users user3 = new Users(3, "Emma");
            Users.Add(user1);
            Users.Add(user2);
            Users.Add(user3);
        }

        public bool IsBookOwnerExistsAlready(string ownerName)
        {
            var user = Users.Where(p => p.OwnerName == ownerName).ToList();

            if (user.Count > 0)
            {
                return true;
            }
            else
            {
                throw new ValidationException(Constants.BookOwnerNotRegistered);
            }
        }
    }
}
