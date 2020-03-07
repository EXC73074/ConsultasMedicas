using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPfinal
{
    public partial class form1 : Form
    {

            
       

        private int contadorConsultas = 0;
        private double acumuladorConsultas = 0;

        private int contadorPediatria = 0;
        private double acumuladorPediatria = 0;

        private int contadorClinico = 0;
        private double acumuladorClinico = 0;

        private int contadorTraumatologo = 0;
        private double acumuladorTraumatologo = 0;

        private int contadorCardiologo = 0;
        private double acumuladorCardiologo = 0;

        private bool baderaFemMayorSetenta = true;
        private Consulta maximo70Fem = new Consulta();

        private int conta16PartiNoPedia = 0;

        private int contadorPami = 0;
        private double acumuladorPami = 0;

        public void Inicio()
        {
            dtpFechaConsulta.Enabled = false;
            cbxTipoConsulta.Enabled = false;
            txtNroDocPaciente.Enabled = false;
            txtNroDocPaciente.Enabled = false;
            txtApellidoPaciente.Enabled = false;
            rbtnMascPaciente.Enabled = false;
            rbtnFemPaciente.Enabled = false;
            txtTelPaciente.Enabled = false;
            dtpFNPaciente.Enabled = false;
            cbxObraSocial.Enabled = false;
            txtNroDocMedi.Enabled = false;
            txtNomMedico.Enabled = false;
            txtApellidoMedi.Enabled = false;
            rbtnMascMedi.Enabled = false;
            rbtnFemMedi.Enabled = false;
            txtTelMedi.Enabled = false;
            dtpFnMedi.Enabled = false;
            txtMatricula.Enabled = false;
            cbxEspecialidad.Enabled = false;
            panelDer.Enabled = false;
        }

        public void Nuevo()
        {
            dtpFechaConsulta.Enabled = true;
            cbxTipoConsulta.Enabled = true;
            txtNroDocPaciente.Enabled = true;
            txtNroDocPaciente.Enabled = true;
            txtApellidoPaciente.Enabled = true;
            rbtnMascPaciente.Enabled = true;
            rbtnFemPaciente.Enabled = true;
            txtTelPaciente.Enabled = true;
            dtpFNPaciente.Enabled = true;
            cbxObraSocial.Enabled = true;
            txtNroDocMedi.Enabled = true;
            txtNomMedico.Enabled = true;
            txtApellidoMedi.Enabled = true;
            rbtnMascMedi.Enabled = true;
            rbtnFemMedi.Enabled = true;
            txtTelMedi.Enabled = true;
            dtpFnMedi.Enabled = true;
            txtMatricula.Enabled = true;
            cbxEspecialidad.Enabled = true;
            panelDer.Enabled = true;
        }


        public void Limpiar()
        {
            dtpFechaConsulta.Value = DateTime.Today;
            cbxTipoConsulta.SelectedIndex = -1;
            txtNroDocPaciente.Clear();
            txtNombrePaciente.Clear();
            txtApellidoPaciente.Clear();
            rbtnMascPaciente.Checked = false;
            rbtnFemPaciente.Checked = false;
            txtTelPaciente.Clear();
            dtpFNPaciente.Value = DateTime.Today;
            cbxObraSocial.SelectedIndex = -1;
            txtNroDocMedi.Clear();
            txtNomMedico.Clear();
            txtApellidoMedi.Clear();
            rbtnMascMedi.Checked = false;
            rbtnFemMedi.Checked = false;
            txtTelMedi.Clear();
            dtpFnMedi.Value = DateTime.Today;
            txtMatricula.Clear();
            cbxEspecialidad.SelectedIndex = -1;

            Inicio();
        }

        public form1()
        {
            InitializeComponent();

            cbxObraSocial.Items.Add("Particular");
            cbxObraSocial.Items.Add("Appros");
            cbxObraSocial.Items.Add("Pami");
            cbxObraSocial.Items.Add("Ospid");

            cbxEspecialidad.Items.Add("Pediatria");
            cbxEspecialidad.Items.Add("Clinica");
            cbxEspecialidad.Items.Add("Traumatologo");
            cbxEspecialidad.Items.Add("Cardiologo");

            cbxTipoConsulta.Items.Add("1° vez");
            cbxTipoConsulta.Items.Add("Paciente del profecional");
            txtApellidoMedi.ReadOnly = false;
            
            dtpFNPaciente.MaxDate = DateTime.Today;
            dtpFnMedi.MaxDate = DateTime.Today;

            Inicio();



        }
       
        public double CalculaPorcentaje(double a, double gral)
        {
            Convert.ToDouble(a);
            Convert.ToDouble(gral);
            if (gral == 0)
            {
                return 0;
            }
            else
            {
                return (a / gral) * 100;
            }
        }
        public double CalculaPorcentaje(int a, int gral)
        {
            Convert.ToDouble(a);
            Convert.ToDouble(gral);
            if (gral == 0)
            {
                return 0;
            }
            else
            {
                return (a / gral) * 100;
            }
        }
        public double CalculaPromedio(double a, int c)
        {
            Convert.ToDouble(a);
            Convert.ToDouble(c);

            if (c == 0)
            {
                return 0;
            }
            else
            {
                return a / c;
            }
        }
        public bool ValidaDesimal(string ee)
        {            
            bool validacion = false;
            int contadorValidador = 0;
            int contadorValidadorComas = 0;
            char[] vector = new char[ee.Length];
            vector = ee.ToCharArray();

            for (int j = 0; j < ee.Length; j++)
            {
                if (!Char.IsNumber(vector[j]) || ee == "")
                {
                    contadorValidador++;
                    if (vector[j] == ',')
                    {
                        contadorValidador--;
                        contadorValidadorComas++;
                    }
                }
            }
            if (contadorValidador == 0 && contadorValidadorComas <= 1)
            {
                validacion = true;
            }

            return validacion;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          
      
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Paciente p = new Paciente();
            Medico m = new Medico();
            Consulta c = new Consulta();

           

            p.PnroDoc = Convert.ToInt32(txtNroDocPaciente.Text);
            p.Pnombre = txtNombrePaciente.Text;
            p.Papellido = txtApellidoPaciente.Text;
            p.Psexo = rbtnMascPaciente.Checked;
            p.Ptelefono = Convert.ToInt64(txtTelPaciente.Text);
            p.PfN = dtpFNPaciente.Value;
            p.PobraSocial = cbxObraSocial.SelectedIndex + 1;
            
            

            m.PnroDoc = Convert.ToInt32(txtNroDocMedi.Text);
            m.Pnombre = txtNomMedico.Text;
            m.Papellido = txtApellidoMedi.Text;
            m.Psexo = rbtnMascMedi.Checked;
            m.Ptelefono = Convert.ToInt64(txtTelMedi.Text);
            m.PfN = dtpFnMedi.Value;
            m.pMatricula = Convert.ToInt32(txtMatricula.Text);
            m.pEspecialidad = cbxEspecialidad.SelectedIndex + 1;

            c.PfConsulta = dtpFechaConsulta.Value;
            c.PtipoConsulta = cbxTipoConsulta.SelectedIndex + 1;
            c.PmiPaciente = p;
            c.PmiMedico = m;

            


            // INICIO Cuenta las consultas realizadas y acumula el total recaudado
            contadorConsultas++;
            acumuladorConsultas = acumuladorConsultas + c.CalculaMontoAPagar();
            // FIN Cuenta las consultas realizadas y acumula el total recaudado

            //INICIO 
            switch(c.PmiMedico.pEspecialidad)
            {
                case 1:
                       contadorPediatria++;
                       acumuladorPediatria = acumuladorPediatria + c.CalculaMontoAPagar();
                       break;
                case 2:
                       contadorClinico++;
                       acumuladorClinico = acumuladorClinico + c.CalculaMontoAPagar();
                       break;
                case 3:
                       contadorTraumatologo++;
                       acumuladorTraumatologo = acumuladorTraumatologo + c.CalculaMontoAPagar();
                       break;
                case 4:
                       contadorCardiologo++;
                       acumuladorCardiologo = acumuladorCardiologo + c.CalculaMontoAPagar();
                       break;
                default:
                       break;
            }
            //FIN 



            // Calcula el paciente Femenina mayor a 70 años que pago mas
            if(c.PmiPaciente.Psexo==false && c.PmiPaciente.CalculaEdadPersona()>=70)
            {
                if(baderaFemMayorSetenta == true)
                {
                    baderaFemMayorSetenta = false;
                    maximo70Fem = c;
                }
                else
                {                   
                    
                   if (c.CalculaMontoAPagar() > maximo70Fem.CalculaMontoAPagar())
                   {
                    maximo70Fem = c;
                   }                   

                }

            }
            // FIN Calcula el paciente Femenina mayor a 70 años que pago mas

            // INICIO cuenta pacientes menors de 16 años obrasocial particular no pediatras
            if (c.PmiPaciente.CalculaEdadPersona()<16 
              && c.PmiPaciente.PobraSocial==1 
              && c.PmiMedico.pEspecialidad!=1 )
            {
                conta16PartiNoPedia++;
            }
            // FIN cuenta pacientes menors de 16 años obrasocial particular no pediatras
            if(c.PmiPaciente.PobraSocial==3)
            {
                contadorPami++;
                acumuladorPami = acumuladorPami + c.CalculaMontoAPagar();

            }
            txtMontoPagado.Text =Convert.ToString(c.CalculaMontoAPagar());

            MessageBox.Show(c.ToStringConsulta()+"\n"+"edad: "+c.PmiPaciente.CalculaEdadPersona());
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtbxMonitor.Clear();
            rtbxMonitor.Text = "Se realizaron: " + contadorConsultas + " consultas" + "\n" +
                               "Y se recaudo: $" + acumuladorConsultas;
        }

        private void btnPromedioXespecialidad_Click(object sender, EventArgs e)
        {
        

            rtbxMonitor.Clear();
            rtbxMonitor.Text = "Promedio por especialidad" + "\n" +
                               "Pediatria: $" + CalculaPromedio(acumuladorPediatria, contadorPediatria) + "\n" +
                               "Clinico: $" + CalculaPromedio(acumuladorClinico, contadorClinico) + "\n" +
                               "Traumatologo: $" + CalculaPromedio(acumuladorTraumatologo, contadorTraumatologo) + "\n" +
                               "Cardiologo: $" + CalculaPromedio(acumuladorCardiologo, contadorCardiologo);
        }

        private void btnMayor70_Click(object sender, EventArgs e)
        {
            rtbxMonitor.Clear();
            if (maximo70Fem.PmiPaciente==null)
            {
                rtbxMonitor.Text = "No ha ingresado ninguno hasta el momento";
            }
            else
            {
                rtbxMonitor.Text = maximo70Fem.PmiPaciente.ToStringPersona();
            }

           
        }

        private void btnPorcNiño16_Click(object sender, EventArgs e)
        {
            rtbxMonitor.Clear();
            rtbxMonitor.Text = "El porcentage de niños menores de " +
                "16 años que se atienden con profecionales que no " +
                "son pediatras es: " + CalculaPorcentaje(Convert.ToDouble(conta16PartiNoPedia), Convert.ToDouble(contadorConsultas)) + " %";
           
        }

        private void txtApellidoPaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNroDocMedi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellidoMedi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNomMedico_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelPaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelMedi_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            rtbxMonitor.Text = "El Porcentage de consultas " +
                "por pami es:" + "\n" + "De Consultas: " + CalculaPorcentaje(acumuladorPami, acumuladorConsultas) +" %"+ "\n" +
                "Monto de Consultas: " + CalculaPorcentaje(Convert.ToDouble(contadorPami), Convert.ToDouble(contadorConsultas))+ " %";
        }

        private void cbxObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNroDocPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* false= habilita && true invalida*/
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;


        }

        private void nged(object sender, EventArgs e)
        {
      
        }

        private void txtNombrePaciente_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
            
        }

        private void txtApellidoPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNomMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtApellidoMedi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNroDocMedi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtTelMedi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtTelPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dtpFNPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void CERRAR_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Esta saliendo del programa" + "\n" + "¿Desea Salir?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
            if(DialogResult==DialogResult.Yes)
            {
                Close();
            }
            
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            DialogResult=MessageBox.Show( "¿Está seguro de cancelar la operación?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
            if (DialogResult== DialogResult.Yes)
            {
                Limpiar();
            }
            
            
            



        }

        private void txtNroDocPaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("¿Generar Nueva Consulta?", "Nueva Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if(DialogResult==DialogResult.Yes)
            {
                Nuevo();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            form1.ActiveForm.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (ActiveForm.WindowState == FormWindowState.Normal)
            {
                form1.ActiveForm.WindowState = FormWindowState.Maximized;
            }

            else
            {
                form1.ActiveForm.WindowState = FormWindowState.Normal;
            }
                




        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
