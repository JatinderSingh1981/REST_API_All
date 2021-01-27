using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Business.REST_API;
using System.Threading.Tasks;
using ViewModels.REST_API;
using Common.REST_API;
using System.Collections.Generic;

namespace REST_API.Controllers
{
    /// <summary>
    /// The methods are not async methods because I am getting the values from the memory and not DB.
    /// If I have to fetch the values from DB, I will convert these to async Task methods.
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/{controller}")]
    public class EnumController : ControllerBase
    {
        private readonly ILogger<EnumController> _logger;
        private readonly IEnumBusiness _enumBL;

        public EnumController(IEnumBusiness enumBL,
            ILogger<EnumController> logger)
        {
            _enumBL = enumBL;
            _logger = logger;
        }

        [HttpGet("productType")]
        public IEnumerable<ProductType> GetProductTypeList()
        {
            return _enumBL.GetList<ProductType>();
        }

        [HttpGet("processor")]
        public IEnumerable<ProcessorType> GetProcessorTypeList()
        {
            return _enumBL.GetList<ProcessorType>();
        }

        [HttpGet("brand")]
        public IEnumerable<Brand> GetGenderList()
        {
            return _enumBL.GetList<Brand>();
        }

        [HttpGet("formFactor")]
        public IEnumerable<FormFactor> GetGroupList()
        {
            return _enumBL.GetList<FormFactor>();
        }

    }
}
