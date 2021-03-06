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

            Printer.writeTitle("Captura de Evaluación por Consola");
            var newEval = new Evaluacion();
            string nombre, notastring;
            float nota;

            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneEnter();
            nombre = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El valor del nombre no puede ser nulo");
            }else 
            {
                newEval.nombre = nombre.ToLower();
                WriteLine("El nombre ha sido asignado satisfactoriamente");
            }

            WriteLine("Ingrese el valor de la nota");
            Printer.PresioneEnter();
            notastring = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(notastring))
            {
                Printer.writeTitle("El valor de la nota no puede ser vacio");
                WriteLine("Saliendo del programa");
                
            }else 
            {
                try{
                newEval.Nota = float.Parse(notastring);
                if(newEval.Nota < 0 || newEval.Nota > 5)
                {
                    throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                }
                WriteLine("La nota ha sido asignada satisfactoriamente");
                }
                catch(ArgumentOutOfRangeException arg){
                    Printer.writeTitle(arg.Message);
                    WriteLine("Saliendo del programa");
                }
                catch(Exception){
                     Printer.writeTitle("El valor de la nota no es un número valido");
                        WriteLine("Saliendo del programa");

                }
               finally{
                     Printer.writeTitle("FINALLY");
                     Printer.Beep(2500, 500, 3);
               }
            }

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