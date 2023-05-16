using AutoMapper;
using AutoMapper.QueryableExtensions;
using LePortfolioApi.Data;
using LePortfolioApi.Dtos;
using LePortfolioApi.Models;
using LePortfolioApi.ParamDtos;
using LePortfolioApi.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LePortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly EfContext _context;
        private readonly IMapper _mapper;

        public ProjectController(EfContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Projects
        [HttpGet("/Projects")]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<Project>>), 200)]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<ValidationError>>), 400)]
        [ProducesResponseType(typeof(BasicResponse<string>), 404)]
        public async Task<ActionResult<BasicResponse<IEnumerable<Project>>>> GetProjects()
        {

            try
            {

                var projects = await _context.Projects
                    .Include(p => p.Images)
                    .Include(p => p.Links)
                    .Include(p => p.Technologies)
                    .ThenInclude(t=> t.Skill )
                    .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            
                if (projects == null)
                {
                    return ResponseManager.NotFound("Sin Proyectos");
                }

                return ResponseManager.OK("Listado de proyectos", projects);

            }
            catch (Exception e)
            {

                return ResponseManager.Error(e);
                throw;
            }


        }

        //// POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/Projects")]
        [ProducesResponseType(typeof(BasicResponse<ProjectDto>), 201)]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<ValidationError>>), 400)]
        [ProducesResponseType(typeof(BasicResponse<string>), 404)]
        public async Task<ActionResult<BasicResponse<Project>>> PostProject([FromBody] ProjectParamDto project)
        {
            try
            {

                var projectModel = _mapper.Map<ProjectParamDto, Project>(project);
                _context.Projects.Add(projectModel);

                projectModel.Technologies = project.SkillsIds.Select(skillId => new ProjectSkill()
                {
                    SkillId = skillId,
                    ProjectId = projectModel.Id,
                }).ToList();

                await _context.SaveChangesAsync();


                var projectDetailed = _context.Projects
                    .Where(p => p.Id == projectModel.Id)
                    .Include(p => p.Images)
                    .Include(p => p.Links)
                    .Include(p => p.Technologies)
                    .ThenInclude(t => t.Skill)
                    .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider).First();

                return ResponseManager.Created("Proyecto guardado", projectDetailed);



            }
            catch (Exception e)
            {

                return ResponseManager.Error(e);

                throw;
            }
        }
    }
}
