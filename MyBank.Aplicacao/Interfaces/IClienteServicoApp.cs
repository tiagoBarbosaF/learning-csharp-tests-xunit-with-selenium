﻿using MyBank.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Aplicacao.DTO;

namespace MyBank.Aplicacao.Interfaces
{
    public interface IClienteServicoApp:IDisposable
    {        
        public List<ClienteDTO> ObterTodos();
        public ClienteDTO ObterPorId(int id);

        public ClienteDTO ObterPorGuid(Guid guid);
        public bool Adicionar(ClienteDTO cliente);
        public bool Atualizar(int id, ClienteDTO cliente);
        public bool Excluir(int id);
      
    }
}
