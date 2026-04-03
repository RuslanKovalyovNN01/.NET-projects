using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Model;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Products = GenerateProducts(10);
            Message = "I'am using Razor Syntax";
        }

        public void OnPost(int quantity)
        {
            Products = GenerateProducts(quantity);
        }

        public void OnGetDefineColor(int id)
        {
            Color = id == 1 ? "#FF0000" : "green";
        }

        public void OnGet()
        {

        }

        public string Message { get; set; }
        public List<Product> Products { get; set; }
        public string Color { get; set; }
        private List<Product> GenerateProducts(int quantity)
        {
            var random = new Random();
            var products = Enumerable.Range(1, quantity).Select(i => new Product
            {
                Id = i,
                Name = "Product {i}",
                Price = (decimal)(random.NextDouble() * 100.0)
            }).ToList();
            return products;
        }
    }
}
