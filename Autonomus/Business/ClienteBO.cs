using Autonomus.Entities;
using Microsoft.EntityFrameworkCore;
using Autonomus.ContextNameSpace;
using Microsoft.Data.SqlClient;
using static Autonomus.Business.ClienteBO;

namespace Autonomus.Business
{
    public class ClienteBO
    {
        public List<Cliente> ObterClientes()
        {
            Context contexto = new Context();
            var resultado = contexto.Cliente.FromSqlRaw("exec sp_SelecionarClientes").ToList();

            return resultado.ToList();

        }

        public decimal InserirCliente(Cliente cliente)
        {
            Context contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@NomeCliente", cliente.NomeCliente ?? (object)DBNull.Value),
                new SqlParameter("@SobrenomeCliente", cliente.SobrenomeCliente ?? (object)DBNull.Value),
                new SqlParameter("@TelefoneCliente", cliente.TelefoneCliente ?? (object)DBNull.Value),
                new SqlParameter("@EmailCliente", cliente.EmailCliente ?? (object)DBNull.Value),
                new SqlParameter("@GeneroCliente", cliente.GeneroCliente ?? (object)DBNull.Value),
                new SqlParameter("@CidadeCliente", cliente.CidadeCliente ?? (object)DBNull.Value),
                new SqlParameter("@DataNascimentoCliente", cliente.DataNascimentoCliente),
                new SqlParameter("@AvaliacaoCliente", cliente.AvaliacaoCliente),
                new SqlParameter("@SenhaCliente", cliente.SenhaCliente ?? (object)DBNull.Value)
            };

            var resultado = contexto
            .Set<NovoClienteResultado>()
            .FromSqlRaw("EXEC sp_InserirCliente @NomeCliente, @SobrenomeCliente, @TelefoneCliente, @EmailCliente, @GeneroCliente, @CidadeCliente, @DataNascimentoCliente, @AvaliacaoCliente, @SenhaCliente", parametros)
            .AsEnumerable().FirstOrDefault();

            return resultado.NovoIdCliente;
        }

        public void DeletarCliente(int idCliente)
        {
            var contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@IdCliente", idCliente)
            };

            contexto.Database.ExecuteSqlRaw("EXEC dboDeletarCliente @IdCliente", parametros);
        }

        public void AtualizarCliente(Cliente cliente)
        {
            Context contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@NomeCliente", cliente.NomeCliente ?? (object)DBNull.Value),
                new SqlParameter("@SobrenomeCliente", cliente.SobrenomeCliente ?? (object)DBNull.Value),
                new SqlParameter("@TelefoneCliente", cliente.TelefoneCliente ?? (object)DBNull.Value),
                new SqlParameter("@EmailCliente", cliente.EmailCliente ?? (object)DBNull.Value),
                new SqlParameter("@GeneroCliente", cliente.GeneroCliente ?? (object)DBNull.Value),
                new SqlParameter("@CidadeCliente", cliente.CidadeCliente ?? (object)DBNull.Value),
                new SqlParameter("@DataNascimentoCliente", cliente.DataNascimentoCliente),
                new SqlParameter("@AvaliacaoCliente", cliente.AvaliacaoCliente),
                new SqlParameter("@SenhaCliente", cliente.SenhaCliente  ?? (object)DBNull.Value),
                new SqlParameter("@idCliente", cliente.IdCliente)
            };

            contexto.Database.ExecuteSqlRaw("EXEC sp_UpdateCliente @NomeCliente, @SobrenomeCliente, @TelefoneCliente, @EmailCliente, @GeneroCliente, @CidadeCliente, @DataNascimentoCliente, @AvaliacaoCliente, @SenhaCliente, @idCliente", parametros);
        }

        public List<Cliente> ObterClientesPorRating(decimal avaliacaominima, decimal avaliacaomaxima)
        {
            Context contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@MinAvaliacao", avaliacaominima),
                new SqlParameter("@MaxAvaliacao", avaliacaomaxima),
            };

            var resultado = contexto.Cliente.FromSqlRaw("exec sp_FiltrarClientesAvaliacao @MinAvaliacao, @MaxAvaliacao", parametros);
            return resultado.ToList();

        }

        public List<Cliente> FiltrarClientes(string? nomeCliente)
        {
            using var contexto = new Context();
            var parametro = new SqlParameter("@NomeCliente",
                               string.IsNullOrEmpty(nomeCliente) ? DBNull.Value : nomeCliente);

            var resultado = contexto.Cliente
                .FromSqlRaw("EXEC sp_FiltrarClientes @NomeCliente", parametro)
                .ToList();

            return resultado;
        }

        public List<Cliente> FiltrarPorCidade(string? cidade)
        {
            using var contexto = new Context();
            var parametro = new SqlParameter("@CidadeCliente",
                               string.IsNullOrEmpty(cidade) ? DBNull.Value : cidade);

            var resultado = contexto.Cliente
                .FromSqlRaw("EXEC sp_FiltrarClienterCidade @CidadeCliente", parametro)
                .AsNoTracking()
                .ToList();

            return resultado;
        }

        public class ComentarioBO
        {
            public List<comentario_Cliente> ObterComentarioCliente()
            {
                using var contexto = new Context();
                return contexto.comentario_Cliente
                    .FromSqlRaw("exec sp_SelecionarComentarioCliente")
                    .ToList();
            }

            public void InserirComentarioCliente(comentario_Cliente comentario)
            {
                using var contexto = new Context();

                var parametros = new[]
                {
                new SqlParameter("@texto_cliente", comentario.texto_cliente ?? (object)DBNull.Value),
                new SqlParameter("@id_cliente", comentario.id_cliente),
                new SqlParameter("@data_comentario_cliente", comentario.data_comentario_cliente)
            };

                contexto.Database.ExecuteSqlRaw(
                    "exec sp_InserirComentarioCliente @texto_cliente, @id_cliente, @data_comentario_cliente",
                    parametros
                );
            }

            public void DeletarComentarioCliente(int idComentario)
            {
                using var contexto = new Context();

                var parametro = new SqlParameter("@id_comentario_cliente", idComentario);

                contexto.Database.ExecuteSqlRaw(
                    "exec sp_DeletarComentarioCliente @id_comentario_cliente",
                    parametro
                );
            }
        }
        }
    }



