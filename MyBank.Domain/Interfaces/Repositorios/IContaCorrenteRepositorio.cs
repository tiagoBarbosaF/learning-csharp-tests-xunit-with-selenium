using System;
using System.Collections.Generic;
using MyBank.Dominio.Entidades;

namespace MyBank.Dominio.Interfaces.Repositorios
{
    public interface IContaCorrenteRepositorio:IDisposable
    {
        public List<ContaCorrente> ObterTodos();
        public ContaCorrente ObterPorId(int id);
        public ContaCorrente ObterPorGuid(Guid guid);
        public bool Adicionar(ContaCorrente conta);
        public bool Atualizar(int id, ContaCorrente conta);
        public bool Excluir(int id);
    }
}
