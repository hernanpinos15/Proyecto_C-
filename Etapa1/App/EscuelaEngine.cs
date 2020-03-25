using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    //sealed para que no exitan herencia pero si me permite crear instancias
    public sealed class EscuelaEngine
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

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int contEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            return GetObjetosEscuela(out contEvaluaciones, out int dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int contEvaluaciones,
            out int contAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            return GetObjetosEscuela(out contEvaluaciones, out contAlumnos, out int dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int contEvaluaciones,
            out int contAlumnos,
            out int contAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            return GetObjetosEscuela(out contEvaluaciones, out contAlumnos, out contAsignaturas, out int dummy);
        }

        //IReadOnlyList lista pero solo en modo lectura
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int contEvaluaciones,
            out int contAlumnos,
            out int contAsignaturas,
            out int contCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            contEvaluaciones = contAsignaturas = contAlumnos = 0;
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            if (traeCursos)
                listaObj.AddRange(Escuela.Cursos);

            contCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                contAsignaturas += curso.Asignaturas.Count;
                contAlumnos += curso.Alumnos.Count;
                if (traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);

                if (traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        contEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }

            }
            return listaObj.AsReadOnly();
        }


        #region Metodos de carga
        private void CargarEvaluaciones()
        {
            var lista = new List<Evaluacion>();
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
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
    #endregion
}