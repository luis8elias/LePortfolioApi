using AutoMapper;
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
    public class LinksController : ControllerBase
    {
        private readonly EfContext _context;
        private readonly IMapper _mapper;

        public LinksController(EfContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Links
        [HttpGet("/Links")]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<Link>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BasicResponse<IEnumerable<Link>>>> GetLinks()
        {

            try
            {

                var links = await _context.Links.ToListAsync();

                if (links == null)
                {
                    return ResponseManager.NotFound("Sin links");
                }


                return ResponseManager.OK("Listado de links", links);


            }
            catch (Exception e)
            {

                return ResponseManager.Error(e);
                throw;
            }


        }

        //GET: api/Links/5
        [HttpGet("/Links/{id}")]
        [ProducesResponseType(typeof(BasicResponse<Link>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BasicResponse<Link>>> GetLinkById(int id)
        {
            try
            {
                if (_context.Links == null)
                {
                    return ResponseManager.NotFound("Sin Links");
                }
                var link = await _context.Links.FindAsync(id);

                if (link == null)
                {
                    return ResponseManager.NotFound("No existe un link con este id");
                }

                return ResponseManager.OK("Detalle de link", link);
            }
            catch (Exception e)
            {

                return ResponseManager.Error(e);
                throw;
            }
        }

        //// POST: api/Links
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/Links")]
        [ProducesResponseType(typeof(BasicResponse<Link>), 201)]
        [ProducesResponseType(typeof(BasicResponse<List<ValidationError>>), 400)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BasicResponse<Link>>> PostLink([FromBody] LinkParamDto link)
        {
            try
            {

                var linkModel = _mapper.Map<LinkParamDto, Link>(link);
                _context.Links.Add(linkModel);
                await _context.SaveChangesAsync();

                return ResponseManager.Created("Link guardado", linkModel);
            }
            catch (Exception e)
            {

                return ResponseManager.Error(e);

                throw;
            }
        }

        [HttpPut("/Links/{id}")]
        [ProducesResponseType(typeof(BasicResponse<Link>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutLink(int id, [FromBody] LinkParamDto link)
        {
            if (LinkNotExists(id))
            {
                return ResponseManager.NotFound("No existe un link con este id");
            }


            var linkModel = _mapper.Map<LinkParamDto, Link>(link);
            linkModel.Id = id;
            _context.Entry(linkModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return ResponseManager.OK("Link actualizado", linkModel);
            }
            catch (Exception e)
            {
                return ResponseManager.Error(e);
                throw;
            }

        }

        // DELETE: api/Links/5
        [HttpDelete("/Links/{id}")]
        [ProducesResponseType(typeof(BasicResponse<string?>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteLink(int id)
        {
            try
            {
                if (_context.Links == null)
                {
                    return ResponseManager.NotFound("Sin links");
                }
                var skill = await _context.Links.FindAsync(id);
                if (skill == null)
                {
                    return ResponseManager.NotFound("No existe un link con este id");
                }

                _context.Links.Remove(skill);
                await _context.SaveChangesAsync();

                return ResponseManager.OK("Link eliminado", null);

            }
            catch (Exception e)
            {
                return ResponseManager.Error(e);
                throw;
            }
        }

        private bool LinkNotExists(int id)
        {
            return !(_context.Links?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
