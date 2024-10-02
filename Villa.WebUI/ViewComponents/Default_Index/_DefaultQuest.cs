using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.QuestDtos;

namespace Villa.WebUI.ViewComponents.Default_Index
{
    public class _DefaultQuest : ViewComponent
    {
        private readonly IQuestService questService;
        private readonly IMapper mapper;

        public _DefaultQuest(IQuestService questService, IMapper mapper)
        {
            this.questService = questService;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await questService.TGetListAsync();
            var map = mapper.Map<List<ResultQuestDto>>(result);
            return View(map);
        }
    }
}
