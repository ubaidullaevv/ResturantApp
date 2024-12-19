namespace Domain.Models;


public class MenuItem
{
    public int MenuId { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? Category { get; set; }
}