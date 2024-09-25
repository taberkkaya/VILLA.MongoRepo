using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.ProductDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await productService.TGetListAsync();
            var map = mapper.Map<List<ResultProductDto>>(values);
            return View(map);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var map = mapper.Map<Product>(createProductDto);
            await productService.TCreateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(ObjectId id)
        {
            await productService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(ObjectId id)
        {
            var product = await productService.TGetByIdAsync(id);
            var map = mapper.Map<Product>(product);
            return View(map);
        }

    }
}
