﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Infraestrutura.Testes.DTO
{
    public class PixDTO
    {
        private Guid chave;
        private double saldo;
        public Guid Chave { get => chave; set => chave = value; }
        public double Saldo { get => saldo; set => saldo = value; }
    }
}
