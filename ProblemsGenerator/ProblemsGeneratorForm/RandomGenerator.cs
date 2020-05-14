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

using ClassLib;

namespace ProblemsGeneratorForm
{
    public partial class RandomGenerator : Form
    {
        const string HTML_FILE = "../../../html/pageWithTasks.html";

        Form mainMenu;

        public RandomGenerator(Form mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;
        }

        private void RandomGenerator_Load(object sender, EventArgs e)
        {
            this.Width = 1550;
            this.Height = 800;
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

            TryToEnableButtons();
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

            TryToEnableButtons();
        }

        private void generateRandom_button_Click(object sender, EventArgs e)
        {
            DummyHTML HtmlDoc = new DummyHTML();

            Utils.Utils.generateHTMLDoc(HtmlDoc,
                int.Parse(tasksNumber_textBox.Text), int.Parse(expressionsNumber_textBox.Text));

            try
            {
                HtmlDoc.SaveDoc(HTML_FILE);

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = Path.GetFileName(HTML_FILE);
                psi.WorkingDirectory = Path.GetDirectoryName(HTML_FILE);
                Process.Start(psi);
            }
            catch (FileNotFoundException ex)
            {
                CallMessageBox("Файл не найден", "File Not Found Exception", error: true);
            }
            catch (IOException ex)
            {
                CallMessageBox("Ошибка ввода/вывода", "IO Exception", error: true);
            }
            catch (System.Security.SecurityException message)
            {
                CallMessageBox("Ошибка безопасности", "Security exception", error: true);
            }
            catch (UnauthorizedAccessException message)
            {
                CallMessageBox("Ошибка доступа", "Unauthorized acsess exception", error: true);
            }
            catch (Exception message)
            {
                CallMessageBox("Возникла непредвиденная ошибка", "Exception", error: true);
            }
        }

        private void TryToEnableButtons()
        {
            uint tempValue;

            generateRandom_button.Enabled = uint.TryParse(tasksNumber_textBox.Text, out tempValue) &&
                uint.TryParse(expressionsNumber_textBox.Text, out tempValue) ? true : false;
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            mainMenu.Show();
            this.Dispose();
        }

        private void RandomGenerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            mainMenu.Show();
        }

        /// <summary>
        /// Вызывает MessageBox, оповещающий о случившейся ошибке.
        /// MessageBoxIcon - всегда Error.
        /// </summary>
        /// <param name="message">Сообщение MessageBox</param>
        /// <param name="caption">Заголовок MessageBox</param>
        /// <param name="buttons">Кнопки MessageBox</param>
        private void CallMessageBox(string message, string caption, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxButtons buttons = MessageBoxButtons.OK, bool error = false)
        {
            // Вызов MessageBox по заданным параметрам.
            // Если error = true, то программа закрывается, иначе просто появляется MessageBox-предупреждение.
            if (error)
            {
                DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Warning);
            }
        }
    }
}
