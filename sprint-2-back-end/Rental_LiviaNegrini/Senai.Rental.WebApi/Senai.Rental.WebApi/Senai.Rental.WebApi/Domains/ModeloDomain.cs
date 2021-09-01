using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class ModeloDomain 
    {
        public int IdModelo { get; set; }

        public string NomeModelo { get; set; }

        public int IdMarca { get; set; }

        public MarcaDomain Marca { get; set; }
    }
}

//modelodomain modelo = new modelodomain()...
//{
//    IdModelo = valor,
//    NomeModelo = valor,
//    NomeMarca = valor   X
//    Marca = new MarcaDomain
//    {
        
//    }
    
//}