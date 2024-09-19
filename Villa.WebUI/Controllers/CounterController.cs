using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Runtime.CompilerServices;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.CounterDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class CounterController : Controller
    {
        private readonly ICounterService counterService;
        private readonly IMapper mapper;
        public CounterController(ICounterService counterService, IMapper mapper)
        {
            this.counterService = counterService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await counterService.TGetListAsync();
            var map = mapper.Map<List<ResultCounterDto>>(values);
            return View(map);
        }

        public IActionResult CreateCounter()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCounter(CreateCounterDto createCounterDto)
        {
            var map = mapper.Map<Counter>(createCounterDto);
            await counterService.TCreateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCounter(ObjectId id)
        {
            var counter = await counterService.TGetByIdAsync(id);
            var map = mapper.Map<UpdateCounterDto>(counter);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCounter(UpdateCounterDto updateCounterDto)
        {
            var map = mapper.Map<Counter>(updateCounterDto);
            await counterService.TUpdateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCounter(ObjectId id)
        {
            await counterService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
