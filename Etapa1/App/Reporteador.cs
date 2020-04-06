using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEs)
        {
            if (dicObsEs == null)
                throw new ArgumentException(nameof(dicObsEs));
            _diccionario = dicObsEs;
        }

        //IEnumerable = lista generica
        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
            }
        }
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }
        public IEnumerable<string> GetListaAsignaturas(
            out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluacion ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDiccionarioEvalXAsig()
        {
            var dictRta = new Dictionary<string, IEnumerable<Evaluacion>>();
            var listaAsig = GetListaAsignaturas(out var listaEval);
            foreach (var asig in listaAsig)
            {
                var evalsAsig = from Evaluacion eval in listaEval
                                where eval.Asignatura.Nombre == asig
                                select eval;
                dictRta.Add(asig, evalsAsig);
            }

            return dictRta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromedioAlumnoPorAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalXAsig = GetDiccionarioEvalXAsig();

            foreach (var asigConEval in dicEvalXAsig)
            {
                var promsAlumn = from Evaluacion eval in asigConEval.Value
                                 group eval by new
                                 {
                                     eval.Alumno.UniqueId,
                                     eval.Alumno.Nombre
                                 }
                                into grupoEvalAlumno
                                 select new AlumnoPromedio
                                 {
                                     alumnoId = grupoEvalAlumno.Key.UniqueId,
                                     alumnoNombre = grupoEvalAlumno.Key.Nombre,
                                     promedio = grupoEvalAlumno.Average(evaluacion => evaluacion.Nota)
                                 };
                rta.Add(asigConEval.Key, promsAlumn);
            }
            return rta;
        }
    }
}