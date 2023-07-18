﻿using System;
using System.Collections.Generic;
using MyBank.Dominio.Entidades;

namespace MyBank.Dominio.Interfaces.Repositorios
{
    public interface IClienteRepositorio:IDisposable
    {
        public List<Cliente> ObterTodos();
        public Cliente ObterPorId(int id);
        public Cliente ObterPorGuid(Guid guid);
        public bool Adicionar(Cliente cliente);
        public bool Atualizar(int id,Cliente cliente);
        public bool Excluir(int id);

    }
}
