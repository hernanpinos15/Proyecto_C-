using System;
using CoreEscuela.Entidades;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("HP ACADEMY", 2012,
                                    TiposEscuela.Primaria,
                                    pais: "Ecuador", ciudad: "Riobamba");
            escuela.Cursos = new Curso[]{
                    new Curso(){ Nombre = "101"},
                    new Curso(){Nombre = "201"},
                    new Curso{Nombre = "301"}
            };

            escuela.Cursos = null;
            //Arreglo de objetos
            /*
            var arregloCursos = new Curso[3]{
                            new Curso(){ Nombre = "101"},
                            new Curso(){Nombre = "201"},
                            new Curso{Nombre = "301"}
            };
            
            Curso[] arregloCursos = {
                            new Curso(){ Nombre = "101"},
                            new Curso(){Nombre = "201"},
                            new Curso{Nombre = "301"}
            };
            //cw
            Console.WriteLine(escuela);
            System.Console.WriteLine("====================");
            ImprimirCursosWhile(arregloCursos);
            System.Console.WriteLine("====================");
            ImprimirCursosDoWhile(arregloCursos);
            System.Console.WriteLine("====================");
            ImprimirCursosFor(arregloCursos);
            System.Console.WriteLine("====================");
            ImprimirCursosForEach(arregloCursos);
            */

            ImprimirCursosEscuela(escuela);
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("===================================");
            WriteLine("Cursos de la escuela");
            WriteLine("===================================");
            //if (escuela != null && escuela.Cursos != null)
            if (escuela?.Cursos != null)
                {
                    foreach (var curso in escuela.Cursos)
                    {
                        WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
                    }
                }
            }
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
                contador++;
            }
        }
        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            do
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
                contador++;
            } while (contador < arregloCursos.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre {arregloCursos[i].Nombre}, Id {arregloCursos[i].UniqueId}");
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var Curso in arregloCursos)
            {
                Console.WriteLine($"Nombre {Curso.Nombre}, Id {Curso.UniqueId}");
            }
        }
    }
}
