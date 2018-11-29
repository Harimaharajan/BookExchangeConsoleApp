namespace BookExchangeConsoleApp.Models
{
    public class BookModel : IBookModel
    {
        public int ID
        {
            get;
            set;
        }

        public string BookName
        {
            get;
            set;
        }

        public string OwnerName
        {
            get;
            set;
        }

        public bool AvailabilityStatus
        {
            get;
            set;
        }
    }
}
