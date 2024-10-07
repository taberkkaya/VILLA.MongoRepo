using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.ContactDtos;

namespace Villa.WebUI.ViewComponents.Default_Index
{
    public class _DefaultContactInfo : ViewComponent
    {
        private readonly IContactService contactService;
        private readonly IMapper mapper;

        public _DefaultContactInfo(IContactService contactService, IMapper mapper)
        {
            this.contactService = contactService;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await contactService.TGetListAsync();
            var map = mapper.Map<List<ResultContactDto>>(result);
            return View(map);
        }
    }
}
