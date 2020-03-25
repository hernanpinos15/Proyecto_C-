using System;
using System.Collections.Generic;
using System.Linq;
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
            //Printer.Beep(10000, cantidad: 10);
            ImprimirCursosEscuela(engine.Escuela);
            var listaObjetos = engine.GetObjetosEscuela();
            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "Pepito");
            diccionario.Add(20, "Loren");
            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key} Valor: {keyValPair.Value}");
            }
            Printer.WriteTitle("Acceso a Diccionario");
            diccionario[0] = "Juanito";
            WriteLine(diccionario[0]);
            Printer.WriteTitle("Otro Diccionario");
            var dic = new Dictionary<string, string>();
            dic["Luna"] = "Cuerpo celeste que gira alrededor de la tierra";
            WriteLine(dic["Luna"]);
            dic["Luna"] = "Protagonista de Soy Luna";
            WriteLine(dic["Luna"]);


            /*
            //Interfaces
            var ListaILugar = from obj in listaObjetos
                            where obj is ILugar 
                              select (ILugar)obj;
            */

            /*
            //var obk = new ObjetoEscuelaBase();
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Puebas de Polimorfismo");

            var alumnoTest = new Alumno { Nombre = "Pepito Espejo" };
            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            var objDummy = new ObjetoEscuelaBase() { Nombre = "Juanito Espejo" };
            Printer.WriteTitle("ObjetoEscuelaBase");
            WriteLine($"Alumno: {objDummy.Nombre}");
            WriteLine($"Alumno: {objDummy.UniqueId}");
            WriteLine($"Alumno: {objDummy.GetType()}");

            var evaluacion = new Evaluacion() { Nombre = "Matematicas", Nota = 4.5f };
            Printer.WriteTitle("Evaluacion");
            WriteLine($"Evaluacion: {evaluacion.Nombre}");
            WriteLine($"Evaluacion: {evaluacion.UniqueId}");
            WriteLine($"Evaluacion: {evaluacion.Nota}");
            WriteLine($"Evaluacion: {evaluacion.GetType()}");

            //ob = evaluacion;
            //is para preguntar si un objeto es de un tipo determinado
            if (ob is Alumno)
            {
                Alumno alumnoRecuperado = (Alumno)ob;
            }

            //as tomar el objeto de cual estamos refiriendonos
            Alumno alumnoRecuperado2 = ob as Alumno;
            */

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
