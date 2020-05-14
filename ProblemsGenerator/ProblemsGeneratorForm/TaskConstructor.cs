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
    public partial class TaskConstructor : Form
    {
        const string HTML_FILE = "../../../html/pageWithTasks.html";

        Form mainMenu;
        public TaskConstructor(Form mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;
        }

        private void TaskConstructor_Load(object sender, EventArgs e)
        {
            this.Width = 1550;
            this.Height = 950;
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

            TryToEnableButton();
        }

        private void TaskConstructor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            mainMenu.Show();
        }

        private void powerExpr_textBox_TextChanged(object sender, EventArgs e)
        {
            TryToEnableButton();
        }

        private void quotientExpr_textBox_TextChanged(object sender, EventArgs e)
        {
            TryToEnableButton();
        }

        private void expExpr_textBox_TextChanged(object sender, EventArgs e)
        {
            TryToEnableButton();
        }

        private void logExpr_textBox_TextChanged(object sender, EventArgs e)
        {
            TryToEnableButton();
        }

        private void trigExpr_textBox_TextChanged(object sender, EventArgs e)
        {
            TryToEnableButton();
        }

        private void notDerivativeExpr_textBox_TextChanged(object sender, EventArgs e)
        {
            TryToEnableButton();
        }

        private void generate_button_Click(object sender, EventArgs e)
        {
            Utils.Utils.GeneratorDelegate generators;
            List<Utils.Utils.GeneratorDelegate> generatorsList = new List<Utils.Utils.GeneratorDelegate>();

            // Определение количества выражений каждого типа в варианте.
            uint numOfPowerExpr = uint.TryParse(powerExpr_textBox.Text, out numOfPowerExpr) == false ? 0 : numOfPowerExpr;
            uint numOfQuotientExpr = uint.TryParse(quotientExpr_textBox.Text, out numOfQuotientExpr) == false ? 0 : numOfQuotientExpr;
            uint numOfExpExpr = uint.TryParse(expExpr_textBox.Text, out numOfExpExpr) == false ? 0 : numOfExpExpr;
            uint numOfLogExpr = uint.TryParse(logExpr_textBox.Text, out numOfLogExpr) == false ? 0 : numOfLogExpr;
            uint numOfTrigExpr = uint.TryParse(trigExpr_textBox.Text, out numOfTrigExpr) == false ? 0 : numOfTrigExpr;
            uint numOfNotDerivativeExpr = uint.TryParse(notDerivativeExpr_textBox.Text, out numOfNotDerivativeExpr) == false ? 0 : numOfNotDerivativeExpr;

            // Добавление выражений по исследованию степенных и иррациональных функций.
            for (int i = 0; i < numOfPowerExpr; i++)
                generatorsList.Add(Utils.Utils.GeneratePowerExpression);

            // Добавление выражений по исследованию частных.
            for (int i = 0; i < numOfQuotientExpr; i++)
                generatorsList.Add(Utils.Utils.GenerateQuotientExpression);

            // Добавление выражений по исследованию показательных функций и произведений.
            for (int i = 0; i < numOfExpExpr; i++)
                generatorsList.Add(Utils.Utils.GenerateExpExpression);

            // Добавление выражений по исследованию логарифмический функций.
            for (int i = 0; i < numOfLogExpr; i++)
                generatorsList.Add(Utils.Utils.GenerateLogExpression);

            // Добавление выражений по исследованию тригонометрических функций.
            for (int i = 0; i < numOfTrigExpr; i++)
                generatorsList.Add(Utils.Utils.GenerateTrigonometricExpression);

            // Добавление выражений по исследованию функций без помощи производной.
            for (int i = 0; i < numOfNotDerivativeExpr; i++)
                generatorsList.Add(Utils.Utils.GenerateExpressionNotRequiringDerivative);

            DummyHTML HtmlDoc = new DummyHTML();

            Utils.Utils.generateHTMLDoc(HtmlDoc, int.Parse(tasksNumber_textBox.Text), generatorsList);

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

        private void TryToEnableButton()
        {
            uint tempValue;

            generate_button.Enabled = uint.TryParse(tasksNumber_textBox.Text, out tempValue) &&
                (uint.TryParse(powerExpr_textBox.Text, out tempValue) || uint.TryParse(quotientExpr_textBox.Text, out tempValue) ||
                uint.TryParse(expExpr_textBox.Text, out tempValue) || uint.TryParse(logExpr_textBox.Text, out tempValue) ||
                uint.TryParse(trigExpr_textBox.Text, out tempValue) || uint.TryParse(notDerivativeExpr_textBox.Text, out tempValue));
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            mainMenu.Show();
            this.Dispose();
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
