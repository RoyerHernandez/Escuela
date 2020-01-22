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

        public IEnumerable<Evaluacion> GetListaEvaluacion ()
        {            
            if(_diccionario.TryGetValue( LlaveDiccionario.EVALUACION, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
            }
           
        }


            public IEnumerable<string> GetListaAsignaturas ()
        {

            return GetListaAsignaturas(
                    out var dummy);

        }


         public IEnumerable<string> GetListaAsignaturas (
             out IEnumerable<Evaluacion> ListaEvaluacion)
        {        

            ListaEvaluacion = GetListaEvaluacion();    

            return (from ev in ListaEvaluacion                
                        select ev.Asignatura.nombre).Distinct();;

           
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluacionesXAsigna()
        {
            var dicRta = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsig = GetListaAsignaturas(out var ListaEval);

            foreach(var asig in listaAsig)
            {
                var evalAsig = from eval in ListaEval
                                   where eval.Asignatura.nombre == asig 
                                    select eval ;
                dicRta.Add(asig,evalAsig);
            }
            return dicRta;
        }


    }
}