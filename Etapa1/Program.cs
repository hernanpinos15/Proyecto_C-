using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {

            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            Printer.Beep(10000, cantidad: 10);
            ImprimirCursosEscuela(engine.Escuela);

            //var obk = new ObjetoEscuelaBase();

        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {

            Printer.WriteTitle("Cursos de la escuela");
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
}
