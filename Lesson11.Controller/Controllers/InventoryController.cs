
using Microsoft.AspNetCore.Mvc;

[Route("api/inventory")]
[ApiController]
public class InventoryController : ControllerBase
{
    private List<Product> inventory = new List<Product>();

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return inventory;
    }

    [HttpPost]
    public ActionResult<Product> AddProduct(Product product)
    {
        inventory.Add(product);
        return product;
    }

    [HttpPut("{id}")]
    public ActionResult<Product> UpdateProduct(int id, Product updatedProduct)
    {
        var existingProduct = inventory.FirstOrDefault(p => p.Id == id);

        if (existingProduct == null)
        {
            return NotFound();
        }

        existingProduct.Name = updatedProduct.Name;
        existingProduct.Price = updatedProduct.Price;
        existingProduct.Quantity = updatedProduct.Quantity;

        return existingProduct;
    }
}