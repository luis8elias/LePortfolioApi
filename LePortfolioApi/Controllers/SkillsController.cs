using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LePortfolioApi.Data;
using LePortfolioApi.Models;
using LePortfolioApi.Util;
using LePortfolioApi.ParamDtos;
using AutoMapper;

namespace LePortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly EfContext _context;
        private readonly IMapper _mapper;

        public SkillsController(EfContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Skills
        [HttpGet("/Skills")]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<Skill>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BasicResponse<IEnumerable<Skill>>>> GetSkills()
        {
         
            try
            {

                var skills = await _context.Skills.ToListAsync();

                if (skills == null)
                {
                    return NotFound(ResponseManager.NotFound("Sin Skills"));
                }
               

                return Ok(ResponseManager.OK("Listado de skills", skills));


            }
            catch (Exception e)
            {
                
                return BadRequest(ResponseManager.Error(e));
                throw;
            }

           
        }

        //GET: api/Skills/5
        [HttpGet("/Skills/{id}")]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<Skill>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BasicResponse<Skill>>> GetSkillById(int id)
        {
            try
            {
                if (_context.Skills == null)
                {
                    return NotFound(ResponseManager.NotFound("Sin Skills"));
                }
                var skill = await _context.Skills.FindAsync(id);

                if (skill == null)
                {
                    return NotFound(ResponseManager.NotFound("No se econtró el skill"));
                }

                return Ok(ResponseManager.OK("Detalle de skill", skill));
            }
            catch (Exception e)
            {

                return BadRequest(ResponseManager.Error(e));
                throw;
            }
        }

        //// POST: api/Skills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/Skills")]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<Skill>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BasicResponse<Skill>>> PostSkill([FromBody] SkillParamDto skill)
        {
            try
            {
                var skillModel = _mapper.Map<SkillParamDto, Skill>(skill);
                _context.Skills.Add(skillModel);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSkillById", new { id =  skillModel.Id  } , ResponseManager.OK("Skill guardada", skillModel));
            }
            catch (Exception e)
            {

                return BadRequest(ResponseManager.Error(e));
                throw;
            }
        }

        [HttpPut("/Skills/{id}")]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<Skill>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutSkill(int id, [FromBody] SkillParamDto skill)
        {
            if (SkillNotExists(id))
            {
                return NotFound(ResponseManager.NotFound("No existe un skill con este id"));
            }

            var skillModel = _mapper.Map<SkillParamDto, Skill>(skill);
            skillModel.Id = id;
            _context.Entry(skillModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(ResponseManager.OK("Skill actualizada", skillModel));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseManager.Error(e));
                throw;
            }
            
        }

        // DELETE: api/Skills/5
        [HttpDelete("/Skills/{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            if (_context.Skills == null)
            {
                return NotFound(ResponseManager.NotFound("Sin Skills"));
            }
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound(ResponseManager.NotFound("No existe un skill con este id"));
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return Ok(ResponseManager.OK("Skill eliminada", null)) ;
        }

        private bool SkillNotExists(int id)
        {
            return !(_context.Skills?.Any(e => e.Id == id)).GetValueOrDefault();
        }



    }
}
