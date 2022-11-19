using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ies_301_WebApi.Handler
{
    public static class ValidarSenhaHandler
    {
        public static string Criptografar(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool validarHashes(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }

    }
}
