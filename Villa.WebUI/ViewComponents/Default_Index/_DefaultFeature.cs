using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.FeatureDtos;

namespace Villa.WebUI.ViewComponents.Default_Index
{
    public class _DefaultFeature : ViewComponent
    {
        private readonly IFeatureService featureService;
        private readonly IMapper mapper;

        public _DefaultFeature(IMapper mapper, IFeatureService featureService)
        {
            this.mapper = mapper;
            this.featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await featureService.TGetListAsync();
            var map = mapper.Map<List<ResultFeatureDto>>(result);
            return View(map);
        }
    }
}
