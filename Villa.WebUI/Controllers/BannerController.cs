using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.BannerDtos;

namespace Villa.WebUI.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBannerService bannerService;
        private readonly IMapper mapper;
        public BannerController(IBannerService bannerService, IMapper mapper)
        {
            this.bannerService = bannerService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await bannerService.TGetListAsync();
            var bannerList = mapper.Map<List<ResultBannerDto>>(values);
            return View(bannerList);
        }
    }
}
