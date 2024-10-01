using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.VideoDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class VideoController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVideoService videoService;

        public VideoController(IMapper mapper, IVideoService videoService)
        {
            this.mapper = mapper;
            this.videoService = videoService;
        }

        public async Task<IActionResult> Index()
        {
            var videos = await videoService.TGetListAsync();
            var map = mapper.Map<List<ResultVideoDto>>(videos);
            return View(map);
        }

        public async Task<IActionResult> CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateVideoDto createVideoDto)
        {
            ModelState.Clear();

            var map = mapper.Map<Video>(createVideoDto);

            var validator = new VideoValidator();
            var result = validator.Validate(map);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });

                return View();
            }

            await videoService.TCreateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateVideo(ObjectId id)
        {
            var video = await videoService.TGetByIdAsync(id);
            var map = mapper.Map<UpdateVideoDto>(video);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVideo(UpdateVideoDto updateVideoDto)
        {
            var map = mapper.Map<Video>(updateVideoDto);

            var validator = new VideoValidator();
            var result = validator.Validate(map);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });

                return View();
            }

            await videoService.TUpdateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteVideo(ObjectId id)
        {
            await videoService.TDeleteAsync(id);    
            return RedirectToAction("Index");
        }
    }
}
