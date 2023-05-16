using AutoMapper;
using LePortfolioApi.Dtos;
using LePortfolioApi.Models;
using LePortfolioApi.ParamDtos;

namespace LePortfolioApi.Profiles
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
          
            CreateMap<SkillParamDto, Skill>();
            CreateMap<Skill, Skill>();
            CreateMap<ProjectSkill, Skill>().IncludeMembers(x => x.Skill);
           


            CreateMap<Image, ImageDto>();
            CreateMap<LinkParamDto, Link>();
            CreateMap<Link, LinkDto>();
            CreateMap<ProjectLinkParamDto, Link>();
            CreateMap<ImageParamDto, Image>();
            CreateMap<ProjectImageParamDto, Image>();
            CreateMap<Image, ImageDto>();
            CreateMap<ProjectParamDto, Project>()
                .ForMember(dest => dest.Technologies, act => act.Ignore());
            CreateMap<Project, ProjectDto>();
                
        }
            
    }
}
