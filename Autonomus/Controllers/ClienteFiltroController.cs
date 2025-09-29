using Autonomus.Business;
using Autonomus.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Autonomus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteFiltroController : ControllerBase
    {

        [HttpGet(Name = "ObterClientesPorRating")]
        public List<Cliente> GetObterClientesPorRating(decimal avaliacaominima, decimal avaliacaomaxima)
        {
            ClienteBO clientes = new ClienteBO();
            return clientes.ObterClientesPorRating(avaliacaominima, avaliacaomaxima);
        }


    }
}
