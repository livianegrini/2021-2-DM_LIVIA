using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_Filmes_WebAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) GENERO
    /// </summary>
    public class GeneroDomain
    {
        public int idGenero { get; set; }

        public string nomeGenero { get; set; }
    }
}
