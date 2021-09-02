using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) Cliente
    /// </summary>
    public class ClienteDomain
    {
        public int IdCliente { get; set; }

        public string NomeCliente { get; set; }

        public string SobrenomeCliente { get; set; }

        public int CPF { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
