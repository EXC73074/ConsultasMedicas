using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPfinal
{
    class Paciente : Persona
    {
        private int obraSocial;

        public int PobraSocial { get => obraSocial; set => obraSocial = value; }

        public Paciente(int obraSocial, long nroDoc, string nombre, string apellido, bool sexo, long telefono, DateTime fN)
        : base(nroDoc,nombre,apellido,sexo,telefono,fN)
        {
            this.obraSocial = obraSocial;
        }
        public Paciente()
        : base()
        {
            this.obraSocial = 0;
        }
        public string TostringObraSocial()
        {
            string oS;
            switch(obraSocial)
            {
                case 1:oS = "Particular"; break;
                case 2:oS = "Appros"; break;
                case 3:oS = "Pami"; break;
                case 4:oS = "Ospid"; break;
                default: oS = "No valido"; break;
            }
            return oS;
        }
        public string ToStringPaciente()
        {
            return  "Paciente"+"\n"+ "\n" +
                    base.ToStringPersona() + "\n" +
                   "Obra social: "+this.TostringObraSocial()+"\n";
        }
    }
}
