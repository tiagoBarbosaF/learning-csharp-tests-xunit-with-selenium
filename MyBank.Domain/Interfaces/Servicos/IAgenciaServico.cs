using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Dominio.Entidades;

namespace MyBank.Dominio.Interfaces.Servicos
{
    public interface IAgenciaServico:IDisposable
    {
        public List<Agencia> ObterTodos();
        public Agencia ObterPorId(int id);
        public Agencia ObterPorGuid(Guid guid);
        public bool Adicionar(Agencia agencia);
        public bool Atualizar(int id, Agencia agencia);
        public bool Excluir(int id);
    }
}
