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
            gameEngine = new GameEngine(10, 1, 1, 1);
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
                gameEngine.MoveHero(dir.Value);
                var heroPos = gameEngine.CurrentLevel.Hero.Position;
                var exitPos = gameEngine.CurrentLevel.Exit.Position;
                UpdateDisplay();
                if (heroPos.X == exitPos.X && heroPos.Y == exitPos.Y)
                {
                    if (gameEngine.NextLevel())
                    {
                        MessageBox.Show("Level Complete! Moving to next level.");
                        UpdateDisplay();
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

        // This is your display update method. Only this version should exist!
        private void UpdateDisplay()
        {
            lblDisplay.Text = gameEngine.ToString();
            UpdateHeroStats();
        }

        // This is your hero stats update method.
        private void UpdateHeroStats()
        {
            var hero = gameEngine.CurrentLevel.Hero;
            lblHerostats.Text =
                $"Hero Stats:\n" +
                $"HP: {hero.HitPoints}/{hero.MaxHitPoints}\n" +
                $"Attack: {hero.AttackPower}";
        }

        // If you have an event handler for painting, make sure it has a unique name:
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
            // Any logic here if needed
        }
    }
}