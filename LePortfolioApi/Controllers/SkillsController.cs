using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LePortfolioApi.Data;
using LePortfolioApi.Models;
using LePortfolioApi.Util;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace LePortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly EfContext _context;

        public SkillsController(EfContext context)
        {
            _context = context;
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
               

                return Ok(ResponseManager.OK("Success", skills));


            }
            catch (Exception e)
            {
                
                return BadRequest(ResponseManager.Error(e));
                throw;
            }

           
        }

    }
}
