namespace Backend.Models;

public class ProductVariant
{
    public int Id { get; set; } //unique identifier
    public int ProductId { get; set; } //product identifier, links to the main product
    public string Size { get; set; } = ""; //size of the product
    public int Quantity { get; set; } //quantity of the product
}