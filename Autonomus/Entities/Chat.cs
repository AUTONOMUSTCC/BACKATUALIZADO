using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.Entities
{
    public class Chat
    {
        [Key]
        public int id_chat { get; set; }
        public string texto_chat { get; set; }
        public DateTime data_envio { get; set; }
        public int id_cliente { get; set; }
        public int id_prestador { get; set; }
    }

    public class NovoIdMensagemResultado
    {
        [Key]
        public decimal NovoIdMensagem { get; set; }
    }
}