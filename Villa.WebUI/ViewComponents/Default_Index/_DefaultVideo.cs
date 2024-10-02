using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.VideoDtos;

namespace Villa.WebUI.ViewComponents.Default_Index
{
    public class _DefaultVideo : ViewComponent
    {
        private readonly IVideoService videoService;
        private readonly IMapper mapper;

        public _DefaultVideo(IMapper mapper, IVideoService videoService)
        {
            this.mapper = mapper;
            this.videoService = videoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await videoService.TGetListAsync();
            var map = mapper.Map<List<ResultVideoDto>>(result);
            return View(map);
        }
    }
}
