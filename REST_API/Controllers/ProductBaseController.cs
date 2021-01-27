using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Business.REST_API;
using System.Threading.Tasks;
using ViewModels.REST_API;
using Models.REST_API;
using System.Reflection;
using Entity = Entities.REST_API;

namespace REST_API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/{controller}")]
    public class ProductBaseController<T, S> : ControllerBase where T : Product where S : class
    {
        private readonly ILogger<ProductBaseController<T, S>> _logger;
        private readonly IProductBusiness<T, S> _productBL;

        public ProductBaseController(IProductBusiness<T, S> productBL,
            ILogger<ProductBaseController<T, S>> logger)
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
        public virtual async Task<ActionResult<ProductsResponse>> GetById(int id)
        {

            //Create logs here
            var result = await _productBL.GetProductById(id);
            //Check if result does not return any products then instead of Ok, return Not Found
            return Ok(result);

            //return NotFound()
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post(T model)
        {
            //Create logs here
            var result = await _productBL.AddProduct(model);
            //Check if result does not return any products then instead of Ok, return Not Found
            return Ok(result);
        }
    }

    public class ProductController : ProductBaseController<Product, Entity.Product>
    {
        private readonly ILogger<ProductBaseController<Product, Entity.Product>> _logger;
        private readonly IProductBusiness<Product, Entity.Product> _productBL;

        public ProductController(IProductBusiness<Product, Entity.Product> productBL,
            ILogger<ProductBaseController<Product, Entity.Product>> logger)
            : base(productBL, logger)
        {
            _productBL = productBL;
            _logger = logger;
        }
    }

    public class DesktopController : ProductBaseController<ProductDesktop, Entity.ProductDesktop>
    {
        private readonly ILogger<ProductBaseController<ProductDesktop, Entity.ProductDesktop>> _logger;
        private readonly IProductBusiness<ProductDesktop, Entity.ProductDesktop> _productBL;

        public DesktopController(DesktopProductBusiness<ProductDesktop, Entity.ProductDesktop> productBL,
            ILogger<ProductBaseController<ProductDesktop, Entity.ProductDesktop>> logger)
            : base(productBL, logger)
        {
            _productBL = productBL;
            _logger = logger;
        }

        [HttpGet("GetById/{id}")]
        public override async Task<ActionResult<ProductsResponse>> GetById(int id)
        {

            //Create logs here
            var result = await _productBL.GetProductById(id);
            //Check if result does not return any products then instead of Ok, return Not Found
            return Ok(result);

            //return NotFound()
        }
    }

    public class LaptopController : ProductBaseController<ProductLaptop, Entity.ProductLaptop>
    {
        private readonly ILogger<ProductBaseController<ProductLaptop, Entity.ProductLaptop>> _logger;
        private readonly IProductBusiness<ProductLaptop, Entity.ProductLaptop> _productBL;

        public LaptopController(IProductBusiness<ProductLaptop, Entity.ProductLaptop> productBL,
            ILogger<ProductBaseController<ProductLaptop, Entity.ProductLaptop>> logger)
            : base(productBL, logger)
        {
            _productBL = productBL;
            _logger = logger;
        }
    }
}
