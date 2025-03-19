namespace Backend.Models;

public class Product
{
    public int Id { get; set; } //unique identifier
    public string Name { get; set; } = "";//name of the product
    public decimal Price { get; set; } //price of the product
    public string? Description { get; set; } //description of the product
    public string? ImageUrl { get; set; } //image of the product
    public int Quantity { get; set; } //quantity of the product
    public bool HasSizes { get; set; } //does the product have sizes
    public List<ProductVariant>? Variants { get; set; } //list of sizes of the product
}