using System;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string uniqueId { get ; private set; }
        public string nombre { get; set; }

        public Alumno() => uniqueId = Guid.NewGuid().ToString();        
    }
}