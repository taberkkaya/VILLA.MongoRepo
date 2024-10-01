using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.QuestDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class QuestController : Controller
    {
        private readonly IQuestService questService;
        private readonly IMapper mapper;

        public QuestController(IQuestService questService, IMapper mapper)
        {
            this.questService = questService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await questService.TGetListAsync();
            var map = mapper.Map<List<ResultQuestDto>>(result);
            return View(map);
        }

        public IActionResult CreateQuest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuest(CreateQuestDto createQuestDto)
        {
            ModelState.Clear(); 

            var map = mapper.Map<Quest>(createQuestDto);
            
            var validator = new QuestionValidator();
            var result = validator.Validate(map);
            
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });

                return View();
            }

            await questService.TCreateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateQuest(ObjectId id)
        {
            var quest = await questService.TGetByIdAsync(id);
            var map = mapper.Map<UpdateQuestDto>(quest);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuest(UpdateQuestDto updateQuestDto)
        {
            var map = mapper.Map<Quest>(updateQuestDto);
            await questService.TUpdateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteQuest(ObjectId id)
        {
            await questService.TDeleteAsync(id);
            return RedirectToAction("Index");
        } 
    }
}
