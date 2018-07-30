using Microsoft.EntityFrameworkCore;

using APIRestBanco.Models;

namespace APIRestBanco.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options)
            : base(options)
        {}

        public DbSet<ContaModel> Contas {get;set;}
        public DbSet<PessoaModel> Pessoas {get;set;}
        public DbSet<TransacaoModel> Transacoes {get;set;}
    }
}
