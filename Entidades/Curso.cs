using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso: ObjetoEscuelaBase, ILugar
    {
        public TiposJornada jornada { get; set; }

        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        public string Direccion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void LimpiarLugar()
        {
            //throw new NotImplementedException();
        }
    }
}