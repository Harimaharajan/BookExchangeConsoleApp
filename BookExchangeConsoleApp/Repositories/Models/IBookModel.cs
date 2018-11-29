namespace BookExchangeConsoleApp.Models
{
    public interface IBookModel
    {
        bool AvailabilityStatus { get; set; }
        string BookName { get; set; }
        int ID { get; set; }
        string OwnerName { get; set; }
    }
}