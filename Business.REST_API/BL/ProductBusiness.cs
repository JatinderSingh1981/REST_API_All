using AutoMapper;
using Microsoft.Extensions.Logging;
using Models.REST_API;
using Repository.REST_API;
using ViewModels.REST_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Entity = Entities.REST_API;

namespace Business.REST_API
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductsResponse _productsResponse;
        private readonly ProductResponse _productResponse;
        private readonly ILogger<ProductBusiness> _logger;
        private readonly IMapper _mapper;

        public ProductBusiness(IProductRepository productRepository,
            ProductResponse productResponse, ProductsResponse productsResponse,
            IMapper mapper, ILogger<ProductBusiness> logger)
        {
            _productRepository = productRepository;
            _productsResponse = productsResponse;
            _productResponse = productResponse;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductsResponse> GetProducts()
        {
            try
            {
                _productsResponse.IsSuccess = false;
                _productsResponse.Message = "Some error Occurred while fetching the data";
                var products = await _productRepository.GetProductList();
                if (products != null && products.Any())
                {
                    var result = _mapper.Map<IEnumerable<Product>>(products);
                    _productsResponse.Products = result;
                    _productsResponse.IsSuccess = true;
                    _productsResponse.Message = "Products Returned Successfully";
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("[GetProducts] -> {ErrorMessage}", ex.StackTrace);
                _productsResponse.Message = ex.Message;
            }
            _logger.LogDebug("[GetProducts] -> {Message}", _productsResponse.Message);
            return _productsResponse;
        }

        public virtual async Task<ProductResponse> GetProductById<T>(int productId) where T : class
        {

            try
            {
                _productResponse.IsSuccess = false;
                _productResponse.Message = "Product Not Found";

                var product = await _productRepository.GetProduct<Product>(x => x.ProductId == productId, false);

                if (product != null)
                {
                    var result = _mapper.Map<ProductDesktop>(product);
                    _productResponse.Product = result;
                    _productResponse.IsSuccess = true;
                    _productResponse.Message = "Product Returned Successfully";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("[GetProductById] -> {ErrorMessage}", ex.StackTrace);
                _productResponse.Message = ex.Message;
            }
            _logger.LogDebug("[GetProductById] -> {Message}", _productResponse.Message);
            return _productResponse;
        }

        public virtual async Task<ProductResponse> AddProduct<T>(T model) where T : class
        {
            throw new Exception("Not implemented");
            //    try
            //    {
            //        _productResponse.IsSuccess = false;
            //        _productResponse.Message = "Product Not Saved";

            //        //Add Business Validation here so that same product cannot be added twice

            //        var mappedProduct = _mapper.Map<Entity.CommonProduct>(model);
            //        //var existingProduct = await _productRepository.GetProduct
            //        //    (x => x.Product.ComputerTypeId == mappedProduct.Product.ComputerTypeId
            //        //        && x.Product.ProcessorId == mappedProduct.Product.ProcessorId
            //        //        && x.Product.BrandId == mappedProduct.Product.BrandId
            //        //        && x.FormFactorId == mappedProduct.FormFactorId);
            //        ////Similar product already exists, return from here
            //        //if (existingProduct != null)
            //        //{
            //        //    _productResponse.Message = "Inventory for the same product already exists, please change the product details or update the existing product!!!";
            //        //    return _productResponse;
            //        //}

            //        var newProduct = await _productRepository.AddProduct(mappedProduct);
            //        //}
            //        //else
            //        //{
            //        //    var mappedProduct = _mapper.Map<Entity.ProductLaptop>(model);
            //        //    existingProduct = await _productRepository.GetProduct<Entity.ProductLaptop>
            //        //        (x => x.Product.ComputerTypeId == mappedProduct.Product.ComputerTypeId
            //        //            && x.Product.ProcessorId == mappedProduct.Product.ProcessorId
            //        //            && x.Product.BrandId == mappedProduct.Product.BrandId
            //        //            && x.ScreenSize == mappedProduct.ScreenSize);
            //        //    //Similar product already exists, return from here
            //        //    if (existingProduct != null)
            //        //    {
            //        //        _productResponse.Message = "Inventory for the same product already exists, please change the product details or update the existing product!!!";
            //        //        return _productResponse;
            //        //    }
            //        //    newProduct = await _productRepository.AddProduct<Entity.ProductLaptop>(mappedProduct);
            //        //}


            //        if (newProduct != null)
            //        {
            //            var result = _mapper.Map<T>(newProduct);
            //            _productResponse.Product = result;
            //            _productResponse.IsSuccess = true;
            //            _productResponse.Message = "Product Saved Successfully";
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        _logger.LogError("[AddProduct] -> {ErrorMessage}", ex.StackTrace);
            //        _productResponse.Message = ex.Message;
            //    }
            //    _logger.LogDebug("[AddProduct] -> {Message}", _productResponse.Message);
            //    return _productResponse;


        }
    }


    public class DesktopProductBusiness : ProductBusiness
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductsResponse _productsResponse;
        private readonly ProductResponse _productResponse;
        private readonly ILogger<DesktopProductBusiness> _logger;
        private readonly IMapper _mapper;

        public DesktopProductBusiness(IProductRepository productRepository,
            ProductResponse productResponse, ProductsResponse productsResponse,
            IMapper mapper, ILogger<DesktopProductBusiness> logger)
            : base(productRepository, productResponse, productsResponse, mapper, logger)
        {
            _productRepository = productRepository;
            _productsResponse = productsResponse;
            _productResponse = productResponse;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task<ProductResponse> GetProductById<T>(int productId) where T : class
        {
            try
            {
                _productResponse.IsSuccess = false;
                _productResponse.Message = "Product Not Found";

                var product = await _productRepository.GetProduct<Entity.ProductDesktop>(x => x.ProductId == productId);

                if (product != null)
                {
                    var result = _mapper.Map<ProductDesktop>(product);
                    _productResponse.Product = result;
                    _productResponse.IsSuccess = true;
                    _productResponse.Message = "Product Returned Successfully";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("[GetProductById] -> {ErrorMessage}", ex.StackTrace);
                _productResponse.Message = ex.Message;
            }
            _logger.LogDebug("[GetProductById] -> {Message}", _productResponse.Message);
            return _productResponse;
        }

        public override async Task<ProductResponse> AddProduct<T>(T model) where T : class
        {
            try
            {
                _productResponse.IsSuccess = false;
                _productResponse.Message = "Product Not Saved";

                //Add Business Validation here so that same product cannot be added twice

                var mappedProduct = _mapper.Map<Entity.ProductDesktop>(model);
                var existingProduct = await _productRepository.GetProduct<Entity.ProductDesktop>
                    (x => x.Product.ComputerTypeId == mappedProduct.Product.ComputerTypeId
                        && x.Product.ProcessorId == mappedProduct.Product.ProcessorId
                        && x.Product.BrandId == mappedProduct.Product.BrandId
                        && x.FormFactorId == mappedProduct.FormFactorId);
                //Similar product already exists, return from here
                if (existingProduct != null)
                {
                    _productResponse.Message = "Inventory for the same product already exists, please change the product details or update the existing product!!!";
                    return _productResponse;
                }

                var newProduct = await _productRepository.AddProduct(mappedProduct);

                if (newProduct != null)
                {
                    var result = _mapper.Map<ProductDesktop>(newProduct);
                    _productResponse.Product = result;
                    _productResponse.IsSuccess = true;
                    _productResponse.Message = "Product Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("[AddProduct] -> {ErrorMessage}", ex.StackTrace);
                _productResponse.Message = ex.Message;
            }
            _logger.LogDebug("[AddProduct] -> {Message}", _productResponse.Message);
            return _productResponse;
        }

    }

    public class LaptopProductBusiness : ProductBusiness
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductsResponse _productsResponse;
        private readonly ProductResponse _productResponse;
        private readonly ILogger<LaptopProductBusiness> _logger;
        private readonly IMapper _mapper;

        public LaptopProductBusiness(IProductRepository productRepository,
            ProductResponse productResponse, ProductsResponse productsResponse,
            IMapper mapper, ILogger<LaptopProductBusiness> logger)
            : base(productRepository, productResponse, productsResponse, mapper, logger)
        {
            _productRepository = productRepository;
            _productsResponse = productsResponse;
            _productResponse = productResponse;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task<ProductResponse> GetProductById<T>(int productId) where T : class
        {
            try
            {
                _productResponse.IsSuccess = false;
                _productResponse.Message = "Product Not Found";

                var product = await _productRepository.GetProduct<Entity.ProductLaptop>(x => x.ProductId == productId);

                if (product != null)
                {
                    var result = _mapper.Map<ProductLaptop>(product);
                    _productResponse.Product = result;
                    _productResponse.IsSuccess = true;
                    _productResponse.Message = "Product Returned Successfully";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("[GetProductById] -> {ErrorMessage}", ex.StackTrace);
                _productResponse.Message = ex.Message;
            }
            _logger.LogDebug("[GetProductById] -> {Message}", _productResponse.Message);
            return _productResponse;
        }

        public override async Task<ProductResponse> AddProduct<T>(T model) where T : class
        {
            try
            {
                _productResponse.IsSuccess = false;
                _productResponse.Message = "Product Not Saved";

                //Add Business Validation here so that same product cannot be added twice

                var mappedProduct = _mapper.Map<Entity.ProductLaptop>(model);
                var existingProduct = await _productRepository.GetProduct<Entity.ProductLaptop>
                    (x => x.Product.ComputerTypeId == mappedProduct.Product.ComputerTypeId
                        && x.Product.ProcessorId == mappedProduct.Product.ProcessorId
                        && x.Product.BrandId == mappedProduct.Product.BrandId
                        && x.ScreenSize == mappedProduct.ScreenSize);
                //Similar product already exists, return from here
                if (existingProduct != null)
                {
                    _productResponse.Message = "Inventory for the same product already exists, please change the product details or update the existing product!!!";
                    return _productResponse;
                }

                var newProduct = await _productRepository.AddProduct(mappedProduct);

                if (newProduct != null)
                {
                    var result = _mapper.Map<ProductDesktop>(newProduct);
                    _productResponse.Product = result;
                    _productResponse.IsSuccess = true;
                    _productResponse.Message = "Product Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("[AddProduct] -> {ErrorMessage}", ex.StackTrace);
                _productResponse.Message = ex.Message;
            }
            _logger.LogDebug("[AddProduct] -> {Message}", _productResponse.Message);
            return _productResponse;
        }

    }
}
