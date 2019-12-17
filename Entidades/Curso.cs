using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public string uniqueId { get ; private set; }
        public string nombre { get; set; }
        public TiposJornada jornada { get; set; }

        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        public Curso() => uniqueId = Guid.NewGuid().ToString();        

    }
}