

using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specificatios;
using API.Dtos;
using API.Helpers;
using API.Infrastructure.DataContext;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        //private readonly StoreContext _context;
        // private readonly IProductRepository _producttRepository;

        private readonly IProductRepository _productService;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;

        private readonly IMapper _mapper;

        public ProductsController(StoreContext context, IGenericRepository<Product> productRepository,
            IProductRepository productService,
            IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<ProductType> productTypeRepository,IMapper mapper)
           
        {
           // _context = context;
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(ProductSpecParams productSpecParams) 
        {
            var spec = new ProductsWithProductTypeAndBrandSpecification(productSpecParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productSpecParams);

            var totalItems = await _productRepository.CountAsync(spec);

            var products = await _productRepository.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);



            return Ok(new Pagination<ProductToReturnDto>(productSpecParams.PageIndex,productSpecParams.PageSize, totalItems, (List<ProductToReturnDto>)data));

            


            
        }

        [HttpGet("GetProduct/{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithProductTypeAndBrandSpecification(id);
           // return await _productRepository.GetEntityWithSpec(spec);
            var product = await _productRepository.GetEntityWithSpec(spec);
            return _mapper.Map<ProductToReturnDto>(product);
        }


        [HttpGet("GetProductBrands/{brands}")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
          return Ok(await _productBrandRepository.ListAllAsync());
        }
        [HttpGet("GetProducTypes/{types}")]
        public async Task<ActionResult<List<ProductType>>> GetProducTypes()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<ProductToReturnDto>> CreateProduct(ProductToReturnDto model)
        {
            var dataModel = _mapper.Map<Product>(model);
            _productRepository.Add(dataModel);
            return Ok();
        }
    }
}

