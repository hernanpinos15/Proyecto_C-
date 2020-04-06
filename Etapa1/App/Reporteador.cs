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
        public IEnumerable<Escuela> GetListaEvaluaciones()
        {
            //var lista = _diccionario.GetValueOrDefault(LlaveDiccionario.Escuela);
            //return lista.Cast<Escuela>();
            IEnumerable<Escuela> rta;
            if (_diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                rta = lista.Cast<Escuela>();
            }else{
                rta = null;
            }

            return rta;
        }
    }
}