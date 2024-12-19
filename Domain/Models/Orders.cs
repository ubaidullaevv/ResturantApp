namespace Domain.Models;



public class Order
{
    public int OrdrId { get; set; }
    public int CustomerId { get; set; }
    public int TableId { get; set; }
    public string? Status { get; set; }
}