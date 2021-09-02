using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) Empresa
    /// </summary>
    public class EmpresaDomain
    {
        public int IdEmpresa { get; set; }

        public string NomeEmpresa { get; set; }
    }
}
