using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("HP ACADEMY", 2012,
                    TiposEscuela.Primaria,
                    pais: "Ecuador", ciudad: "Riobamba");
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            throw new NotImplementedException();
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                                new Asignatura{Nombre="Matemáticas"},
                                new Asignatura{Nombre="Educación Física"},
                                new Asignatura{Nombre="Castellano"},
                                new Asignatura{Nombre="Cienicas Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Steven", "Fernanda", "Arturo", "Melisa", "Jorge", "Andrea", "Maurico", "Valeria", "Antonio", "Pepe" };
            string[] nombre2 = { "Juan", "Antonio", "Felipe", "Johana", "Anai", "Emely", "Elizabeth", "Erika", "Carlos", "Alberto" };
            string[] apellido1 = { "Perez", "Guayas", "Espejo", "Ambato", "Ruiz", "Maduro", "Toledo", "Hernandez", "Uribe", "Pingos" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                    new Curso(){ Nombre = "101", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                    new Curso{Nombre = "301", Jornada = TiposJornada.Mañana},
                    new Curso(){ Nombre = "401", Jornada = TiposJornada.Tarde},
                    new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde},
            };
            Random rnd = new Random();
            foreach (var c in Escuela.Cursos)
            {
                int cantidadRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantidadRandom);
            }
        }
    }
}