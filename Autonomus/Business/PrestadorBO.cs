using Autonomus.Entities;
using Microsoft.EntityFrameworkCore;
using Autonomus.ContextNameSpace;
using Microsoft.Data.SqlClient;
namespace Autonomus.Business
{
    public class PrestadorBO
    {

            public List<Prestador> ObterPrestador()
            {
                Context contexto = new Context();
                var resultado = contexto.Prestador.FromSqlRaw("exec sp_SelecionarPrestador");
                return resultado.ToList();

            }

            public static decimal InserirPrestador(Prestador prestador)
            {
                Context contexto = new Context();
                var parametros = new[]
                {
                new SqlParameter("@NomePrestador", prestador.NomePrestador ?? (object)DBNull.Value),
                new SqlParameter("@SobrenomePrestador", prestador.SobrenomePrestador ?? (object)DBNull.Value),
                new SqlParameter("@TelefonePrestador", prestador.TelefonePrestador ?? (object)DBNull.Value),
                new SqlParameter("@EmailPrestador", prestador.EmailPrestador ?? (object)DBNull.Value),
                new SqlParameter("@GeneroPrestador", prestador.GeneroPrestador ?? (object)DBNull.Value),
                new SqlParameter("@CidadePrestador", prestador.CidadePrestador ?? (object)DBNull.Value),
                new SqlParameter("@DataNascimentoPrestador", prestador.DataNascimentoPrestador),
                new SqlParameter("@AvaliacaoPrestador", prestador.AvaliacaoPrestador),
                new SqlParameter("@SenhaPrestador", prestador.SenhaPrestador ?? (object)DBNull.Value)
            };

                var resultado = contexto
                .Set<NovoPrestadorResultado>()
                .FromSqlRaw("EXEC sp_InserirPrestador @NomePrestador, @SobrenomePrestador, @TelefonePrestador, @EmailPrestador, @GeneroPrestador, @CidadePrestador, @DataNascimentoPrestador, @AvaliacaoPrestador, @SenhaPrestador", parametros)
                .AsEnumerable().FirstOrDefault();

                return resultado.NovoIdPrestador;
            }

            public void DeletarPrestador(int idPrestador)
            {
                var contexto = new Context();
                var parametros = new[]
                {
                new SqlParameter("@IdPrestador", idPrestador)
            };

                contexto.Database.ExecuteSqlRaw("EXEC dboDeletarPrestador @IdPrestador", parametros);
            }

            public static void AtualizarPrestador(Prestador prestador)
            {
                Context contexto = new Context();
                var parametros = new[]
                {
                new SqlParameter("@NomePrestador", prestador.NomePrestador ?? (object)DBNull.Value),
                new SqlParameter("@SobrenomePrestador", prestador.SobrenomePrestador ?? (object)DBNull.Value),
                new SqlParameter("@TelefonePrestador", prestador.TelefonePrestador ?? (object)DBNull.Value),
                new SqlParameter("@EmailPrestador", prestador.EmailPrestador ?? (object)DBNull.Value),
                new SqlParameter("@GeneroPrestador", prestador.GeneroPrestador ?? (object)DBNull.Value),
                new SqlParameter("@DataNascimentoPrestador", prestador.DataNascimentoPrestador),
                new SqlParameter("@AvaliacaoPrestador", prestador.AvaliacaoPrestador),
                new SqlParameter("@SenhaPrestador", prestador.SenhaPrestador  ?? (object)DBNull.Value),
                new SqlParameter("@idPrestador", prestador.IdPrestador)
            };

                contexto.Database.ExecuteSqlRaw("EXEC sp_UpdatePrestador @NomePrestador, @SobrenomePrestador, @TelefonePrestador, @EmailPrestador, @GeneroPrestador, @DataNascimentoPrestador, @AvaliacaoPrestador, @SenhaPrestador, @idPrestador", parametros);
            }

             public List<Prestador> ObterPrestadorPorRating(decimal avaliacaominima, decimal avaliacaomaxima)
             {
            Context contexto = new Context();
            var parametros = new[]
            {
            new SqlParameter("@MinAvaliacao", avaliacaominima),
            new SqlParameter("@MaxAvaliacao", avaliacaomaxima),
            };

            
            var resultado = contexto.Prestador.FromSqlRaw("exec sp_FiltrarPrestadorAvaliacao @MinAvaliacao, @MaxAvaliacao", parametros).ToList();

            return resultado;
        }

        public List<Prestador> FiltrarPrestadores(string? nomePrestador)
        {
            using var contexto = new Context();
            var parametro = new SqlParameter("@NomePrestador",
                               string.IsNullOrEmpty(nomePrestador) ? DBNull.Value : nomePrestador);

            var resultado = contexto.Prestador
                .FromSqlRaw("EXEC sp_FiltrarPrestadores @NomePrestador", parametro)
                .ToList();

            return resultado;
        }

        public List<Prestador> FiltrarPorCidade(string? cidade)
        {
            using var contexto = new Context();
            var parametro = new SqlParameter("@CidadePrestador",
                               string.IsNullOrEmpty(cidade) ? DBNull.Value : cidade);

            var resultado = contexto.Prestador
                .FromSqlRaw("EXEC sp_FiltrarPrestadorCidade @CidadePrestador", parametro)
                .AsNoTracking()
                .ToList();

            return resultado;
        }
        public class ComentarioPBO
        {
                public List<comentario_Prestador> ObterComentarioPrestador()
                {
                    using var contexto = new Context();
                    return contexto.comentario_Prestador
                                   .FromSqlRaw("EXEC sp_SelecionarComentarioPrestador")
                                   .ToList();
                }

                public void InserirComentarioPrestador(comentario_Prestador comentario)
                {
                    using var contexto = new Context();

                    var parametros = new object[]
                    {
                new SqlParameter("@texto_prestador", (object?)comentario.texto_prestador ?? DBNull.Value),
                new SqlParameter("@id_prestador", comentario.id_prestador),
                new SqlParameter("@data_comentario_prestador", comentario.data_comentario_prestador)
                    };
                    contexto.Database.ExecuteSqlRaw(
                        "EXEC sp_InserirComentarioPrestador @texto_prestador, @id_prestador, @data_comentario_prestador",
                        parametros
                    );
                }

                public void DeletarComentarioPrestador(int idComentarioP)
                {
                    using var contexto = new Context();
                    var parametro = new SqlParameter("@id_comentario_prestador", idComentarioP);

                    contexto.Database.ExecuteSqlRaw(
                        "EXEC sp_DeletarComentarioPrestador @id_comentario_prestador",
                        parametro
                    );
                }
            }
    }
}


