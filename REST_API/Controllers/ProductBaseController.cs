using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Business.REST_API;
using System.Threading.Tasks;
using ViewModels.REST_API;
using Models.REST_API;
using System.Reflection;
using Entity = Entities.REST_API;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace REST_API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/{controller}")]
    public class ProductBaseController<T> : ControllerBase where T : Product
    {
        private readonly ILogger<ProductBaseController<T>> _logger;
        private readonly IProductBusiness _productBL;

        public ProductBaseController(IProductBusiness productBL,
            ILogger<ProductBaseController<T>> logger)
        {

            _productBL = productBL;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ProductsResponse>> Get()
        {
            //Create logs here
            var result = await _productBL.GetProducts();
            //Check if result does not return any products then instead of Ok, return Not Found
            return Ok(result);

            //return NotFound()
        }

        [HttpGet("GetById/{id}")]
        public virtual async Task<ActionResult<ProductResponse>> GetById(int id)
        {

            //Create logs here
            var result = await _productBL.GetProductById<T>(id);
            //Check if result does not return any products then instead of Ok, return Not Found
            return Ok(result);

            //return NotFound()
        }

        [HttpPost]
        public virtual async Task<ActionResult<ProductResponse>> Post(T model)
        {
            //Create logs here
            var result = await _productBL.AddProduct<T>(model);
            //Check if result does not return any products then instead of Ok, return Not Found
            return Ok(result);
        }
    }

    public class ProductController : ProductBaseController<Product>
    {
        private readonly ILogger<ProductBaseController<Product>> _logger;
        private readonly IProductBusiness _productBL;

        public ProductController(IEnumerable<IProductBusiness> productBL,
            ILogger<ProductBaseController<Product>> logger)
            : base(productBL.First(o => o.GetType() == typeof(ProductBusiness)), logger)
        {
            _productBL = productBL.First(o => o.GetType() == typeof(ProductBusiness));
            _logger = logger;
        }
    }

    public class DesktopController : ProductBaseController<ProductDesktop>
    {
        private readonly ILogger<ProductBaseController<ProductDesktop>> _logger;
        private readonly IProductBusiness _productBL;

        public DesktopController(IEnumerable<IProductBusiness>  productBL,
            ILogger<ProductBaseController<ProductDesktop>> logger)
            : base(productBL.First(o => o.GetType() == typeof(DesktopProductBusiness)), logger)
        {
            //var dependencyArray = productBL.GetEnumerator().
            //IEnumerable<IProductBusiness> productBL
            //var services = serviceProvider.GetServices<IProductBusiness>();
            _productBL = productBL.First(o => o.GetType() == typeof(DesktopProductBusiness));
            _logger = logger;
        }
    }

    public class LaptopController : ProductBaseController<ProductLaptop>
    {
        private readonly ILogger<ProductBaseController<ProductLaptop>> _logger;
        private readonly IProductBusiness _productBL;

        public LaptopController(IEnumerable<IProductBusiness> productBL,
            ILogger<ProductBaseController<ProductLaptop>> logger)
            : base(productBL.First(o => o.GetType() == typeof(LaptopProductBusiness)), logger)
        {
            _productBL =  productBL.First(o => o.GetType() == typeof(LaptopProductBusiness));
            _logger = logger;
        }
   }
}
