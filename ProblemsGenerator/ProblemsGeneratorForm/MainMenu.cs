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
    public partial class MainMenu : Form
    {
        // Директория, в котором хранится HTML документ.
        private const string HTML_FILE = "../../../html/pageWithTasks.html";

        // Возможные названия задач.
        private static string[] possibleNamesOfExpression = { "Исследование показательных функций и произведений",
                                                      "Исследование частных",
                                                      "Исследование степенных и иррациональных функций",
                                                      "Исследование логарифмических функций",
                                                      "Исследование тригонометрических функций",
                                                      "Исследование функций без помощи производной" };

        // Тип генератора вариантов.
        private string typeOfVariantsGenerator;
        // Номер выбранного типа выражения.
        private uint numOfTypeOfExpression;
        // Количество вариантов.
        private int tasksNumber;
        // Количество заданий в варианте.
        private int expressionsNumber;
        // Ключ генерациии.
        private int seed;
        private string stringSeed;

        // Количество выражений разных типов.
        private uint numOfPowerExpr;
        private uint numOfQuotientExpr;
        private uint numOfExpExpr;
        private uint numOfLogExpr;
        private uint numOfTrigExpr;
        private uint numOfNotDerivativeExpr;

        /// <summary>
        /// Конструктор главного окна программы.
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка главного окна программы. Задает ширину и высоту рамки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.Width = 1550;
            this.Height = 950;
        }

        /// <summary>
        /// Скрывает главное окно приложения и открывает окно «Генератор задач»
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openGenerator_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form generator = new Generator(this);
            generator.Show();
        }

        /// <summary>
        /// Скрывает главное окно приложения и открывает окно «Генератор случайных задач»
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openRandomGenerator_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form randomGenerator = new RandomGenerator(this);
            randomGenerator.Show();
        }

        /// <summary>
        /// Скрывает главное окно приложения и открывает окно «Конструктор вариантов»
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openTaskConstructor_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form taskConstructor = new TaskConstructor(this);
            taskConstructor.Show();
        }

        /// <summary>
        /// Проверяет корректность ввода ключа генерации и заполняет необходимые для генерации набора вариантов поля.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateKey_textBox_TextChanged(object sender, EventArgs e)
        {
            stringSeed = generateKey_textBox.Text;
            string[] seedDecoder = generateKey_textBox.Text.Split('.');

            try
            {
                for (int i = 0; i < 1; i++)
                {
                    if (seedDecoder[0] == "G")
                    {
                        typeOfVariantsGenerator = "G";

                        if (!uint.TryParse(seedDecoder[1], out numOfTypeOfExpression) || !(int.TryParse(seedDecoder[2], out tasksNumber)) ||
                            !int.TryParse(seedDecoder[3], out expressionsNumber) || !int.TryParse(seedDecoder[4], out seed) ||
                            seedDecoder.Length != 5)
                        {
                            generateKeyWarning_label.Visible = true;
                            generateKey_button.Enabled = false;
                            break;
                        }

                        generateKeyWarning_label.Visible = false;
                        generateKey_button.Enabled = true;
                    }
                    else if (seedDecoder[0] == "GR")
                    {
                        typeOfVariantsGenerator = "GR";

                        if (!int.TryParse(seedDecoder[1], out tasksNumber) || !int.TryParse(seedDecoder[2], out expressionsNumber) ||
                            !int.TryParse(seedDecoder[3], out seed) || seedDecoder.Length != 4)
                        {
                            generateKeyWarning_label.Visible = true;
                            generateKey_button.Enabled = false;
                            break;
                        }

                        generateKeyWarning_label.Visible = false;
                        generateKey_button.Enabled = true;
                    }
                    else if (seedDecoder[0] == "TC")
                    {
                        typeOfVariantsGenerator = "TC";

                        if (!int.TryParse(seedDecoder[1], out tasksNumber) ||
                            !uint.TryParse(seedDecoder[2], out numOfPowerExpr) || !uint.TryParse(seedDecoder[3], out numOfQuotientExpr) ||
                            !uint.TryParse(seedDecoder[4], out numOfExpExpr) || !uint.TryParse(seedDecoder[5], out numOfLogExpr) ||
                            !uint.TryParse(seedDecoder[6], out numOfTrigExpr) || !uint.TryParse(seedDecoder[7], out numOfNotDerivativeExpr) ||
                            !int.TryParse(seedDecoder[8], out seed) || seedDecoder.Length != 9)
                        {
                            generateKeyWarning_label.Visible = true;
                            generateKey_button.Enabled = false;
                            break;
                        }

                        generateKeyWarning_label.Visible = false;
                        generateKey_button.Enabled = true;
                    }
                    else
                    {
                        generateKeyWarning_label.Visible = true;
                        generateKey_button.Enabled = false;
                        break;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                generateKeyWarning_label.Visible = true;
                generateKey_button.Enabled = false;
            }
        }

        /// <summary>
        /// Генерирует набор вариантов по ключу генерации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateKey_button_Click(object sender, EventArgs e)
        {
            // Создание нового пустого HTML документа.
            DummyHTML HtmlDoc = new DummyHTML();

            if (typeOfVariantsGenerator == "G")
            {
                // Добавление вариантов выбранного пользователем типа задач в HtmlDoc.
                Generators.GenerateHTMLDoc(HtmlDoc,
                    tasksNumber, expressionsNumber,
                    seed, stringSeed, possibleNamesOfExpression[numOfTypeOfExpression]);
            }
            else if (typeOfVariantsGenerator == "GR")
            {
                // Добавление вариантов случайного типа задач в HtmlDoc.
                Generators.GenerateHTMLDoc(HtmlDoc,
                    tasksNumber, expressionsNumber, seed: seed, stringSeed: stringSeed);
            }
            else if (typeOfVariantsGenerator == "TC")
            {
                // Добавление вариантов выбранных типов задач в HtmlDoc.

                // Список всех генераторов, которые будут использоваться при генерации вариантов.
                List<Generators.GeneratorDelegate> generatorsList = new List<Generators.GeneratorDelegate>();

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

                Generators.GenerateHTMLDoc(HtmlDoc, tasksNumber, generatorsList, seed, stringSeed);
            }

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
