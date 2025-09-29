using Autonomus.ContextNameSpace;
using Microsoft.AspNetCore.Mvc;
using static Autonomus.Business.ClienteBO;

namespace Autonomus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioController : ControllerBase
        {
            [HttpGet(Name = "ObterComentarioCliente")]
            public List<comentario_Cliente> Get()
            {
                ComentarioBO comentarioBO = new ComentarioBO();
                return comentarioBO.ObterComentarioCliente();
            }
            [HttpPost(Name = "InserirComentarioCliente")]

        public IActionResult Post([FromBody] comentario_Cliente comentario)
        {
            comentario.data_comentario_cliente = DateTime.Now;
            ComentarioBO bo = new ComentarioBO();
            bo.InserirComentarioCliente(comentario);
            return Ok("Comentário inserido com sucesso!");
        }

        [HttpDelete("{id}", Name = "DeletarComentarioCliente")]
            public void Delete(int id_comentario_cliente)
            {
                ComentarioBO comentario = new ComentarioBO();
                comentario.DeletarComentarioCliente(id_comentario_cliente);
            }

        }
    }

