using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_Filmes_WebAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) FILME
    /// </summary>
    public class FilmeDomain 
    {
        public int IdFilme { get; set; }

        public int IdGenero { get; set; }

        public string TituloFilme { get; set; }

        public GeneroDomain Genero { get; set; }
    }
}
