using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using product.Models;
using product.Services;
namespace product.Pages;

public class IndexModel : PageModel
{
    private readonly ProductService productService;
    public List<Product> Products;

    public IndexModel()
    {
        productService = new ProductService();
    }

    public void OnGet()
    {
        Products = productService.GetProducts();
    }
}
