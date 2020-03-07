using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPfinal
{
   abstract class Persona
    {
        private long nroDoc;
        private string nombre;
        private string apellido;
        private bool sexo;
        private long telefono;
        private DateTime fN;

        public long PnroDoc
        {
            set { nroDoc = value; }
            get { return nroDoc; } 
        }
        public string Pnombre { get => nombre; set => nombre = value; }
        public string Papellido { get => apellido; set => apellido = value; }
        public bool Psexo { get => sexo; set => sexo = value; }
        public long Ptelefono { get => telefono; set => telefono = value; }
        public DateTime PfN { get => fN; set => fN = value; }

        public Persona(long nroDoc, string nombre, string apellido, bool sexo, long telefono, DateTime fN)
        {
            this.nroDoc = nroDoc;
            this.nombre = nombre;
            this.apellido = apellido;
            this.sexo = sexo;
            this.telefono = telefono;
            this.fN = fN;
        }
        public Persona()
        {
            this.nroDoc = 0;
            this.nombre = "";
            this.apellido = "";
            this.sexo = true;
            this.telefono = 0;
            this.fN = DateTime.Today;
        }
        public string ToStringNroDoc()
        {
            string nD = Convert.ToString(nroDoc);
            return nD;
        }
        public string ToStringSexo()
        {
            if(sexo)
            {
                return "Masculino";
            }
            else
            {
                return "Femenino";
            }            
        }
        public string ToStringTelefono()
        {
            string tel = Convert.ToString(telefono);
            return tel;
        }
        public string ToStringFechaNacimiento()
        {
            string fNacimiento = Convert.ToString(fN);
            return fNacimiento;
        }
        public string ToStringPersona()
        {
            return "Numero de documento: "+this.ToStringNroDoc() + "\n" +
                   "Nombre: " + nombre + "\n" +
                   "Apellido: " + apellido + "\n" +
                   "Sexo: " + this.ToStringSexo() + "\n" +
                   "Numero de telefono: " + this.ToStringTelefono() + "\n" +
                   "Fecha de Nacimiento: " + this.ToStringFechaNacimiento();
        }
        public int CalculaEdadPersona()
        {
            int edad = DateTime.Today.Year - fN.Year;
            int mesHoy = DateTime.Today.Month;
            int mesNacimiento = fN.Month;
            int diaHoy = DateTime.Today.Day;
            int diaNacimiento = fN.Day;

            if(mesHoy>mesNacimiento)
            {
                return edad;
            }
            else 
            {
                if (mesHoy == mesNacimiento)
                {
                    if (diaHoy >= diaNacimiento)
                    {
                        return edad;
                    }
                    else
                    {
                        return edad-1;
                    }
                }
                else
                {
                    return edad-1;
                }
               
            }
        }
    }
}
