using AutoMapper;
using LePortfolioApi.Models;
using LePortfolioApi.ParamDtos;

namespace LePortfolioApi.Profiles
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
          
            CreateMap<SkillParamDto, Skill>();
        }
            
    }
}
