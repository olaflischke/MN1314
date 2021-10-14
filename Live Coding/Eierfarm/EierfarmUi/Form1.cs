using EierfarmBl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EierfarmUi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNeuesHuhn_Click(object sender, EventArgs e)
        {
            Huhn huhn = new Huhn("Neues Huhn");

            huhn.EigenschaftGeaendert += Gefluegel_EigenschaftGeaendert;

            // Huhn in die Combobox
            cbxTiere.Items.Add(huhn);

            // Huhn wird ausgewähltes Element in der Combobox
            cbxTiere.SelectedItem = huhn;
        }

        private void Gefluegel_EigenschaftGeaendert(object sender, EventArgs e)
        {
            //MessageBox.Show("Tier hat Eigenschaft geändert.");
            pgdTier.SelectedObject = sender;
        }

        private void cbxTiere_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgdTier.SelectedObject = cbxTiere.SelectedItem;
        }

        private void btnFuettern_Click(object sender, EventArgs e)
        {
            Gefluegel tier = cbxTiere.SelectedItem as Gefluegel; // SaveCast - liefert null, wenn Cast fehlschlägt
            if (tier != null)
            {
                tier.Fressen();
            }
        }

        private void btnEiLegen_Click(object sender, EventArgs e)
        {
            if (cbxTiere.SelectedItem is IEileger tier)
            {
                tier.EiLegen();
            }
        }

        private void btnNeueGans_Click(object sender, EventArgs e)
        {
            Gans gans = new Gans();
            gans.EigenschaftGeaendert += Gefluegel_EigenschaftGeaendert;

            cbxTiere.Items.Add(gans);
            cbxTiere.SelectedItem = gans;
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            // Benutzer nach Speicherort fragen
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                RestoreDirectory = true,
                Filter = "Hühner|*.hn|Gänse|*.gs|Enten|*.et|Alles|*.*",
                FilterIndex = 0
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Tier dort speichern
                Gefluegel tier = cbxTiere.SelectedItem as Gefluegel;
                if (tier != null)
                {
                    XmlSerializer serializer = new XmlSerializer(tier.GetType());
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        serializer.Serialize(writer, tier);
                    }
                }
            }
        }

        private void btnSchnabelTier_Click(object sender, EventArgs e)
        {
            Schnabeltier schnabeltier = new Schnabeltier();

            cbxTiere.Items.Add(schnabeltier);
            cbxTiere.SelectedItem = schnabeltier;
        }

        private void btnFuettern_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
