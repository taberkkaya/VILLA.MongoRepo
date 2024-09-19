using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.ContactDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        private readonly IMapper mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            this.contactService = contactService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await contactService.TGetListAsync();
            var result = mapper.Map<List<ResultContactDto>>(values);
            return View(result);
        }

        public async Task<IActionResult> DeleteContact(ObjectId id)
        {
            await contactService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var map = mapper.Map<Contact>(createContactDto);
            await contactService.TCreateAsync(map);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateContact(ObjectId id)
        {
            var contact = await contactService.TGetByIdAsync(id);
            var map = mapper.Map<UpdateContactDto>(contact);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var map = mapper.Map<Contact>(updateContactDto);
            await contactService.TUpdateAsync(map);
            return RedirectToAction("Index");
        }

    }
}
