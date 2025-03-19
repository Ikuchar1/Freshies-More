using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products
            .Include(p => p.Variants) // ✅ Ensures size variants are loaded
            .ToListAsync();
    }

    // GET: api/products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    //Post: api/products
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    // Delete: api/products/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound(); // Returns 404 if the product doesn't exist
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent(); // Returns 204 when successfully deleted
    }   

    // PUT: api/products/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
    {
        var existingProduct = await _context.Products.FindAsync(id);

        if (exitstingProduct == null)
        {
            return NotFound();
        }

        existingProduct.Name = updatedProduct.Name;
        existingProduct.Price = updatedProduct.Price;
        existingProduct.Description = updatedProduct.Description;
        existingProduct.ImageUrl = updatedProduct.ImageUrl;
        existingProduct.Quantity = updatedProduct.Quantity;
        existingProduct.HasSizes = updatedProduct.HasSizes;

        if (updatedProduct.HasSizes)
        {
            _context.ProductVariants.RemoveRange(_context.ProductVariants.Where(pv => pv.ProductId == id));

            if (updatedProduct.Variants != null)
            {
                foreach (var variant in updatedProduct.Variants)
                {
                    _context.ProductVariants.Add(new ProductVariant
                    {
                        ProductId = id,
                        Size = variant.Size,
                        Quantity = variant.Quantity
                    });
                }
            }
        }

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Patch: /api/product/{id}/quantity
    [HttpPatch("{id}/quantity")]
    public async Task<IActionResult> UpdateProductQuantity(int id, int quantity)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null){
            return NotFound();
        }

        product.Quantity = quantity;
        await _context.SaveChangesAsync();
        return NoContent();
    }



}