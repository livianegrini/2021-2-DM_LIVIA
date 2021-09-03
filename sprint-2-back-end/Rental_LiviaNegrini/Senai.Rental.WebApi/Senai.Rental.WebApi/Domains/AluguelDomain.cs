using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) Aluguel
    /// </summary>
    public class AluguelDomain
    {
        public int IdAluguel { get; set; }

        public int IdCliente { get; set; }

        public int IdVeiculo { get; set; }

        public int Preco { get; set; }

        public DateTime  Data  { get; set; }

        public ClienteDomain Cliente { get; set; }

        public VeiculoDomain Veiculo { get; set; }
    }
}
