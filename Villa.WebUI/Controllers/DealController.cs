using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.DealDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class DealController : Controller
    {
        private readonly IDealService dealService;
        private readonly IMapper mapper;

        public DealController(IMapper mapper, IDealService dealService)
        {
            this.mapper = mapper;
            this.dealService = dealService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await dealService.TGetListAsync();
            var map = mapper.Map<List<ResultDealDto>>(result);
            return View(map);
        }

        public IActionResult CreateDeal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeal(CreateDealDto createDealDto)
        {
            var map = mapper.Map<Deal>(createDealDto);
            await dealService.TCreateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateDeal(ObjectId id)
        {
            var deal = await dealService.TGetByIdAsync(id);
            var map = mapper.Map<UpdateDealDto>(deal);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDeal(UpdateDealDto updateDealDto)
        {
            var map = mapper.Map<Deal>(updateDealDto);
            await dealService.TUpdateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDeal(ObjectId id)
        {
            await dealService.TDeleteAsync(id); 
            return RedirectToAction("Index");
        }

    }
}
