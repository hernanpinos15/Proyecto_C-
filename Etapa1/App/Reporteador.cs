using System;
using System.Collections.Generic;
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
        
    }
}