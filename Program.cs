﻿using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela.Entidades
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o,s)=> Printer.Beep(2000,1000,1);

            var engie = new EscuelaEngie();
            engie.Inicializar();
            Printer.writeTitle("Bienvenidos a la Escuela");
            //Printer.Beep(10000, cantidad: 10);
            //imprimirCursosEscuela(engie.Escuela);
            //var dictmp = engie.GetDiccionarioObjetos();
            //engie.ImprimirDiccionario(dictmp,true);

            var reporteador = new Reporteador(engie.GetDiccionarioObjetos());
            var evaList = reporteador.GetListaEvaluacion();
            var asigList = reporteador.GetListaAsignaturas();
            var lisEvaAsig = reporteador.GetDicEvaluacionesXAsigna();
            var listPromEvalXAsign = reporteador.GetPromedioAlumnoPorAsignatura();
            var listMejPromXAsign = reporteador.GetMejoresPromediosPorAsignatura(2);
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.writeTitle("SALIENDO");
            Printer.Beep(3000, 1000, 3);
            Printer.writeTitle("SALIÓ");
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