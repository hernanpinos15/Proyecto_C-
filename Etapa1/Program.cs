using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("HP ACADEMY", 2012,
                                    TiposEscuela.Primaria,
                                    pais: "Ecuador", ciudad: "Riobamba");
            Console.WriteLine(escuela);
        }
    }
}
