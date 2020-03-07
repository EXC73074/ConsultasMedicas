using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPfinal
{
    class Consulta
    {
        private DateTime fConsulta;
        private double montoPagado;
        private int tipoConsulta;
        private Paciente miPaciente;
        private Medico miMedico;

        public Consulta(DateTime fConsulta, double montoPagado, int tipoConsulta, Paciente miPaciente, Medico miMedico)
        {
            this.fConsulta = fConsulta;
            this.montoPagado = montoPagado;
            this.tipoConsulta = tipoConsulta;
            this.miPaciente = miPaciente;
            this.miMedico = miMedico;
        }
        public Consulta()
        {
            this.fConsulta = DateTime.Today;
            this.montoPagado = 0;
            this.tipoConsulta = 0;
            this.miPaciente = null;
            this.miMedico = null;
        }
        public string TostringFechaConsulta()
        {
            string fechaConsulta = Convert.ToString(fConsulta);
            return fechaConsulta;
        }
        public string ToStringMontoPagado()
        {
            string montoPag = Convert.ToString(this.CalculaMontoAPagar());
            return montoPag;
        }
        public double CalculaMontoAPagar()
        {
            double mPag;
            switch (miPaciente.PobraSocial)
            {
                case 1: mPag = 750; break;
                case 2: mPag = 250; break;
                case 3: mPag = 100; break;
                case 4: mPag = 300; break;
                default: mPag = 0; break;
            }
            if (this.PtipoConsulta == 1)
            {
                mPag = mPag * 1.05;
            }
            return mPag;
        }
        public string ToStringTipoConsulta()
        {
            if(tipoConsulta==1)
            {
                return "1° vez";
            }
            else
            {
                return "Paciente del profecional";
            }
        }
        public string ToStringConsulta()
        {
            return "Consulta"+"\n"+ "\n" +
                   "Fecha de la consulta: " +this.TostringFechaConsulta() + "\n" +
                   "Monto a Pagar: $" + this.CalculaMontoAPagar() + "\n" +
                   "Tipo de consulta: " + this.ToStringTipoConsulta() + "\n" + "\n" +
                   this.miPaciente.ToStringPaciente() + "\n" +
                   this.miMedico.ToStringMedico();
        }

        public DateTime PfConsulta { get => fConsulta; set => fConsulta = value; }
        public double PmontoPagado { get => montoPagado; set => montoPagado = value; }
        public int PtipoConsulta { get => tipoConsulta; set => tipoConsulta = value; }
        internal Paciente PmiPaciente { get => miPaciente; set => miPaciente = value; }
        internal Medico PmiMedico { get => miMedico; set => miMedico = value; }
    }

}
