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
    public class ImagesController : ControllerBase
    {
        private readonly EfContext _context;
        private readonly IMapper _mapper;

        public ImagesController(EfContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Images
        [HttpGet("/Images")]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<Image>>), 200)]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<ValidationError>>),400)]
        [ProducesResponseType(typeof(BasicResponse<string>), 404)]
        public async Task<ActionResult<BasicResponse<IEnumerable<Image>>>> GetImages()
        {

            try
            {

                var images = await _context.Images.ToListAsync();

                if (images == null)
                {
                    return ResponseManager.NotFound("Sin Imágenes");
                }


                return ResponseManager.OK("Listado de imágenes", images);


            }
            catch (Exception e)
            {

                return ResponseManager.Error(e);
                throw;
            }


        }

        //GET: api/Images/5
        [HttpGet("/Images/{id}")]
        [ProducesResponseType(typeof(BasicResponse<Image>), 200)]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<ValidationError>>), 400)]
        [ProducesResponseType(typeof(BasicResponse<string>), 404)]
        public async Task<ActionResult<BasicResponse<Image>>> GetImageById(int id)
        {
            try
            {
                if (_context.Images == null)
                {
                    return ResponseManager.NotFound("Sin imágenes");
                }
                var image = await _context.Images.FindAsync(id);

                if (image == null)
                {
                    return ResponseManager.NotFound("No existe una imágen con este id");
                }

                return ResponseManager.OK("Detalle de imágen", image);
            }
            catch (Exception e)
            {

                return ResponseManager.Error(e);
                throw;
            }
        }

        //// POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/Images")]
        [ProducesResponseType(typeof(BasicResponse<Image>), 201)]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<ValidationError>>), 400)]
        [ProducesResponseType(typeof(BasicResponse<string>), 404)]
        public async Task<ActionResult<BasicResponse<Image>>> PostImage([FromBody] ImageParamDto image)
        {
            try
            {

                var imageModel = _mapper.Map<ImageParamDto, Image>(image);
                _context.Images.Add(imageModel);
                await _context.SaveChangesAsync();

                return ResponseManager.Created("Imágen guardada", imageModel);
            }
            catch (Exception e)
            {

                return ResponseManager.Error(e);
                throw;
            }
        }

        [HttpPut("/Images/{id}")]
        [ProducesResponseType(typeof(BasicResponse<Image>), 200)]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<ValidationError>>), 400)]
        [ProducesResponseType(typeof(BasicResponse<string>), 404)]
        public async Task<IActionResult> PutImage(int id, [FromBody] ImageParamDto image)
        {
            if (ImageNotExists(id))
            {
                return ResponseManager.NotFound("No existe una imágen con este id");
            }


            var imageModel = _mapper.Map<ImageParamDto, Image>(image);
            imageModel.Id = id;
            _context.Entry(imageModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return ResponseManager.OK("Imágen actualizada", imageModel);
            }
            catch (Exception e)
            {
                return ResponseManager.Error(e);
                throw;
            }

        }

        // DELETE: api/Images/5
        [HttpDelete("/Images/{id}")]
        [ProducesResponseType(typeof(BasicResponse<string?>), 200)]
        [ProducesResponseType(typeof(BasicResponse<IEnumerable<ValidationError>>), 400)]
        [ProducesResponseType(typeof(BasicResponse<string>), 404)]
        public async Task<IActionResult> DeleteImage(int id)
        {
            try
            {
                if (_context.Images == null)
                {
                    return ResponseManager.NotFound("Sin imágenes");
                }
                var image = await _context.Images.FindAsync(id);
                if (image == null)
                {
                    return ResponseManager.NotFound("No existe una imágen con este id");
                }

                _context.Images.Remove(image);
                await _context.SaveChangesAsync();

                return ResponseManager.OK("Imágen eliminada", null);

            }
            catch (Exception e)
            {
                return ResponseManager.Error(e);
                throw;
            }
        }

        private bool ImageNotExists(int id)
        {
            return !(_context.Images?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
