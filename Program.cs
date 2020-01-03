using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela.Entidades
{
    class Program
    {
        static void Main(string[] args)
        {
            var engie = new EscuelaEngie();
            engie.Inicializar();
            Printer.writeTitle("Bienvenidos a la Escuela");
            Printer.Beep(10000, cantidad: 10);
            imprimirCursosEscuela(engie.Escuela);
            var listaObjetos = engie.GetObjetosEscuela(traeEvaluaciones : false);

        }

        private static int PredicadoMalHecho(Curso curobj)
        {
            return 301;
        }

        private static void imprimirCursosEscuela(Escuela escuela)
        {

            Printer.writeTitle("Cursos de la Escuela");


            if (escuela?.Cursos != null)
            {
                foreach (var cursos in escuela.Cursos)
                {
                    foreach (var asignatura in cursos.Asignaturas)
                    {
                        foreach (var estudiante in cursos.Alumnos)
                        {                            
                            WriteLine($"Nombre : {cursos.nombre}, id : {cursos.uniqueId}, asignatura : {asignatura.nombre}, estudiante : {estudiante.nombre}");                        
                        }
                    }
                }
            }
            else
            {
                return;
            };
        }

    }
}