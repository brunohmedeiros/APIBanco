using System.Collections.Generic;
using System.Linq;
using System;

using APIRestBanco.Models;

namespace APIRestBanco.Data
{
    public class ContaRepositorio : IContaRepositorio
    {
        BancoContext _context;

        public ContaRepositorio(BancoContext context)
        {
            _context = context;
        }

        public ContaModel Get(long Id)
        {
            var conta = _context.Contas.FirstOrDefault(t => t.Idconta == Id);
            return conta;
        }

        public IEnumerable<ContaModel> GetAll()
        {
            return _context.Contas.ToList();;
        }

        public long Add(ContaModel Conta)
        {
            //Inserindo Data Atual
            Conta.DataCriacao = DateTime.Now;

            _context.Contas.Add(Conta);
            long contaID = _context.SaveChanges();
            return contaID;
        }

        public long Delete(long Id)
        {
            int contaID = 0;
            var conta = _context.Contas.FirstOrDefault(t => t.Idconta == Id);
            if (conta != null)
            {
                _context.Contas.Remove(conta);
                contaID = _context.SaveChanges();
            }
            return contaID;
        }
        public void Deposito (long Id, decimal ValorDep){
            var Conta = _context.Contas.Find(Id);

            //Verifica se conta não está bloqueada
            if (Conta != null && Conta.FlagAtivo == true)
            {
                Conta.Deposito(ValorDep);
                _context.SaveChanges();    
            }
        }

        public bool Saque (long Id, decimal ValorSaq){
            var Conta = _context.Contas.Find(Id);

            //Verifica se conta não está bloqueada
            if (Conta != null && Conta.FlagAtivo == true)
            {
                if (Conta.Saca(ValorSaq)){
                    _context.SaveChanges();  
                    return true;  
                }else{
                    return false;
                }
            } else {
                return false;
            }
        }

        public decimal Saldo (long Id){
            decimal ValorSaldo = 0;

            var Conta = _context.Contas.Find(Id);
            if (Conta != null)
            {
                ValorSaldo = Conta.Saldo;
            }

            return ValorSaldo;
        }

        public void Bloqueio(long Id){
            var Conta = _context.Contas.Find(Id);

            //Verifica se conta já está bloqueada
            if (Conta != null && Conta.FlagAtivo == true)
            {
                Conta.FlagAtivo = false;
                _context.SaveChanges();
            }    
        }
    }
}