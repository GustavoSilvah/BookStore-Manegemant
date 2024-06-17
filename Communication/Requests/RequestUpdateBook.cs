using BookstoreManagemant.Enums;

namespace BookstoreManagemant.Communication.Requests;

public class RequestUpdateBook
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public EBookType BookType { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
