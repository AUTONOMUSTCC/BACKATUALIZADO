using Autonomus.Business;
using Autonomus.ContextNameSpace;
using Autonomus.Entities;
using Microsoft.AspNetCore.Mvc;
using static Autonomus.Business.ClienteBO;

namespace Autonomus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        [HttpGet(Name = "ObterClientes")]
        public List<Cliente> Get()
        {
            ClienteBO clientes = new ClienteBO();
            return clientes.ObterClientes();
        }

        [HttpPost(Name = "InserirClientes")]
        public decimal Post(Cliente cliente)
        {
            ClienteBO clientes = new ClienteBO();
            return clientes.InserirCliente(cliente);
        }

        [HttpDelete(Name = "DeletarClientes")]
        public void Delete(int idCliente)
        {
            ClienteBO clientes = new ClienteBO();
            clientes.DeletarCliente(idCliente);
        }


        [HttpPut(Name = "AtualizarClientes")]
        public void Put(Cliente cliente)
        {
            ClienteBO clientes = new ClienteBO();
            clientes.AtualizarCliente(cliente);
        }

        [HttpGet("filtrar")]
        public List<Cliente> Filtrar([FromQuery] string? nome)
        {
            ClienteBO bo = new ClienteBO();
            return bo.FiltrarClientes(nome);
        }

        [HttpGet("filtrar-por-cidade")]
        public List<Cliente> FiltrarPorCidade([FromQuery] string? cidade)
        {
            ClienteBO bo = new ClienteBO();
            return bo.FiltrarPorCidade(cidade);
        }

    }
    
}
