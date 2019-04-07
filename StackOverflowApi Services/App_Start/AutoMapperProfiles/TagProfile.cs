using AutoMapper;
using Mediporta_Services.Models;
using RestServices.Models.DTO;

namespace RestServices.App_Start.AutoMapper
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<TagResult, TagResultDTO>();
        }

    }
}
