using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
 
using APIRestBanco.Models;
using APIRestBanco.Data;

namespace APIRestBanco.Controllers
{
    [Route("api/[controller]")]
    public class ContaController : Controller
    {

        private IContaRepositorio _IRepoC;
        private ITransacaoRepositorio _IRepoT;

        public ContaController(IContaRepositorio repositorioConta, ITransacaoRepositorio repositorioTransacao){
            _IRepoC = repositorioConta;
            _IRepoT = repositorioTransacao;
        }

        // GET conta/values
        [HttpGet]
        public IEnumerable<ContaModel> Get()
        {
            return _IRepoC.GetAll();
        }

        // GET conta/extrato/values
        [HttpGet("extrato/{id}/{dtInicio}/{dtFim}")]
        public IEnumerable<TransacaoModel> Extrato(long Id, string dtInicio, string dtFim)
        {
            DateTime dtInicio_Date, dtFim_Date;
            DateTime.TryParseExact(dtInicio, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtInicio_Date);
            DateTime.TryParseExact(dtFim, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtFim_Date);
            
            return _IRepoT.GetAll(Id,dtInicio_Date, dtFim_Date);
        }

        // GET conta/values/5
        [HttpGet("{id}")]
        public ContaModel Get(long id)
        {
            return _IRepoC.Get(id);
        }

        // GET conta/saldo/values/5
        [HttpGet("saldo/{id}")]
        public decimal Saldo(long id)
        {
            return _IRepoC.Saldo(id);
        }

        // POST conta/values
        [HttpPost]
        public void Post([FromForm]ContaModel value)
        {
            _IRepoC.Add(value);
        }

        // DELETE conta/values/5
        [HttpDelete("{id}")]
        public void Delete(int Id)
        {
            _IRepoC.Delete(Id);
        }

        // Patch conta/deposito/values/5
        [HttpPatch("deposito/{id}")]
        public void Deposito(int Id, [FromForm]decimal vlDeposito)
        {
            TransacaoModel Transacao = new TransacaoModel();
            
            _IRepoC.Deposito(Id, vlDeposito);

            Transacao.IdConta = Id;
            Transacao.DataTransacao = DateTime.Now;
            Transacao.Valor = + vlDeposito;
            _IRepoT.Add(Transacao);
        }

        // Patch saque/saca/values/5
        [HttpPatch("saque/{id}")]
        public void Saque(int Id, [FromForm]decimal vlSaque)
        {
            if (_IRepoC.Saque(Id, vlSaque)){
                TransacaoModel Transacao = new TransacaoModel();

                Transacao.IdConta = Id;
                Transacao.DataTransacao = DateTime.Now;
                Transacao.Valor = - vlSaque;
                _IRepoT.Add(Transacao);
            }
        }

        // Head conta/bloqueio/values/5
        [HttpHead("bloqueio/{id}")]
        public void Bloqueio(int Id)
        {
            _IRepoC.Bloqueio(Id);
        }
    }
}
