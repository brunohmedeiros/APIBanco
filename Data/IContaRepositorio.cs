using System.Collections.Generic;

using APIRestBanco.Models;

namespace APIRestBanco.Data
{
    public interface IContaRepositorio
    {
        IEnumerable<ContaModel> GetAll();
        ContaModel Get(long Id);
        long Add(ContaModel Conta);
        long Delete(long Id);
        void Deposito(long Id, decimal ValorDep);
        bool Saque(long Id, decimal ValorSaq);
        decimal Saldo (long Id);
        void Bloqueio(long Id);
    }

}