﻿using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {

            //Event = dispara las acciones
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(2000, 1000, 1);
            AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento;

            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            //Printer.Beep(10000, cantidad: 10);
            //ImprimirCursosEscuela(engine.Escuela);

            //var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var reporteador = new Reporteador(null);




            /*
            //Obtener los objetos mediante una lista
            var listaObjetos = engine.GetObjetosEscuela();
            */

            /*
            //Obtener los objetos mediante un diccionario
            var dictmp = engine.GetDiccionarioObjetos();
            engine.ImprimirDiccionario(dictmp, true);
            */

            /*
            //Implementacion de diccionarios
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
            */

            /*
            //Interfaces
            var ListaILugar = from obj in listaObjetos
                            where obj is ILugar 
                              select (ILugar)obj;
            */

            /*
            //is para preguntar si un objeto es de un tipo determinado
            if (ob is Alumno)
            {
                Alumno alumnoRecuperado = (Alumno)ob;
            }
            //as tomar el objeto de cual estamos refiriendonos
            Alumno alumnoRecuperado2 = ob as Alumno;
            */

        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(3000, 1000, 3);
            Printer.WriteTitle("SALIO");
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
