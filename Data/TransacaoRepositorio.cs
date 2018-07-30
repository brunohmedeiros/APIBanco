using System.Collections.Generic;
using System.Linq;
using System;

using APIRestBanco.Models;

namespace APIRestBanco.Data
{
    public class TransacaoRepositorio : ITransacaoRepositorio
    {
        BancoContext _context;

        public TransacaoRepositorio(BancoContext context)
        {
            _context = context;
        }

        public IEnumerable<TransacaoModel> GetAll(long IdConta, DateTime DataInicio, DateTime DataFim)
        {
            return _context.Transacoes.Where(x => x.DataTransacao >= DataInicio & x.DataTransacao <= DataFim & x.IdConta == IdConta).ToList();
        }

        public long Add(TransacaoModel Transacao)
        {
            _context.Transacoes.Add(Transacao);
            long TransacaoID = _context.SaveChanges();
            return TransacaoID;
        }
    }
}