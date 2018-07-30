using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIRestBanco.Models
{
    [Table("transacoes")]
    public class TransacaoModel {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idtransacao")]
        public long IdTransacao{get;set;}

        [Column("idconta")]
        public long IdConta{get;set;}

        [Column("valor")]
        public decimal Valor{get;set;}

        [Column("datatransacao")]
        [DataType(DataType.Date)]
        public DateTime DataTransacao{get;set;}

    }
}