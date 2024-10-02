using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.CounterDtos;

namespace Villa.WebUI.ViewComponents.Default_Index
{
    public class _DefaultCounter : ViewComponent
    {
        private readonly ICounterService counterService;
        private readonly IMapper mapper;

        public _DefaultCounter(ICounterService counterService, IMapper mapper)
        {
            this.counterService = counterService;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await counterService.TGetListAsync();
            var map = mapper.Map<List<ResultCounterDto>>(result);
            return View(map);
        }

    }
}
