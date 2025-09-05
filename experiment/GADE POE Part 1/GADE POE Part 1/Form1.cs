using System;
using System.Windows.Forms;
using static GADE_POE_Part_1.GameEngineClass;

namespace GADE_POE_Part_1
{
    public partial class Form1 : Form
    {
        private GameEngine gameEngine;

        public Form1()
        {
            InitializeComponent();

            // Initialise GameEngine with number of levels = 10
            gameEngine = new GameEngine(10);

            // Display the first level
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            // Call GameEngine’s ToString() and display it
            lblDisplay.Text = gameEngine.ToString();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Paint logic here if needed
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            // Click logic here if needed
        }
    }
}
