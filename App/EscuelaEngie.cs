using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela.Entidades
{
    public sealed class EscuelaEngie
    {
        public Escuela Escuela { get; set; }
        public EscuelaEngie()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Bogotá");

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela()
        {
                var listaObj = new List<ObjetoEscuelaBase>();
                    listaObj.Add(Escuela);
                    listaObj.AddRange(Escuela.Cursos);
                    foreach(var curso in Escuela.Cursos)
                    {
                        listaObj.AddRange(curso.Asignaturas);
                        listaObj.AddRange(curso.Alumnos);
                            foreach(var alumno in curso.Alumnos)
                            {
                                listaObj.AddRange(alumno.Evaluaciones);
                            }

                    }

                return listaObj;
        }

        #region Métodos de Carga

        private void CargarEvaluaciones()
        {            
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                nombre = $"{asignatura.nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);                            
                        }
                    }
                }
            }

        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Juan", "Camilo", "Andres", "Andrea", "Karen", "Karla", "Ximena" };
            string[] apellido = { "Arciniegas", "Teeran", "Uribe", "Gacha", "Macri", "Quintero", "Lopez" };
            string[] nombre2 = { "Esteban", "Carlos", "Felipe", "Ana", "Lauren", "Bruno", "Catalina" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido
                               select new Alumno { nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.uniqueId).Take(cantidad).ToList();

        }
        private void CargarAsignaturas()
        {
            foreach (var Curso in Escuela.Cursos)
            {
                var ListaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura{ nombre = "Matematicas" },
                    new Asignatura{ nombre = "Educación Fisica" },
                    new Asignatura{ nombre = "Castellano" },
                    new Asignatura{ nombre = "Ciencias Naturales" },
                    new Asignatura{ nombre = "Ingles" }
                };
                Curso.Asignaturas = ListaAsignaturas;
            }
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                 new Curso() {nombre = "101", jornada = TiposJornada.Mañana},
                 new Curso() {nombre = "201", jornada = TiposJornada.Mañana},
                 new Curso() {nombre = "301", jornada = TiposJornada.Mañana},
                 new Curso() {nombre = "401", jornada = TiposJornada.Tarde},
                 new Curso() {nombre = "501", jornada = TiposJornada.Tarde},
            };

            Random rnd = new Random();

            foreach (var c in Escuela.Cursos)
            {

                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
    }

        #endregion


}