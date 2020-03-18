using System;
using System.Collections.Generic;
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

            /*
            Arreglos
            escuela.Cursos = new Curso[]{
                    new Curso(){ Nombre = "101"},
                    new Curso(){Nombre = "201"},
                    new Curso{Nombre = "301"}
            };
            */
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

            //Colecciones
            escuela.Cursos = new List<Curso>(){
                    new Curso(){ Nombre = "101", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                    new Curso{Nombre = "301", Jornada = TiposJornada.Mañana}
            };

            escuela.Cursos.Add(new Curso { Nombre = "102", Jornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso { Nombre = "202", Jornada = TiposJornada.Tarde });

            var otraColeccion = new List<Curso>(){
                    new Curso(){ Nombre = "401", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "501", Jornada = TiposJornada.Mañana},
                    new Curso{Nombre = "501", Jornada = TiposJornada.Tarde}
            };
            //otraColeccion.Clear();
            
            //Codigo para remove datos
            /*
            Curso tmp = new Curso { Nombre = "101-vACACION", Jornada = TiposJornada.Noche };
            escuela.Cursos.Add(tmp);
            WriteLine("Curso.Hash"+ tmp.GetHashCode());
            escuela.Cursos.Remove(tmp);
            */

            escuela.Cursos.AddRange(otraColeccion);
            ImprimirCursosEscuela(escuela);

            //Remover datos mediante los predicados declarando funcion
            /*
            Predicate<Curso> miAlgoritmo = Predicado;
            escuela.Cursos.RemoveAll(Predicado);
            */
            //Funcion con delegado
            escuela.Cursos.RemoveAll(delegate (Curso cur)
            {
                return cur.Nombre == "301";
            });
            //Expresiones lambda
            escuela.Cursos.RemoveAll((cur) => cur.Nombre == "501" && cur.Jornada == TiposJornada.Mañana);

            WriteLine("=======================");
            ImprimirCursosEscuela(escuela);

        }

        private static bool Predicado(Curso obj)
        {
            return obj.Nombre == "301";
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
