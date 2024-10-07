using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.ProductDtos;

namespace Villa.WebUI.ViewComponents.Default_Index
{
    public class _DefaultProduction : ViewComponent
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        public _DefaultProduction(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await productService.TGetListAsync();
            var map = mapper.Map<List<ResultProductDto>>(result);
            return View(map);
        }
    }
}
