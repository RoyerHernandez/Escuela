using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string uniqueId { get ; private set; }
        public string nombre { get; set; }

        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
        public Alumno() => uniqueId = Guid.NewGuid().ToString();        
    }
}