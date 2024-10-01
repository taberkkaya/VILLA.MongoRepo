using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.SubHeaderDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class SubHeaderController : Controller
    {
        private readonly IMapper mapper;
        private readonly ISubHeaderService subHeaderService;

        public SubHeaderController(IMapper mapper, ISubHeaderService subHeaderService)
        {
            this.mapper = mapper;
            this.subHeaderService = subHeaderService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await subHeaderService.TGetListAsync();
            var map = mapper.Map<List<ResultSubHeaderDto>>(result);
            return View(map);
        }

        public IActionResult CreateSubHeader()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubHeader(CreateSubHeaderDto createSubHeaderDto)
        {
            var map = mapper.Map<SubHeader>(createSubHeaderDto);
            await subHeaderService.TCreateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSubHeader(ObjectId id)
        {
            await subHeaderService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateSubHeader(ObjectId id)
        {
            var subHeader = await subHeaderService.TGetByIdAsync(id);
            var map = mapper.Map<UpdateSubHeaderDto>(subHeader);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubHeader(UpdateSubHeaderDto updateSubHeaderDto)
        {
            var map = mapper.Map<SubHeader>(updateSubHeaderDto);
            await subHeaderService.TUpdateAsync(map);
            return RedirectToAction("Index");
        }


    }
}
