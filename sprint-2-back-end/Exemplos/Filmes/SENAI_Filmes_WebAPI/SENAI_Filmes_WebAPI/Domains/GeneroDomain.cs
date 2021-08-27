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
        public int IdGenero { get; set; }

        public string NomeGenero { get; set; }
    }
}
