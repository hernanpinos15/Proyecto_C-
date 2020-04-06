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
            var listaEvaluaciones = GetListaEvaluaciones();


            return (from Evaluacion ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();

            /*
            return from Evaluacion ev in listaEvaluaciones
                   where ev.Nota >= 3.0f
                   select ev.Asignatura;
            */
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDiccionarioEvaluacionXAsig()
        {
            var dictRta = new Dictionary<string, IEnumerable<Evaluacion>>();
            return dictRta;
        }
    }
}