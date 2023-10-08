using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public class Validation
    {
        public static void ValidarSeVazio(string valor, string mensagem)
        {
            if (valor == null || valor.Trim().Length == 0)
            {
                throw new Exception(mensagem);
            }
        }

        public static void ValidarSeNulo(object object1, string mensagem)
        {
            if (object1 == null)
            {
                throw new Exception(mensagem);
            }
        }

        public static void ValidarTamanho(string valor, int minimo, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length < minimo || length > maximo)
            {
                throw new Exception(mensagem);
            }
        }
    }
}
