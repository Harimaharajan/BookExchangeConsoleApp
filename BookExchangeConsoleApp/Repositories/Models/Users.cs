using BookExchangeConsoleApp.Repositories.Interfaces;

namespace BookExchangeConsoleApp.Models
{
    public class Users : IUsers
    {
        public Users(int id, string userName)
        {
            ID = id;
            OwnerName = userName;
        }

        public int ID { get; set; }

        public string OwnerName { get; set; }
    }
}
