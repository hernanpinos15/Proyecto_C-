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

            //Arreglo de objetos
            var arregloCursos = new Curso[3];

            arregloCursos[0] = new Curso()
            {
                Nombre = "101",
            };

            var curso2 = new Curso()
            {
                Nombre = "201",
            };
            arregloCursos[1] = curso2;

            arregloCursos[2] = new Curso
            {
                Nombre = "301",
            };


            Console.WriteLine(escuela);
            //cw
            System.Console.WriteLine("====================");
            ImprimirCursos(arregloCursos);
        }

        private static void ImprimirCursos(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
                contador++;
            }
        }
    }
}
