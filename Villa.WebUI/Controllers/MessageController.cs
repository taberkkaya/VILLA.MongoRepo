using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Security.Policy;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.MessageDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class MessageController : Controller
    {

        private readonly IMessageService messageService;
        private readonly IMapper mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            this.messageService = messageService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await messageService.TGetListAsync();
            var map = mapper.Map<List<ResultMessageDto>>(result);
            return View(map);
        }

        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            var map = mapper.Map<Message>(createMessageDto);
            await messageService.TCreateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MessageDetails(ObjectId id)
        {
            var message = await messageService.TGetByIdAsync(id);
            var result = mapper.Map<ResultMessageDto>(message);
            return View(result);
        }
    }
}
