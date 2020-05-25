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

namespace Task12Generator
{
    public partial class TaskConstructor : Form
    {
        // Путь к директории, в которой хранится HTML документ.
        private const string HTML_FILE_DIRECTORY = "html";

        // Путь к HTML документу.
        private const string HTML_FILE = "html/pageWithTasks.html";

        // Главное окно приложения
        Form mainMenu;

        /// <summary>
        /// Конструктор окна «Конструктор вариантов».
        /// </summary>
        /// <param name="mainMenu">Главное окно приложения</param>
        public TaskConstructor(Form mainMenu)
        {
            InitializeComponent();

            this.mainMenu = mainMenu;
        }

        /// <summary>
        /// Загрузка окна «Конструктор вариантов». 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskConstructor_Load(object sender, EventArgs e)
        {
            this.Width = 1550;
            this.Height = 950;
        }

        /// <summary>
        /// Отображает сообщение с предупреждением, если введенное количество вариантов некорректно, 
        /// и пробует включить кнопку «СГЕНЕРИРОВАТЬ ЗАДАЧИ» (метод TryToEnableButtons)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tasksNumber_textBox_TextChanged(object sender, EventArgs e)
        {
            uint tempValue;

            if (!uint.TryParse(tasksNumber_textBox.Text, out tempValue) || tempValue == 0)
            {
                tasksNumberWarning_label.Visible = true;
            }
            else
            {
                tasksNumberWarning_label.Visible = false;
            }

            TryToEnableButton();
        }

        /// <summary>
        /// Отображает сообщение с предупреждением, если введенное количество задач типа «Исследование степенных функций» некорректно.
        /// Пробует включить кнопку «СГЕНЕРИРОВАТЬ ЗАДАЧИ» 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void powerExpr_textBox_TextChanged(object sender, EventArgs e)
        {
            TryToEnableButton();

            uint tempValue;

            if (powerExpr_textBox.Text == "")
            {
                powerExprWarning_label.Visible = false;
            }
            else if (!uint.TryParse(powerExpr_textBox.Text, out tempValue))
            {
                powerExprWarning_label.Visible = true;
                generate_button.Enabled = false;
            }
            else
            {
                powerExprWarning_label.Visible = false;
            }
        }

        /// <summary>
        /// Отображает сообщение с предупреждением, если введенное количество задач типа «Исследование частных» некорректно.
        /// Пробует включить кнопку «СГЕНЕРИРОВАТЬ ЗАДАЧИ» 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quotientExpr_textBox_TextChanged(object sender, EventArgs e)
        {
            TryToEnableButton();

            uint tempValue;

            if (quotientExpr_textBox.Text == "")
            {
                quotientExprWarning_label.Visible = false;
            }
            else if (!uint.TryParse(quotientExpr_textBox.Text, out tempValue))
            {
                quotientExprWarning_label.Visible = true;
                generate_button.Enabled = false;
            }
            else
            {
                quotientExprWarning_label.Visible = false;
            }
        }

        /// <summary>
        /// Отображает сообщение с предупреждением, если введенное количество задач типа «Исследование произведений» некорректно. 
        /// Пробует включить кнопку «СГЕНЕРИРОВАТЬ ЗАДАЧИ» 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expExpr_textBox_TextChanged(object sender, EventArgs e)
        {
            TryToEnableButton();

            uint tempValue;

            if (expExpr_textBox.Text == "")
            {
                expExprWarning_label.Visible = false;
            }
            else if (!uint.TryParse(expExpr_textBox.Text, out tempValue))
            {
                expExprWarning_label.Visible = true;
                generate_button.Enabled = false;
            }
            else
            {
                expExprWarning_label.Visible = false;
            }
        }

        /// <summary>
        /// Отображает сообщение с предупреждением, если введенное количество задач типа «Исследование показательных и логарифмических функций» некорректно. 
        /// Пробует включить кнопку «СГЕНЕРИРОВАТЬ ЗАДАЧИ» 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logExpr_textBox_TextChanged(object sender, EventArgs e)
        {
            TryToEnableButton();

            uint tempValue;

            if (logExpr_textBox.Text == "")
            {
                logExprWarning_label.Visible = false;
            }
            else if (!uint.TryParse(logExpr_textBox.Text, out tempValue))
            {
                logExprWarning_label.Visible = true;
                generate_button.Enabled = false;
            }
            else
            {
                logExprWarning_label.Visible = false;
            }
        }

        /// <summary>
        /// Отображает сообщение с предупреждением, если введенное количество задач типа «Исследование тригонометрических функций» некорректно. 
        /// Пробует включить кнопку «СГЕНЕРИРОВАТЬ ЗАДАЧИ» 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trigExpr_textBox_TextChanged(object sender, EventArgs e)
        {
            TryToEnableButton();

            uint tempValue;

            if (trigExpr_textBox.Text == "")
            {
                trigExprWarning_label.Visible = false;
            }
            else if (!uint.TryParse(trigExpr_textBox.Text, out tempValue))
            {
                trigExprWarning_label.Visible = true;
                generate_button.Enabled = false;
            }
            else
            {
                trigExprWarning_label.Visible = false;
            }
        }

        /// <summary>
        /// Отображает сообщение с предупреждением, если введенное количество задач типа «Исследование функций без помощи производной» некорректно. 
        /// Пробует включить кнопку «СГЕНЕРИРОВАТЬ ЗАДАЧИ» 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notDerivativeExpr_textBox_TextChanged(object sender, EventArgs e)
        {
            TryToEnableButton();

            uint tempValue;

            if (notDerivativeExpr_textBox.Text == "")
            {
                notDerivativeExprWarning_label.Visible = false;
            }
            else if (!uint.TryParse(notDerivativeExpr_textBox.Text, out tempValue))
            {
                notDerivativeExprWarning_label.Visible = true;
                generate_button.Enabled = false;
            }
            else
            {
                notDerivativeExprWarning_label.Visible = false;
            }
        }

        /// <summary>
        /// Генерирует HTML документ с задачами выбранных пользователем типа в заданном пользователем количеством вариантов
        /// и количеством каждого типа задач в вариантею
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generate_button_Click(object sender, EventArgs e)
        {
            // Список всех генераторов, которые будут использоваться при генерации вариантов.
            List<Generators.GeneratorDelegate> generatorsList = new List<Generators.GeneratorDelegate>();

            // Определение количества выражений каждого типа в варианте.
            uint numOfPowerExpr = uint.TryParse(powerExpr_textBox.Text, out numOfPowerExpr) == false ? 0 : numOfPowerExpr;
            uint numOfQuotientExpr = uint.TryParse(quotientExpr_textBox.Text, out numOfQuotientExpr) == false ? 0 : numOfQuotientExpr;
            uint numOfExpExpr = uint.TryParse(expExpr_textBox.Text, out numOfExpExpr) == false ? 0 : numOfExpExpr;
            uint numOfLogExpr = uint.TryParse(logExpr_textBox.Text, out numOfLogExpr) == false ? 0 : numOfLogExpr;
            uint numOfTrigExpr = uint.TryParse(trigExpr_textBox.Text, out numOfTrigExpr) == false ? 0 : numOfTrigExpr;
            uint numOfNotDerivativeExpr = uint.TryParse(notDerivativeExpr_textBox.Text, out numOfNotDerivativeExpr) == false ? 0 : numOfNotDerivativeExpr;

            // Добавление выражений по исследованию степенных и иррациональных функций.
            for (int i = 0; i < numOfPowerExpr; i++)
                generatorsList.Add(Generators.GeneratePowerExpression);

            // Добавление выражений по исследованию частных.
            for (int i = 0; i < numOfQuotientExpr; i++)
                generatorsList.Add(Generators.GenerateQuotientExpression);

            // Добавление выражений по исследованию показательных функций и произведений.
            for (int i = 0; i < numOfExpExpr; i++)
                generatorsList.Add(Generators.GenerateExpExpression);

            // Добавление выражений по исследованию логарифмический функций.
            for (int i = 0; i < numOfLogExpr; i++)
                generatorsList.Add(Generators.GenerateLogExpression);

            // Добавление выражений по исследованию тригонометрических функций.
            for (int i = 0; i < numOfTrigExpr; i++)
                generatorsList.Add(Generators.GenerateTrigonometricExpression);

            // Добавление выражений по исследованию функций без помощи производной.
            for (int i = 0; i < numOfNotDerivativeExpr; i++)
                generatorsList.Add(Generators.GenerateExpressionNotRequiringDerivative);

            // Создание папки, в которой будет храниться HTML документ.
            Directory.CreateDirectory(HTML_FILE_DIRECTORY);

            // Создание нового пустого HTML документа.
            DummyHTML HtmlDoc = new DummyHTML();

            // Количество вариантов.
            int tasksNumber = int.Parse(tasksNumber_textBox.Text);

            // Ключ генерации.
            int seed = (int)DateTime.Now.Ticks;
            string stringSeed = $"TC.{tasksNumber}." +
                $"{numOfPowerExpr}.{numOfQuotientExpr}.{numOfExpExpr}." +
                $"{numOfLogExpr}.{numOfTrigExpr}.{numOfNotDerivativeExpr}." +
                $"{seed}";

            // Добавление вариантов выбранных типов задач в HtmlDoc.
            Generators.GenerateHTMLDoc(HtmlDoc, tasksNumber, generatorsList, seed, stringSeed);

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
        /// Проверяет корректность введенных пользователем данных (количество вариантов и количество задач каждого типа в варианте). 
        /// Если данные корректны, то включается кнопка «СГЕНЕРИРОВАТЬ ЗАДАЧИ», иначе – выключается.
        /// </summary>
        private void TryToEnableButton()
        {
            uint tempValue;

            generate_button.Enabled = uint.TryParse(tasksNumber_textBox.Text, out tempValue) &&
                (uint.TryParse(powerExpr_textBox.Text, out tempValue) || uint.TryParse(quotientExpr_textBox.Text, out tempValue) ||
                uint.TryParse(expExpr_textBox.Text, out tempValue) || uint.TryParse(logExpr_textBox.Text, out tempValue) ||
                uint.TryParse(trigExpr_textBox.Text, out tempValue) || uint.TryParse(notDerivativeExpr_textBox.Text, out tempValue));
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
        private void TaskConstructor_FormClosed(object sender, FormClosedEventArgs e)
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
