using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.DealDtos;

namespace Villa.WebUI.ViewComponents.Default_Index
{
    public class _DefaultDeal : ViewComponent
    {
        private readonly IDealService dealService;
        private readonly IMapper mapper;

        public _DefaultDeal(IDealService dealService, IMapper mapper)
        {
            this.dealService = dealService;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await dealService.TGetListAsync();
            var map = mapper.Map<List<ResultDealDto>>(result);
            return View(map);
        }
    }
}
