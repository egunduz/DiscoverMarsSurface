using DiscoverMarsSurface.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscoverMarsSurfaceWF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(rtbInput.Text))
            {
                MessageBox.Show(this, "Plase fill in input area", "Missing Input");
                rtbInput.Focus();
                return;
            }

            IList<string> instructions = rtbInput.Lines.ToArray();

            try
            {
                var missionCenter = new MissionCenter();
                missionCenter.CreatePlatue(instructions.First());

                for (int i = 1; i < instructions.Count; i += 2)
                {
                    string roverCoordinates = instructions[i];
                    string roverInstructions = (i + 1) < instructions.Count ? instructions[i+1] : String.Empty;
                    
                    missionCenter.DeployRover(roverCoordinates, roverInstructions);
                }

                rtbOutput.Text = missionCenter.GetLastLocatsionsOfRovers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtbInput.Clear();
            rtbOutput.Clear();
        }
    }
}
