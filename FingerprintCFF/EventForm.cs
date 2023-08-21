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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FingerprintCFF
{
    public partial class EventForm : Form
    {

        public string EventID;
        public EventForm()
        {
            InitializeComponent();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            FingerPrintRepository fingerPrintRepository = new FingerPrintRepository();

            List<EventModel> listEvents = fingerPrintRepository.GetEventsAll();

            comboEvents.DisplayMember = "Description";
            comboEvents.DataSource = listEvents;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEvents.SelectedItem != null)
            {
                // Obtén el objeto seleccionado en el ComboBox
                EventModel objetoSeleccionado = (EventModel)comboEvents.SelectedItem;

                EventID = objetoSeleccionado.Id;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerificarHuella verificarHuella = new VerificarHuella(EventID);
            verificarHuella.ShowDialog();
        }
    }
}
