using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemsGeneratorForm
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.Width = 1550;
            this.Height = 950;
        }

        private void openGenerator_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form generator = new Generator(this);
            generator.Show();
        }

        private void openTaskConstructor_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form taskConstructor = new TaskConstructor(this);
            taskConstructor.Show();
        }

        private void openRandomGenerator_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form randomGenerator = new RandomGenerator(this);
            randomGenerator.Show();
        }
    }
}
