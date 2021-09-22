using senai_gufi_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
    }
}
