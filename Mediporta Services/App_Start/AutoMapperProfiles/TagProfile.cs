using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mediporta.Models;
using RestServices.Models;
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
