using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela:  ObjetoEscuelaBase, ILugar
    {   

        public int AñoDeCreación {get; set;} //La manera corta para definir el método get y set

        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public List<Curso> Cursos { get; set; }

        public List<Alumno> Alumnos { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public TiposEscuela TiposEscuela{get;set;}
        //Constructor   Define los valores iniciales que necesita nuestra intancia para funcionar correctamente
        /* 
        public Escuela(string nombre, int año){
            this.nombre = nombre; //This para indicar que hablamos de la variable interna
            AñoDeCreación = año;

        }
        */
        //Manera corta de crear el Constructor    
        public Escuela(string nombre, int año) => (nombre, AñoDeCreación) = (nombre, año);

        public Escuela(string nombre, int año, TiposEscuela tipos, string pais = "",string ciudad = "")
        {
            (nombre, AñoDeCreación) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: \'{nombre}\',{System.Environment.NewLine} TiposEscuela: {TiposEscuela}, {System.Environment.NewLine}Pais: {Pais}, {System.Environment.NewLine}Ciudad: {Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela ..");
            foreach(var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Console.WriteLine($"Escuela {nombre} limpia");
        }

    }
}