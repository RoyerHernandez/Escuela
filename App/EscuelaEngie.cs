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

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic,
                    bool imprimirEval = false)
        {
            foreach(var objDic in dic)
            {
                Printer.writeTitle(objDic.Key.ToString());
                foreach(var val in objDic.Value)
                {
                    
                    switch (objDic.Key)
                    {
                        case LlaveDiccionario.EVALUACION:
                                if(imprimirEval)
                                Console.WriteLine(val);
                        break;
                        case LlaveDiccionario.ESCUELA:
                                Console.WriteLine("Escuela :"+val);        
                        break;
                        case LlaveDiccionario.ALUMNO:
                                Console.WriteLine("Alumno : "+ val);
                        break;
                        case LlaveDiccionario.CURSO:
                            var curTmp = val as Curso;
                            if(curTmp != null)
                            { 
                                int count = curTmp.Alumnos.Count();
                                Console.WriteLine("Curso : "+ val + "Cantidad de Alumnos: " + count);
                            }
                        break;
                        default:
                        Console.WriteLine(val);
                        break;
                    }                        
                }
            }
        }
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {

            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            diccionario.Add(LlaveDiccionario.ESCUELA, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.CURSO, Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            var listatmp = new List<Evaluacion>();
            var listasig = new List<Asignatura>();
            var listalum = new List<Alumno>();

            foreach (var cur in Escuela.Cursos)
            {
                listasig.AddRange(cur.Asignaturas);
                listalum.AddRange(cur.Alumnos);       
                foreach (var alum in cur.Alumnos)
                {
                    listatmp.AddRange(alum.Evaluaciones);
                }                
            }
             diccionario.Add(LlaveDiccionario.ASIGNATURA, 
                                    listasig.Cast<ObjetoEscuelaBase>());
             diccionario.Add(LlaveDiccionario.ALUMNO,
                                    listalum.Cast<ObjetoEscuelaBase>());                           
             diccionario.Add(LlaveDiccionario.EVALUACION,
                                    listatmp.Cast<ObjetoEscuelaBase>());


            return diccionario;
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(

               bool traeEvaluaciones = true,
               bool traeAlumnos = true,
               bool traeAsignaturas = true,
               bool traeCursos = true
               )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(

               out int conteoEvaluaciones,
               bool traeEvaluaciones = true,
               bool traeAlumnos = true,
               bool traeAsignaturas = true,
               bool traeCursos = true
               )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(

               out int conteoEvaluaciones,
               out int conteoAlumnos,
               bool traeEvaluaciones = true,
               bool traeAlumnos = true,
               bool traeAsignaturas = true,
               bool traeCursos = true
               )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(

               out int conteoEvaluaciones,
               out int conteoAlumnos,
               out int conteAsignaturas,
               bool traeAlumnos = true,
               bool traeAsignaturas = true,
               bool traeCursos = true
               )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out conteAsignaturas, out int dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                out int conteoEvaluaciones,
                out int conteoAlumnos,
                out int conteAsignaturas,
                out int conteoCursos,
                bool traeEvaluaciones = true,
                bool traeAlumnos = true,
                bool traeAsignaturas = true,
                bool traeCursos = true
                )
        {
            conteoEvaluaciones = 0;
            conteAsignaturas = 0;
            conteoAlumnos = 0;
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);

            if (traeCursos)
                listaObj.AddRange(Escuela.Cursos);
            conteoCursos = Escuela.Cursos.Count;

            foreach (var curso in Escuela.Cursos)
            {
                if (traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);
                conteAsignaturas += curso.Asignaturas.Count;
                if (traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);
                conteoAlumnos += curso.Alumnos.Count;

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return listaObj.AsReadOnly();
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
                                Nota = MathF.Round((float)(5 * rnd.NextDouble())),
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