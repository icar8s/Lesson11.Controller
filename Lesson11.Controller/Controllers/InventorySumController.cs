using Microsoft.AspNetCore.Mvc;

[Route("api/summary")]
[ApiController]
public class InventorySummaryController : ControllerBase
{
    private List<Product> inventory = new List<Product>();

    [HttpGet("total")]
    public ActionResult<decimal> GetTotalInventoryValue()
    {
        decimal totalValue = inventory.Sum(product => product.Price * product.Quantity);
        return totalValue;
    }

    [HttpGet("byCategory/{categoryId}")]
    public ActionResult<decimal> GetTotalValueByCategory(int categoryId)
    {
        decimal totalValue = inventory.Where(product => product.CategoryId == categoryId)
                                      .Sum(product => product.Price * product.Quantity);
        return totalValue;
    }
}