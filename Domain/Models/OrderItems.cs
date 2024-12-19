namespace Domain.Models;



public class OrderItem
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int MenuId { get; set; }
}