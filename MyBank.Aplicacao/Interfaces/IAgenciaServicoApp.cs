using MyBank.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Aplicacao.DTO;

namespace MyBank.Aplicacao.Interfaces
{
    public interface IAgenciaServicoApp:IDisposable
    {
        public List<AgenciaDTO> ObterTodos();
        public AgenciaDTO ObterPorId(int id);
        public AgenciaDTO ObterPorGuid(Guid guid);
        public bool Adicionar(AgenciaDTO agencia);
        public bool Atualizar(int id, AgenciaDTO agencia);
        public bool Excluir(int id);
    }
}
