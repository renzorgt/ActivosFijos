using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormActivosFijos.Models;

namespace WinFormActivosFijos
{
    public partial class Form1 : Form
    {
        string baseurl = ConfigurationManager.AppSettings["BaseUrl"];
        string ctlACtivoFijo = "ActivoFijo";
        string ctlTipo = "Tipo";


        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {


            load_tipo();


        }

        public async Task<string> GetHttp(string url)
        {
            WebRequest oRequest =  WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());

            return await sr.ReadToEndAsync();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)

        {
            try
            {
                string parameters = "";
                if (checTipo.Checked is true)
                {
                    parameters = parameters + "tipo=" + cbxTipo.SelectedValue.ToString();
                }
                if (checkFechaCompra.Checked is true)
                {
                    parameters = parameters + "&fechacompra=" + dtFechaCompra.Value.ToString("yyyy-MM-dd");
                }
                if (checkIdActivo.Checked is true)
                {
                    parameters = parameters + "&id=" + numId.Value;

                }
                if (checkSerial.Checked is true)
                {
                    parameters = parameters + "&serial=" + txtSerial.Text.ToString();

                }

                string resp = await GetHttp(baseurl+ctlACtivoFijo + "?" + parameters);
                List<ActivoFijoView> lst = JsonConvert.DeserializeObject<List<ActivoFijoView>>(resp);

                if (lst.Count > 0)
                {
                    btnEditar.Enabled = true;
                    grdActivosFijos.DataSource = lst;
                }
                else
                {
                    btnEditar.Enabled = false;
                }
               

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void checkFechaCompra_CheckedChanged(object sender, EventArgs e)
        {
            valcheck(checkFechaCompra, dtFechaCompra);
        }


        private void checTipo_CheckedChanged(object sender, EventArgs e)
        {
            valcheck(checTipo, cbxTipo);
        }

        private void checkSerial_CheckedChanged(object sender, EventArgs e)
        {
            valcheck(checkSerial, txtSerial);
        }

        private void checkIdActivo_CheckedChanged(object sender, EventArgs e)
        {
            valcheck(checkIdActivo, numId);
        }

        private async void load_tipo()
        {
            string resp = await GetHttp(baseurl + ctlTipo);
            List<TipoView> lst = JsonConvert.DeserializeObject<List<TipoView>>(resp);
            cbxTipo.DataSource = lst;
            cbxTipo.DisplayMember = "nombre";
            cbxTipo.ValueMember = "id";
            cbxTipo.SelectedIndex = 0;
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            grbActualizar.Visible = true;

            var b = grdActivosFijos.Rows[grdActivosFijos.CurrentRow.Index].Cells[0].Value;

            dtFechaBaja.Value = (DateTime)grdActivosFijos.Rows[grdActivosFijos.CurrentRow.Index].Cells[13].Value;
            txtActSerial.Text = (string)grdActivosFijos.Rows[grdActivosFijos.CurrentRow.Index].Cells[5].Value;
        }

        private void valcheck(CheckBox check, Control obj)
        {
            if (check.Checked is true)
            {
                obj.Enabled = true;
            }
            else
            {
                obj.Enabled = false;
            }
        }

        private void checkFechaBaja_CheckedChanged(object sender, EventArgs e)
        {
            valcheck(checkFechaBaja, dtFechaBaja);
        }

        private void checActSerial_CheckedChanged(object sender, EventArgs e)
        {
            valcheck(checkFechaBaja, txtActSerial);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
