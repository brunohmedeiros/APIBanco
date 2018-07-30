using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System;

namespace APIRestBanco.Models
{
    [Table("contas")]
    public class ContaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idconta")]
        public long Idconta {get;set;}   
    
        [Column("idpessoa")]
        public long IdPessoa {get;set;}

        /*
        * Saldo da conta deve ser alterado apenas nos métodos Deposito e Saque
        */
        [Column("saldo")]
        public decimal Saldo {get;private set;}

        [Column("limitesaquediario")]
        public decimal LimiteSaqueDiario {get;set;}

        [Column("flagativo")]
        [DefaultValue(true)]
        public bool FlagAtivo {get;set;}

        [Column("tipoconta")]
        public int TipoConta {get;set;}

        [Column("datacriacao")]
        [DataType(DataType.Date)]
        public DateTime DataCriacao {get;set;}

        public void Deposito(decimal ValorDep){
            this.Saldo += ValorDep;
        }

        public bool Saca (decimal ValorSaq){
            if (this.Saldo >= ValorSaq){
                this.Saldo -= ValorSaq;
                return true;
            } else {
                return false;
            }
        }
    }

}