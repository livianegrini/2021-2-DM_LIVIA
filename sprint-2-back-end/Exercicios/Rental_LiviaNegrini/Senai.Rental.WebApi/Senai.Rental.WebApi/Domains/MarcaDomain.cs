﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) Marca
    /// </summary>
    public class MarcaDomain
    {
        public int IdMarca { get; set; }

        public string NomeMarca { get; set; }
    }
}
