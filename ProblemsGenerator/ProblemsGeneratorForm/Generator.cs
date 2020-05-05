using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using Utils;
using ClassLib;

namespace ProblemsGeneratorForm
{
    public partial class Generator : Form
    {
        const string HTML_FILE = "../../../html/pageWithTasks.html";

        public Generator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            generate_button.FlatAppearance.BorderSize = 0;
            generate_button.FlatStyle = FlatStyle.Flat;

            this.Width = 1550;
            this.Height = 850;
        }

        private void selectExpressionType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckIfAllOptionsCorrect() == true) generate_button.Enabled = true;
        }

        private void tasksNumber_textBox_TextChanged(object sender, EventArgs e)
        {
            uint tempValue;

            if (uint.TryParse(tasksNumber_textBox.Text, out tempValue) == false || tempValue == 0)
            {
                tasksNumberWarning_label.Visible = true;
            }
            else
            {
                tasksNumberWarning_label.Visible = false;
            }

            if (CheckIfAllOptionsCorrect() == true) generate_button.Enabled = true;
        }

        private void expressionsNumber_textBox_TextChanged(object sender, EventArgs e)
        {
            uint tempValue;

            if (uint.TryParse(expressionsNumber_textBox.Text, out tempValue) == false || tempValue == 0)
            {
                expressionsNumberWarning_label.Visible = true;
            }
            else
            {
                expressionsNumberWarning_label.Visible = false;
            }

            if (CheckIfAllOptionsCorrect() == true) generate_button.Enabled = true;
        }

        private void generate_button_Click(object sender, EventArgs e)
        {
            DummyHTML HtmlDoc = new DummyHTML();

            Utils.Utils.generateHTMLDoc((string)selectExpressionType_comboBox.SelectedItem, HtmlDoc, 
                int.Parse(tasksNumber_textBox.Text), int.Parse(expressionsNumber_textBox.Text));

            HtmlDoc.SaveDoc(HTML_FILE);

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Path.GetFileName(HTML_FILE);
            psi.WorkingDirectory = Path.GetDirectoryName(HTML_FILE);
            Process.Start(psi);
        }

        private bool CheckIfAllOptionsCorrect()
        {
            uint tempValue;

            return (selectExpressionType_comboBox.SelectedItem != null && uint.TryParse(tasksNumber_textBox.Text, out tempValue) &&
                uint.TryParse(expressionsNumber_textBox.Text, out tempValue));
        }
    }
}
