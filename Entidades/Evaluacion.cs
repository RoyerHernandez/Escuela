using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion : ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public Double Nota { get; set; }

        public override string ToString(){
            return $"{Nota},{Alumno.nombre},{Asignatura.nombre}";
        }
 
    }
}