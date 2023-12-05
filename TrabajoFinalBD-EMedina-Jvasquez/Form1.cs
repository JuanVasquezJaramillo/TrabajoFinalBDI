using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoFinalBD_EMedina_Jvasquez.logica;


namespace TrabajoFinalBD_EMedina_Jvasquez
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Consorcio objConsorcio = new Consorcio();
        Abogado objAbogado = new Abogado();
        private void btnRConsorcio_Click(object sender, EventArgs e)
        {
            int i = 0;
            if(txtNombreRConsorcio.Text.Length <=0)
            {
                MessageBox.Show("Ingresa un nombre", "NOMBRE", MessageBoxButtons.OK);

            }
            if(dtpAnioFundacionRConsorcio.Value.Date == DateTime.Today)
            {
                MessageBox.Show("Selecciona una fecha válida", "FECHA", MessageBoxButtons.OK);
            }
            if (!int.TryParse(txtNitRConsorcio.Text, out i))
            {
                MessageBox.Show("Ingresa un número de NIT", "NIT", MessageBoxButtons.OK);
            }
            if (txtNitRConsorcio.Text.Length <= 0)
            {
                MessageBox.Show("Ingresa un número de NIT válido (no se admite texto, sólo números enteros)", "NIT", MessageBoxButtons.OK);
            }
            else if(int.TryParse(txtNitRConsorcio.Text, out i) && txtNitRConsorcio.Text.Length > 0 && txtNombreRConsorcio.Text.Length > 0 && dtpAnioFundacionRConsorcio.Value.Date != DateTime.Today)
            {
                int nit = int.Parse(txtNitRConsorcio.Text);
                string nombre = txtNombreRConsorcio.Text;
                string fecha = dtpAnioFundacionRConsorcio.Value.Date.ToString("D");
                DateTime fecha2 = dtpAnioFundacionRConsorcio.Value;
                Console.WriteLine(fecha2.ToString("d") + "FECHAAAAAAAAAAA-----");
                objConsorcio.registrarConsorcio(nit, fecha, nombre);
                MessageBox.Show("Consorcio registrado con éxito", "REGISTRAR CONSORCIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRAbogado_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (txtNombreRAbogado.Text.Length <= 0)
            {
                MessageBox.Show("Ingresa un nombre", "NOMBRE", MessageBoxButtons.OK);

            }
            if (!int.TryParse(txtIdRAbogado.Text, out i))
            {
                MessageBox.Show("Ingresa un número de identificación válido (no se admite texto, sólo números)", "NÚMERO DE IDENTIFICACIÓN", MessageBoxButtons.OK);
            }
            if (txtIdRAbogado.Text.Length <= 0)
            {
                MessageBox.Show("Ingresa un número de identificación", "NÚMERO DE IDENTIFICACIÓN", MessageBoxButtons.OK);
            }
            if(!rbPenalistaRAbogado.Checked && !rbCivilRAbogado.Checked)
            {
                MessageBox.Show("Selecciona de qué tipo es el abogado", "TIPO DE ABOGADO", MessageBoxButtons.OK);
            }
            if (cbCasosRAbogado.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona la cantidad de casos que ha ganado del abogado", "CANTIDADD DE CASOS GANADOS", MessageBoxButtons.OK);
            }
            else if (int.TryParse(txtIdRAbogado.Text, out i) && txtIdRAbogado.Text.Length > 0 && txtNombreRAbogado.Text.Length > 0 && cbCasosRAbogado.SelectedIndex > 0 && (rbCivilRAbogado.Checked || rbPenalistaRAbogado.Checked))
            {
                string tipo = "";
                if (rbPenalistaRAbogado.Checked)
                {
                    tipo = rbPenalistaRAbogado.Text;
                } else if (rbCivilRAbogado.Checked)
                {
                    tipo = rbCivilRAbogado.Text;
                }
                int nId = int.Parse(txtIdRAbogado.Text);
                string nombre = txtNombreRAbogado.Text;
                string casos = cbCasosRAbogado.SelectedItem.ToString();
                if ( objAbogado.registrarAbogado(nId, nombre, tipo, casos) > 0)
                {
                MessageBox.Show("Abogado registrado con éxito", "REGISTRAR ABOGADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdRAbogado.Text = "";
                    txtNombreRAbogado.Text = "";
                    rbPenalistaRAbogado.Checked = false;
                    rbCivilRAbogado.Checked = false;
                    cbCasosRAbogado.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el abogado", "REGISTRAR ABOGADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
        
        private void btnRTrabajo_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarAbogado_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrarCAbogados_Click(object sender, EventArgs e)
        {

        }

        private void rbPenalistaRAbogado_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
