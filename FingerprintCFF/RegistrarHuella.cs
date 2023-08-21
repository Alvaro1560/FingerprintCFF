using DemoDP4500;
using FingerprintCFF.entities.models;
using FingerprintCFF.entities.repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FingerprintCFF
{
    public partial class RegistrarHuella : Form
    {
        private DPFP.Template Template;
        // private UsuariosEntities contexto;
        public RegistrarHuella()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] streamHuella = Template.Bytes;
                UserFingerprint fingerPrintUser = new UserFingerprint()
                {
                    CodeStudent = txtCodeStudent.Text,
                    Fingerprint = streamHuella
                };

                FingerPrintRepository fingerPrintRepository = new FingerPrintRepository();

                int respRegisterFingerPrint = fingerPrintRepository.CreateHuella(fingerPrintUser);
                if (respRegisterFingerPrint != 1)
                {
                    MessageBox.Show("No se pudo registrar en la BD");
                }
                else
                {
                    MessageBox.Show("Registro agregado a la BD correctamente");
                    Limpiar();
                    Listar();
                    Template = null;
                    btnAgregar.Enabled = false;
                }
                // contexto.Empleadoes.Add(empleado);
                // contexto.SaveChanges();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegistrarHuella_Click(object sender, EventArgs e)
        {
            CapturarHuella capturar = new CapturarHuella();
            capturar.OnTemplate += this.OnTemplate;
            capturar.ShowDialog();
        }

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate ()
            {
                Template = template;
                btnAgregar.Enabled = (Template != null);
                if (Template != null)
                {
                    MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
                    txtFingerprint.Text = "Huella capturada correctamente";
                }
                else
                {
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
                }
            }));
        }

        private void RegistrarHuella_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Limpiar()
        {
            txtCodeStudent.Text = "";
        }

        private void Listar()
        {

            try
            {
                FingerPrintRepository fingerPrintRepository = new FingerPrintRepository();

                List<UserFingerprint> listFingerPrints = fingerPrintRepository.GetFingerPrints();
                if (listFingerPrints != null)
                {
                    dgvListar.DataSource = listFingerPrints.ToList();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvListar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
