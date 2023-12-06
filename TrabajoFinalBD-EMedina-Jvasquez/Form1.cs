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
        Trabajo objTrabajo = new Trabajo();
        private void btnRConsorcio_Click(object sender, EventArgs e)
        {
            int i = 0;
            int aux = 0;
            if(txtNombreRConsorcio.Text.Length <=0)
            {
                MessageBox.Show("Ingresa un nombre", "NOMBRE", MessageBoxButtons.OK);

            }
            if (!int.TryParse(txtNitRConsorcio.Text, out i))
            {
                MessageBox.Show("Ingresa un número de NIT válido (no se admite texto, sólo números enteros)", "NIT", MessageBoxButtons.OK);
            }
            if (txtNitRConsorcio.Text.Length <= 0)
            {
                MessageBox.Show("Ingresa un número de NIT", "NIT", MessageBoxButtons.OK);
            }
            if (!int.TryParse(txtAnioFRAbogado.Text, out i))
            {
                MessageBox.Show("Ingresa un número de año de fundación válido (no se admite texto, sólo números enteros mayores que 1700 y menor o igual que el año actual)", "AÑO DE FUNDACIÓN", MessageBoxButtons.OK);
            }
            if (txtAnioFRAbogado.Text.Length <= 0)
            {
                MessageBox.Show("Ingresa un año", "AÑO DE FUNDACIÓN", MessageBoxButtons.OK);
            }
            else if(int.TryParse(txtNitRConsorcio.Text, out i) && txtNitRConsorcio.Text.Length > 0 && txtNombreRConsorcio.Text.Length > 0 && txtAnioFRAbogado.Text.Length > 0)
            {
                aux = int.Parse(txtAnioFRAbogado.Text);
                if (aux < 1700 || aux > 2023)
                {
                    MessageBox.Show("Ingresa un número de año de fundación válido (solo años mayores que 1700 y menores o iguales que el año actual)", "AÑO DE FUNDACIÓN", MessageBoxButtons.OK);
                }
                else
                {
                    int nit = int.Parse(txtNitRConsorcio.Text);
                    string nombre = txtNombreRConsorcio.Text;
                    int fecha = int.Parse(txtAnioFRAbogado.Text);
                    if (objConsorcio.registrarConsorcio(nit, fecha, nombre) > 0)
                    {
                        MessageBox.Show("Consorcio registrado con éxito", "REGISTRAR CONSORCIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNitRConsorcio.Text = "";
                        txtNombreRConsorcio.Text = "";
                        txtAnioFRAbogado.Text = "";
                    }
                }
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
            string fechaFinal = "";
            if (noEsNum(txtNitRTrabajo.Text))
            {
                MessageBox.Show("Ingresa un NIT válido", "NIT", MessageBoxButtons.OK);
            }
            if (noEsNum(txtIdRTrabajo.Text))
            {
                MessageBox.Show("Ingresa un número de identificación válido", "NÚMERO DE IDENTIFICACIÓN", MessageBoxButtons.OK);
            }
            if (!anioValido(dtpFiRTrabajo.Value.Date.ToString("yyyy")))
            {
                MessageBox.Show("Selecciona una fecha de inicio válida. (dónde el año sea mayor que 1990 y menor o igual que 2024)", "FECHA DE INCIO", MessageBoxButtons.OK);
            }
            if (!rbFfDRTrabajo.Checked && !rbFfIRTrabajo.Checked)
            {
                MessageBox.Show("Debes seleccionar si la fecha de finalización está definida o no", "FECHA DE FINALIZACIÓN", MessageBoxButtons.OK);
            }
            if (!anioValido(dtpFfRTrabajo.Value.Date.ToString("yyyy"))) 
            {
                MessageBox.Show("Selecciona una fecha de finalización válida", "FECHA DE FINALIZACIÓN", MessageBoxButtons.OK);
            }
            else if (!noEsNum(txtIdRTrabajo.Text) && !noEsNum(txtNitRTrabajo.Text) && anioValido(dtpFiRTrabajo.Value.Date.ToString("yyyy")) && (rbFfIRTrabajo.Checked || rbFfDRTrabajo.Checked))
            {
                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();
                int nit = int.Parse(txtNitRTrabajo.Text);
                int nId = int.Parse(txtIdRTrabajo.Text);
                ds = objTrabajo.consultarConsorcio(nit);
                ds2 = objTrabajo.consultarAbogado(nId);

                if (ds.Tables[0].Rows.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    //----------------------FECHA FINAL--------------------
                    string diaFF, mesFF, aNoFF;
                    //----------------------FECHA FINAL--------------------
                    if (rbFfDRTrabajo.Checked)
                    {
                        diaFF = dtpFfRTrabajo.Value.Date.ToString("dd");
                        mesFF = dtpFfRTrabajo.Value.Date.ToString("MM");
                        aNoFF = dtpFfRTrabajo.Value.Date.ToString("yyyy");
                        fechaFinal = $"{diaFF}/{mesFF}/{aNoFF}";
                    }

                    //----------------------FECHA INICIO--------------------
                    string diaFI = dtpFiRTrabajo.Value.Date.ToString("dd");
                    string mesFI = dtpFiRTrabajo.Value.Date.ToString("MM");
                    string aNoFI = dtpFiRTrabajo.Value.Date.ToString("yyyy");
                    string fechaInicio = $"{diaFI}/{mesFI}/{aNoFI}";
                    //----------------------FECHA INICIO--------------------
                    
                    
                    if (objTrabajo.registrarTrabajo(nit, nId, fechaInicio, fechaFinal) > 0)
                    {
                        MessageBox.Show("Trabajo registrado con éxito", "REGISTRAR TRABAJO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNitRTrabajo.Text = "";
                        txtIdRTrabajo.Text = "";
                        rbFfDRTrabajo.Checked = false;
                        rbFfIRTrabajo.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el NIT ni número de identificación en la base de datos existente. Intenta de nuevo", "REGISTRAR TRABAJO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private bool noEsNum(string texto)
        {
            int i = 0;
            if(texto.Length >= 0)
            {
                if (!int.TryParse(texto, out i))
                {
                    return true;
                }
            }
            return false;
        }
        private bool anioValido(string anio)
        {
            int aux = 0;
            if (anio.Length > 0)
            {
                aux = int.Parse(anio);
                if(aux >= 1990 && aux <= 2030)
                {
                    return true;
                }
            }
            return false;
        }
        private void btnBuscarAbogado_Click(object sender, EventArgs e)
        {
            DataSet miDs = new DataSet();
            string anio, mes, dia;
            anio = dtpFIBuscarAbogado.Value.Year.ToString();
            mes = dtpFIBuscarAbogado.Value.Month.ToString();
            dia = dtpFIBuscarAbogado.Value.Day.ToString();
            miDs = objAbogado.consultarAbogXFechaInicio(anio, mes, dia);


            if (miDs.Tables[0].Rows.Count > 0)
            {
                dgvDatosAbogado.DataSource = miDs;
                dgvDatosAbogado.DataMember = "ResultadoDatos";
                lblNoHayResultados.Visible = false;
            }
            else
            {
                dgvDatosAbogado.DataMember = "";
                lblNoHayResultados.Visible = true;
                MessageBox.Show("Persona no encontrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMostrarCAbogados_Click(object sender, EventArgs e)
        {
            DataSet miDs = new DataSet();
            miDs = objAbogado.consultaCantAbogPenalistas();
            if (miDs.Tables[0].Rows.Count > 0)
            {
                lblCantidadAbogados.Text = miDs.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("Persona no encontrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rbFfDRTrabajo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFfDRTrabajo.Checked)
            {
                dtpFfRTrabajo.Visible = true;
                dtpFfRTrabajo.Enabled = true;
            } else
            {
                dtpFfRTrabajo.Visible = false;
            }
        }
    }
}
