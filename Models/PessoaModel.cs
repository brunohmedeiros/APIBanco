using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace APIRestBanco.Models
{

    [Table("pessoas")]
    public class PessoaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idpessoa")]
        public long IdPessoa {get;set;}
        
        [Column("nome")]
        public string Nome {get;set;}

        [Column("cpf")]
        public string Cpf {get;set;}

        [Column("datanascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento {get;set;}

    }

}