using AutoMapper;
using DataAccess.Data;
using Shared.Dto;

namespace Blazor_Education.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDto,Course>().ReverseMap();
        }
    }
}
