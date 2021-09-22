using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) Veiculo
    /// </summary>
    public class VeiculoDomain
    {
        public int IdVeiculo { get; set; }

        public int IdEmpresa { get; set; }

        public string Placa { get; set; }

        public int IdModelo { get; set; }

        public EmpresaDomain Empresa { get; set; }

        public ModeloDomain Modelo { get; set; }


    }
}
