﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.Entities
{
    public class Cliente
    {
        [Column("id_cliente")]
        [Key]
        public int IdCliente { get; set; }
        [Column("nome_cliente")]
        public required string NomeCliente { get; set; }
        [Column("sobrenome_cliente")]
        public required string SobrenomeCliente { get; set; }
        [Column("tel_cliente")]
        public required string TelefoneCliente { get; set; }
        [Column("email_cliente")]
        public required string EmailCliente { get; set; }
        [Column("genero_cliente")]
        public required string GeneroCliente { get; set; }
        [Column("data_nasc_cliente")]
        public DateTime DataNascimentoCliente { get; set; }
        [Column("cidade_cliente")]
        public required string CidadeCliente { get; set; }
        [Column("avaliacao_cliente")]
        public decimal AvaliacaoCliente { get; set; }
        [Column("senha_cliente")]
        public required string SenhaCliente { get; set; }

    }
}
