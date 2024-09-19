using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Windows.Markup;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.FeatureDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService featureService;
        private readonly IMapper mapper;

        public FeatureController(IMapper mapper, IFeatureService featureService)
        {
            this.mapper = mapper;
            this.featureService = featureService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await featureService.TGetListAsync();
            var map = mapper.Map<List<ResultFeatureDto>>(result);
            return View(map);
        }

        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var map = mapper.Map<Feature>(createFeatureDto);
            await featureService.TCreateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateFeature(ObjectId id)
        {
            var feature = await featureService.TGetByIdAsync(id);
            var map = mapper.Map<UpdateFeatureDto>(feature);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var map = mapper.Map<Feature>(updateFeatureDto);
            await featureService.TUpdateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeature(ObjectId id)
        {
            await featureService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}