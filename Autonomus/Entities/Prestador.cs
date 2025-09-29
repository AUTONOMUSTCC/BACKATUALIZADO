using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.Entities
{
    public class Prestador
    {
        [Column("id_prestador")]
        [Key]
        public int IdPrestador { get; set; }
        [Column("nome_prestador")]
        public required string NomePrestador { get; set; }
        [Column("sobrenome_prestador")]
        public required string SobrenomePrestador { get; set; }
        [Column("tel_prestador")]
        public required string TelefonePrestador { get; set; }
        [Column("genero_prestador")]
        public required string GeneroPrestador { get; set; }
        [Column("email_prestador")]
        public required string EmailPrestador { get; set; }
        [Column("data_nasc_prestador")]
        public DateTime DataNascimentoPrestador { get; set; }
        [Column("cidade_prestador")]
        public required string CidadePrestador { get; set; }
        [Column("avaliacao_prestador")]
        public decimal AvaliacaoPrestador { get; set; }
        [Column("senha_prestador")]
        public required string SenhaPrestador { get; set; }
    }
}
