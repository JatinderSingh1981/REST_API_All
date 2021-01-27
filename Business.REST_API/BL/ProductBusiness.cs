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
    public class ProductBusiness<T, S> : IProductBusiness<T, S> where T : Product where S : class
    {
        private readonly IProductBaseRepository<S> _productRepository;
        private readonly ProductsResponse _productsResponse;
        private readonly ProductResponse<T> _productResponse;
        private readonly ILogger<ProductBusiness<T, S>> _logger;
        private readonly IMapper _mapper;

        public ProductBusiness(IProductBaseRepository<S> productRepository,
            ProductResponse<T> productResponse, ProductsResponse productsResponse,
            IMapper mapper, ILogger<ProductBusiness<T, S>> logger)
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

        public virtual async Task<ProductResponse<T>> GetProductById(int productId)
        {
            throw new Exception("Not implemented");
            //try
            //{
            //    _productResponse.IsSuccess = false;
            //    _productResponse.Message = "Product Not Found";

            //    var product = await _productRepository.GetProduct(x => x.ProductId == productId);

            //    if (product != null)
            //    {
            //        var result = _mapper.Map<ProductDesktop>(product);
            //        _productResponse.Product = result;
            //        _productResponse.IsSuccess = true;
            //        _productResponse.Message = "Product Returned Successfully";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError("[GetProductById] -> {ErrorMessage}", ex.StackTrace);
            //    _productResponse.Message = ex.Message;
            //}
            //_logger.LogDebug("[GetProductById] -> {Message}", _productResponse.Message);
            //return _productResponse;
        }

        public virtual async Task<ProductResponse<T>> AddProduct(T model)
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


    public class DesktopProductBusiness<T, S> : ProductBusiness<ProductDesktop, Entity.ProductDesktop>
    {
        private readonly IProductBaseRepository<Entity.ProductDesktop> _productRepository;
        private readonly ProductsResponse _productsResponse;
        private readonly ProductResponse<ProductDesktop> _productResponse;
        private readonly ILogger<DesktopProductBusiness<ProductDesktop, Entity.ProductDesktop>> _logger;
        private readonly IMapper _mapper;

        public DesktopProductBusiness(IProductBaseRepository<Entity.ProductDesktop> productRepository,
            ProductResponse<ProductDesktop> productResponse, ProductsResponse productsResponse,
            IMapper mapper, ILogger<DesktopProductBusiness<ProductDesktop, Entity.ProductDesktop>> logger)
            : base(productRepository, productResponse, productsResponse, mapper, logger)
        {
            _productRepository = productRepository;
            _productsResponse = productsResponse;
            _productResponse = productResponse;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task<ProductResponse<ProductDesktop>> GetProductById(int productId)
        {
            try
            {
                _productResponse.IsSuccess = false;
                _productResponse.Message = "Product Not Found";

                var product = await _productRepository.GetProduct(x => x.ProductId == productId);

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

        public override async Task<ProductResponse<ProductDesktop>> AddProduct(ProductDesktop model)
        {
            try
            {
                _productResponse.IsSuccess = false;
                _productResponse.Message = "Product Not Saved";

                //Add Business Validation here so that same product cannot be added twice

                var mappedProduct = _mapper.Map<Entity.ProductDesktop>(model);
                var existingProduct = await _productRepository.GetProduct
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

    public class LaptopProductBusiness<T, S> : ProductBusiness<ProductLaptop, Entity.ProductLaptop>
    {
        private readonly IProductBaseRepository<Entity.ProductLaptop> _productRepository;
        private readonly ProductsResponse _productsResponse;
        private readonly ProductResponse<ProductLaptop> _productResponse;
        private readonly ILogger<LaptopProductBusiness<ProductLaptop, Entity.ProductLaptop>> _logger;
        private readonly IMapper _mapper;

        public LaptopProductBusiness(IProductBaseRepository<Entity.ProductLaptop> productRepository,
            ProductResponse<ProductLaptop> productResponse, ProductsResponse productsResponse,
            IMapper mapper, ILogger<LaptopProductBusiness<ProductLaptop, Entity.ProductLaptop>> logger)
            : base(productRepository, productResponse, productsResponse, mapper, logger)
        {
            _productRepository = productRepository;
            _productsResponse = productsResponse;
            _productResponse = productResponse;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task<ProductResponse<ProductLaptop>> GetProductById(int productId)
        {
            try
            {
                _productResponse.IsSuccess = false;
                _productResponse.Message = "Product Not Found";

                var product = await _productRepository.GetProduct(x => x.ProductId == productId);

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

        public override async Task<ProductResponse<ProductLaptop>> AddProduct(ProductLaptop model)
        {
            try
            {
                _productResponse.IsSuccess = false;
                _productResponse.Message = "Product Not Saved";

                //Add Business Validation here so that same product cannot be added twice

                var mappedProduct = _mapper.Map<Entity.ProductLaptop>(model);
                var existingProduct = await _productRepository.GetProduct
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
                    var result = _mapper.Map<ProductLaptop>(newProduct);
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
