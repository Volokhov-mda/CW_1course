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
    public partial class Generator : Form
    {
        // Директория, в котором хранится HTML документ.
        const string HTML_FILE = "../../../html/pageWithTasks.html";

        // Возможные названия задач.
        private static string[] possibleNamesOfExpression = { "Исследование показательных функций и произведений",
                                                      "Исследование частных",
                                                      "Исследование степенных и иррациональных функций",
                                                      "Исследование логарифмических функций",
                                                      "Исследование тригонометрических функций",
                                                      "Исследование функций без помощи производной" };

        // Главное окно приложения.
        private Form mainMenu;

        /// <summary>
        /// Конструктор окна «Генератор задач».
        /// </summary>
        /// <param name="mainMenu">Главное окно приложения</param>
        public Generator(Form mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;
        }

        /// <summary>
        /// Загрузка окна «Генератор задач».
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Generator_Load(object sender, EventArgs e)
        {
            this.Width = 1550;
            this.Height = 950;
        }

        /// <summary>
        /// Пробует включить кнопку «СГЕНЕРИРОВАТЬ ЗАДАЧИ» при выборе типа задачи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectExpressionType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TryToEnableButtons();
        }

        /// <summary>
        /// Отображает сообщение с предупреждением, если введенное количество вариантов некорректно, 
        /// и пробует включить кнопку «СГЕНЕРИРОВАТЬ ЗАДАЧИ». 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Отображает сообщение с предупреждением, если введенное количество задач в варианте некорректны,
        /// и пробует включить кнопку «СГЕНЕРИРОВАТЬ ЗАДАЧИ».
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Генерирует HTML документ с задачами выбранного пользователем типа в заданном пользователем количеством вариантов и количеством задач в варианте.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generate_button_Click(object sender, EventArgs e)
        {
            // Создание нового пустого HTML документа.
            DummyHTML HtmlDoc = new DummyHTML();

            // Количество вариантов.
            int tasksNumber = int.Parse(tasksNumber_textBox.Text);
            // Количество заданий в варианте.
            int expressionsNumber = int.Parse(expressionsNumber_textBox.Text);
            // Выбранный тип выражения.
            string typeOfExpression = (string)selectExpressionType_comboBox.SelectedItem;

            // Ключ генерации.
            int seed = (int)DateTime.Now.Ticks;
            string stringSeed = $"G.{Array.IndexOf(possibleNamesOfExpression, typeOfExpression)}.{tasksNumber}.{expressionsNumber}." +
                $"{seed}";

            // Добавление вариантов выбранного пользователем типа задач в HtmlDoc.
            Generators.GenerateHTMLDoc(HtmlDoc,
                tasksNumber, expressionsNumber,
                seed, stringSeed, typeOfExpression);

            // Безопасное сохранение сгенерированного HtmlDoc.  
            try
            {
                HtmlDoc.SaveDoc(HTML_FILE);

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = Path.GetFileName(HTML_FILE);
                psi.WorkingDirectory = Path.GetDirectoryName(HTML_FILE);
                Process.Start(psi);
            }
            catch (FileNotFoundException message)
            {
                CallMessageBox("Файл не найден", "File Not Found Exception", error: true);
            }
            catch (IOException message)
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

        /// <summary>
        /// Проверяет корректность введенных пользователем данных (тип задачи, количество вариантов и задач в варианте). 
        /// Если данные корректны, то включается кнопка «СГЕНЕРИРОВАТЬ ЗАДАЧИ», иначе – выключается.
        /// </summary>
        private void TryToEnableButtons()
        {
            uint tempValue;

            generate_button.Enabled = selectExpressionType_comboBox.SelectedItem != null && uint.TryParse(tasksNumber_textBox.Text, out tempValue) &&
                uint.TryParse(expressionsNumber_textBox.Text, out tempValue) ? true : false;
        }

        /// <summary>
        /// Показывает скрытое главное окно приложения и уничтожает текущее окно.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void back_button_Click(object sender, EventArgs e)
        {
            mainMenu.Show();
            this.Dispose();
        }

        /// <summary>
        /// Показывает скрытое главное окно приложения и уничтожает текущее окно.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Generator_FormClosed(object sender, FormClosedEventArgs e)
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
