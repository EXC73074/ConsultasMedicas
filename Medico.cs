using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPfinal
{
    class Medico : Persona
    {
        private int matricula;
        private int especialidad;

        public Medico(int matricula, int especialidad, long nroDoc, string nombre, string apellido, bool sexo, long telefono, DateTime fN) 
              : base (nroDoc,nombre,apellido,sexo,telefono,fN)
        {
            this.matricula = matricula;
            this.especialidad = especialidad;
        }
        public Medico()
              : base()
        {
            this.matricula = 0;
            this.especialidad = 1;
        }

        public int pMatricula { get => matricula; set => matricula = value; }
        public int pEspecialidad { get => especialidad; set => especialidad = value; }

        public string ToStringMatricula()
        {
            string mat = Convert.ToString(matricula);
            return mat;
        }
        public string ToStringEspecialidad()
        {
            string espe;
            switch(especialidad)
            {
                case 1: espe = "Pediatra"; break;
                case 2: espe = "Clínico"; break;
                case 3: espe = "Traumatologo";break;
                case 4: espe = "Cardiologo"; break;
                default: espe = "No valido";break;
            }
            return espe;
        }
        public string ToStringMedico()
        {
            return "Medico: "+"\n"+ "\n" +
                   base.ToStringPersona() + "\n" +
                   "Matricula: "+this.ToStringMatricula() + "\n" +
                   "Especialidad: " + this.ToStringEspecialidad()+"\n";
        }
    }
}
