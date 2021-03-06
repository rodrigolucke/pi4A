﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CryptSharp;

namespace f12020.Models
{
    public static class Criptografia
    {
        public static string Codifica(string senha)
        {
            return Crypter.MD5.Crypt(senha);
        }

        public static bool Compara(string senhaDigitada, string senhaUsuario)
        {
            return Crypter.CheckPassword(senhaDigitada, senhaUsuario);
        }
    }
}