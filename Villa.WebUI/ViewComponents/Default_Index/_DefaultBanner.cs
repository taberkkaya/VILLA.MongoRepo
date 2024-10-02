using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.BannerDtos;

namespace Villa.WebUI.ViewComponents.Default_Index
{
    public class _DefaultBanner : ViewComponent
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper mapper;

        public _DefaultBanner(IBannerService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _bannerService.TGetListAsync();
            var map = mapper.Map<List<ResultBannerDto>>(result);
            return View(map);
        }
    }
}
