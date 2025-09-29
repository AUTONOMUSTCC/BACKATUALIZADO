using Autonomus.Entities;
using Autonomus.ContextNameSpace;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Autonomus.Business
{
    public class ChatBO
    {
        public decimal InserirMensagem(Chat chat)
        {
            using var contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@texto_chat", chat.texto_chat ?? (object)DBNull.Value),
                new SqlParameter("@id_cliente", chat.id_cliente),
                new SqlParameter("@id_prestador", chat.id_prestador),
            };

            var resultado = contexto
                .Set<NovoIdMensagemResultado>()
                .FromSqlRaw("EXEC sp_InserirMensagem @texto_chat, @id_cliente, @id_prestador", parametros)
                .AsEnumerable()
                .FirstOrDefault();

            return resultado?.NovoIdMensagem ?? -1;
        }

        public List<Chat> ObterMensagensChat(int idCliente, int idPrestador)
        {
            using var contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@id_cliente", idCliente),
                new SqlParameter("@id_prestador", idPrestador),
            };

            return contexto.Chat
                .FromSqlRaw("EXEC sp_ObterMensagensChat @id_cliente, @id_prestador", parametros)
                .ToList();
        }

        public void DeletarMensagem(int idChat)
        {
            using var contexto = new Context();
            var parametro = new SqlParameter("@id_chat", idChat);

            contexto.Database.ExecuteSqlRaw(
                "EXEC sp_DeletarMensagem @id_chat",
                parametro
            );
        }
    }
}