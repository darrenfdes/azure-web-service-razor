using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using product.Models;
using product.Services;
namespace product.Pages;

public class IndexModel : PageModel
{
    private readonly IProductService productService;
    public List<Product> Products;
    public bool IsBeta;

    public IndexModel(IProductService productService)
    {
        this.productService = productService;
    }

    public void OnGet()
    {
        Products = productService.GetProducts();
        IsBeta = productService.IsBeta().Result;
    }
}
