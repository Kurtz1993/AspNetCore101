using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCraft.Website.Models;
using ContosoCraft.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCraft.Website.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Product> Products { get; private set; }

        private readonly JsonFileProductsService _productsService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(
            ILogger<IndexModel> logger,
            JsonFileProductsService productsService
        )
        {
            _productsService = productsService;
            _logger = logger;
        }

        public void OnGet()
        {
            Products = _productsService.GetProducts();
        }
    }
}
