using System.Collections.Generic;
using CoreEscuela.Entidades;
using System;
using System.Linq;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc)
        {
            if(dicObsEsc == null)
                throw new ArgumentNullException(nameof(dicObsEsc));
            _diccionario = dicObsEsc;
        }

        public IEnumerable<Escuela> GetListaEvaluacion ()
        {
            IEnumerable<Escuela> rta;
            if(_diccionario.TryGetValue( LlaveDiccionario.ESCUELA, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                rta = lista.Cast<Escuela>();
            }
            {
                rta = null;
            }
            return rta;
        }
    }
}