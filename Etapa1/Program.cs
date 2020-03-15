using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("HP ACADEMY",2012);
            escuela.Pais = "Ecuador";
            escuela.Ciudad = "Riobamba";
            escuela.TipoEscuela = TiposEscuela.Primaria;
            Console.WriteLine(escuela);
        }
    }
}
