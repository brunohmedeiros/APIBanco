using System.Collections.Generic;
using System;

using APIRestBanco.Models;

namespace APIRestBanco.Data
{
    public interface ITransacaoRepositorio
    {
        IEnumerable<TransacaoModel> GetAll(long IdConta, DateTime DataInicio, DateTime DataFim);
        long Add(TransacaoModel Transacao);
    }

}