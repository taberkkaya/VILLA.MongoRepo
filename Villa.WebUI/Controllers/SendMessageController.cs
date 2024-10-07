using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Operations;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.MessageDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class SendMessageController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IMapper mapper;
        public SendMessageController(IMessageService messageService, IMapper mapper)
        {
            this.messageService = messageService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            var map = mapper.Map<Message>(createMessageDto);
            await messageService.TCreateAsync(map);
            return RedirectToAction("Index", "Default");
        }

    }
}
