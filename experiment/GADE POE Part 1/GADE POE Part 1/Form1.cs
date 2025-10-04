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
            gameEngine = new GameEngine(10, 1, 1);

            // Display the first level
            UpdateDisplay();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Direction? dir = null;
            switch (keyData)
            {
                case Keys.Up: dir = Direction.Up; break;
                case Keys.Right: dir = Direction.Right; break;
                case Keys.Down: dir = Direction.Down; break;
                case Keys.Left: dir = Direction.Left; break;
            }

            if (dir.HasValue)
            {
                gameEngine.MoveHero(dir.Value); // Move the hero

                // Now check if hero is on the exit
                var heroPos = gameEngine.CurrentLevel.Hero.Position;
                var exitPos = gameEngine.CurrentLevel.Exit.Position;

                UpdateDisplay(); // Show updated map

                if (heroPos.X == exitPos.X && heroPos.Y == exitPos.Y)
                {
                    // Advance to next level
                    if (gameEngine.NextLevel())
                    {
                        MessageBox.Show("Level Complete! Moving to next level.");
                        UpdateDisplay(); // Show new level
                    }
                    else
                    {
                        MessageBox.Show("Congratulations! You finished all levels!");
                    }
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}