using Autonomus.Business;
using Autonomus.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Autonomus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        [HttpPost("enviar")]
        public decimal Post([FromBody] Chat chat)
        {
            ChatBO chatBO = new ChatBO();
            return chatBO.InserirMensagem(chat);
        }

        [HttpGet("mensagens")]
        public List<Chat> Get([FromQuery] int idCliente, [FromQuery] int idPrestador)
        {
            ChatBO chatBO = new ChatBO();
            return chatBO.ObterMensagensChat(idCliente, idPrestador);
        }

        [HttpDelete("deletar")]
        public void Delete([FromQuery] int idChat)
        {
            ChatBO chatBO = new ChatBO();
            chatBO.DeletarMensagem(idChat);
        }
    }
}