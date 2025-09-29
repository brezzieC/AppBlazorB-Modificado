using AppBlazor.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppBlazorB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        [HttpGet]
        public IActionResult listarLibros()
        {
            try
            {
                return Ok();
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{idlibro}")]
        public IActionResult recuperarLibro(int idlibro)
        {
            try
            {
               return Ok();
            }
            catch (Exception ex)
            {
                    return StatusCode(500, ex.Message);
            }
        }
            [HttpDelete("{idlibro}")]
            public IActionResult eliminarLibro(int idlibro)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        [HttpPost]
        public IActionResult guardarLibro([FromBody]LibroFormCLS libroFormCLS)   
        {
            try
            {
                return Ok();
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("recuperarArchivo/{idlibro}")]
        public IActionResult recuperarArchivoPorId(int idlibro)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

