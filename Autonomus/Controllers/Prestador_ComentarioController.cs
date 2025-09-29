using Autonomus.Business;
using Autonomus.ContextNameSpace;
using Autonomus.Entities;
using Microsoft.AspNetCore.Mvc;
using static Autonomus.Business.PrestadorBO;

namespace Autonomus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioPrestadorController : ControllerBase
    {
        [HttpGet(Name = "ObterComentarioPrestador")]
        public List<comentario_Prestador> Get()
        {
            ComentarioPBO comentarioPBO = new ComentarioPBO();
            return comentarioPBO.ObterComentarioPrestador();
        }

        [HttpPost(Name = "InserirComentarioPrestador")]
        public IActionResult Post([FromBody] comentario_Prestador comentario)
        {
            comentario.data_comentario_prestador = DateTime.Now;
            ComentarioPBO bo = new ComentarioPBO();
            bo.InserirComentarioPrestador(comentario);
            return Ok("Comentário inserido com sucesso!");
        }

        [HttpDelete("{id}", Name = "DeletarComentarioPrestador")]
        public IActionResult Delete(int id)
        {
            ComentarioPBO comentario = new ComentarioPBO();
            comentario.DeletarComentarioPrestador(id);
            return Ok("Comentário deletado com sucesso!");
        }
    }
}
