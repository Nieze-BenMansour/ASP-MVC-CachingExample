namespace CachingExample.Controllers;

public class ProductController(IProductRepository _repository, IMemoryCache _memoryCache)
    : Controller
{
    public IActionResult Index(int? id)
    {
        IEnumerable<Product>? products = null;
        var isProductsExistInCache = _memoryCache.TryGetValue("products", out products);

        if (!isProductsExistInCache)
        {
            products = _repository.GetProducts();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(15));

            _memoryCache.Set("products", products, cacheEntryOptions);
        }

        ViewBag.SelectedProductId = id;

        return View(products);
    }

    public IActionResult GetImage(string name)
    {
        return File($@"images\{name}.png", "image/png");
    }
}