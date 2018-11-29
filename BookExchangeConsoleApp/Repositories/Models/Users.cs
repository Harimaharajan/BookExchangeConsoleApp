using BookExchangeConsoleApp.Repositories.Interfaces;

namespace BookExchangeConsoleApp.Models
{
    public class Users
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
