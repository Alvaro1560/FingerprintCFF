using DemoDP4500;
using FingerprintCFF.entities.models;
using FingerprintCFF.entities.repositories;
using FingerprintCFF.entities.repositories.abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FingerprintCFF
{
    public partial class VerificarHuella : CaptureForm
    {
        string IdEventGlobal;
        List<UserFingerprint> listFingerPrints;
        bool startVerify = false;
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator;
        FingerPrintRepository fingerPrintRepository = new FingerPrintRepository();
        // private UsuariosDBEntities contexto;

        public void Verify(DPFP.Template template)
        {
            Template = template;
            ShowDialog();
        }

        protected override void Init()
        {
            base.Init();
            base.Text = "Verificación de Huella Digital";
            Verificator = new DPFP.Verification.Verification();     // Create a fingerprint template verificator
            UpdateStatus(0);
        }
        public VerificarHuella(string idEvent)
        {
            IdEventGlobal = idEvent;
            InitializeComponent();
        }

        private void UpdateStatus(int FAR)
        {
            // Show "False accept rate" value
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }

        protected override void Process(DPFP.Sample Sample)
        {
            try
            {
                base.Process(Sample);

                // Process the sample and create a feature set for the enrollment purpose.
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                // Check quality of the sample and start verification if it's good
                // TODO: move to a separate task
                if (features != null)
                {
                    // Compare the feature set with our template
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                    DPFP.Template template = new DPFP.Template();

                    if (listFingerPrints.Count == 0)
                    {
                        MessageBox.Show("No se pudo registrar en la BD");
                    }

                    Stream stream;
                    foreach (var emp in listFingerPrints)
                    {
                        stream = new MemoryStream(emp.Fingerprint);
                        template = new DPFP.Template(stream);
                        if (template.Bytes != null)
                        {
                            Verificator.Verify(features, template, ref result);
                            UpdateStatus(result.FARAchieved);
                            if (result.Verified)
                            {

                                AttendandeModel newAttendance = new AttendandeModel
                                {
                                    IdUser = emp.Id,
                                    IdEvent = IdEventGlobal,
                                    UserId = "1D7A820D-234B-41D8-A31D-F34081A80D4D"
                                };
                                int responseEventUser = fingerPrintRepository.CreateAttendanceEventUser(newAttendance);

                                if (responseEventUser == 1)
                                {
                                    SoundPlayer();
                                    MakeReport("The fingerprint was VERIFIED. " + emp.CodeStudent + " Id event: " + IdEventGlobal);

                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerificarHuella_Load(object sender, EventArgs e)
        {
            listFingerPrints = fingerPrintRepository.GetFingerPrintAll();

        }

        public void SoundPlayer()
        {
            string audioFilePath = @"E:\Documents\gitlab\internal-projects\ffcc\FingerprintCFF\FingerprintCFF\assets\audio\sucessfull.wav"; // Cambia la ruta al archivo de audio que deseas reproducir

            SoundPlayer player = new SoundPlayer(audioFilePath);

            try
            {
                player.PlaySync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al reproducir el audio: " + ex.Message);
            }
        }
    }

    
}
