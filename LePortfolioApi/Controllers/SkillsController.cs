using Microsoft.EntityFrameworkCore;
using LePortfolioApi.Data;
using LePortfolioApi.Models;
using LePortfolioApi.Util;
using LePortfolioApi.ParamDtos;
using AutoMapper;
using LePortfolioApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LePortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly EfContext _context;
        private readonly IMapper _mapper;

        public SkillsController(EfContext context , IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Skills
        [HttpGet("/Skills")]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<Skill>>), 200)]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<ValidationError>>), 400)]
        [ProducesResponseType(typeof(BasicResponse<string>), 404)]
        public async Task<ActionResult<BasicResponse<IEnumerable<Skill>>>> GetSkills()
        {
         
            try
            {

                var skills = await _context.Skills.ToListAsync();

                if (skills == null)
                {
                    return ResponseManager.NotFound("Sin Skills");
                }
               

                return ResponseManager.OK("Listado de skills", skills);


            }
            catch (Exception e)
            {
                
                return ResponseManager.Error(e);
                throw;
            }

           
        }

        //GET: api/Skills/5
        [HttpGet("/Skills/{id}")]
        [ProducesResponseType(typeof(BasicResponse<Skill>), 200)]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<ValidationError>>), 400)]
        [ProducesResponseType(typeof(BasicResponse<string>), 404)]
        public async Task<ActionResult<BasicResponse<Skill>>> GetSkillById(int id)
        {
            try
            {
                if (_context.Skills == null)
                {
                    return ResponseManager.NotFound("Sin Skills");
                }
                var skill = await _context.Skills.FindAsync(id);

                if (skill == null)
                {
                    return ResponseManager.NotFound("No existe un skill con este id");
                }

                return ResponseManager.OK("Detalle de skill", skill);
            }
            catch (Exception e)
            {

                return ResponseManager.Error(e);
                throw;
            }
        }

        //// POST: api/Skills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/Skills")]
        [ProducesResponseType(typeof(BasicResponse<Skill>), 201)]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<ValidationError>>), 400)]
        [ProducesResponseType(typeof(BasicResponse<string>), 404)]
        public async Task<ActionResult<BasicResponse<Skill>>> PostSkill([FromBody] SkillParamDto skill)
        {
            try
            {

                var skillModel = _mapper.Map<SkillParamDto, Skill>(skill);
                _context.Skills.Add(skillModel);
                await _context.SaveChangesAsync();

                return  ResponseManager.Created("Skill guardada", skillModel);
            }
            catch (Exception e)
            {

                return ResponseManager.Error(e);

                throw;
            }
        }

        [HttpPut("/Skills/{id}")]
        [ProducesResponseType(typeof(BasicResponse<Skill>), 200)]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<ValidationError>>), 400)]
        [ProducesResponseType(typeof(BasicResponse<string>), 404)]
        public async Task<IActionResult> PutSkill(int id, [FromBody] SkillParamDto skill)
        {
            if (SkillNotExists(id))
            {
                return ResponseManager.NotFound("No existe un skill con este id");
            }
           

            var skillModel = _mapper.Map<SkillParamDto, Skill>(skill);
            skillModel.Id = id;
            _context.Entry(skillModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return ResponseManager.OK("Skill actualizada", skillModel);
            }
            catch (Exception e)
            {
                return ResponseManager.Error(e);
                throw;
            }
            
        }

        // DELETE: api/Skills/5
        [HttpDelete("/Skills/{id}")]
        [ProducesResponseType(typeof(BasicResponse<string?>), 200)]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<ValidationError>>), 400)]
        [ProducesResponseType(typeof(BasicResponse<string>), 404)]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            try
            {
                if (_context.Skills == null)
                {
                    return ResponseManager.NotFound("Sin Skills");
                }
                var skill = await _context.Skills.FindAsync(id);
                if (skill == null)
                {
                    return ResponseManager.NotFound("No existe un skill con este id");
                }

                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();

                return ResponseManager.OK("Skill eliminada", null);

            }
            catch (Exception e)
            {
                return ResponseManager.Error(e);
                throw;
            }
        }

        private bool SkillNotExists(int id)
        {
            return !(_context.Skills?.Any(e => e.Id == id)).GetValueOrDefault();
        }



    }
}
