using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLib;

namespace Utils
{
    public class Utils
    {
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        public static Random random = new Random();

        // Делегат генератора функции.
        delegate string[] GeneratorDelegate();

        // Делегат выражения функции.
        delegate double Expression<T>(T x);

        /// <summary>
        /// Генерация выражения вида (a * x + b) * exp^(c * x + d).
        /// </summary>
        /// <returns></returns>
        private static string[] GenerateExpExpression()
        {
            // Генерация происходит при помощи равенства ans = -b / a - 1 / c.
            // Возможные задачи.
            string[] possibleTasks = { "Найти точку <b><u>минимума</u></b> функции", "Найти точку <b><u>максимума</u></b> функции" };

            // Генерация нуля производной.
            int funcZero = Utils.random.Next(-10, 11);

            // Генерация коэффициента c, не равного нулю.
            int c;
            int[] possibleC = { Utils.random.Next(-10, 0), Utils.random.Next(1, 11) };
            c = possibleC[Utils.random.Next(possibleC.Length)];

            // Создание дроби 1 / c.
            Fraction divideC = new Fraction(1, c);

            // Создание дроби -b / a. Числитель и знаменатель умножается на число [1, 3], чтобы не всегда c = a.
            Fraction minusBDivideA = (funcZero + divideC).IncreaseNumAndDenumBy(random.Next(1, 4));

            // Коэффициенты b и a.
            int b = -minusBDivideA.Numerator;
            int a = minusBDivideA.Denominator;

            // Коэффициент d может быть любым, он не влияет на решение задачи.
            int d = Utils.random.Next(-100, 101);

            // Отрезок, на котором надо найти точку минимума или максимума.
            int[] segment = { funcZero - Utils.random.Next(1, 6), funcZero + Utils.random.Next(1, 6) };

            // Что надо найти: точку минимума или максимума?
            // 0 - минимума, 1 - максимума.
            int taskID = Utils.random.Next(possibleTasks.Length);

            // Функция.
            Expression<int> expr = (x) => { return (a * x + b) * Math.Exp(c * x + d); };

            // Нахождение ответа и определение условия задачи.
            int ans = GetTaskAnswer(expr, new List<int> { segment[0], segment[1], funcZero }, taskID); // .ToArray() работает долго, может, стоит заменить на что-нибудь другое?
            string task = possibleTasks[taskID];

            // Вывод сгенерированного выражения в виде LaTeX и ответа.
            string taskCondition = $"{task}";
            string taskExpression = $"$$ ({a}x + {b})e^" + "{" + $"({c}x + {d})" + "}" + $"$$ на отрезке [{segment[0]}, {segment[1]}]";
            string taskAnswer = ($"Ответ: {ans}");

            return new string[] { taskCondition, taskExpression, taskAnswer };
        }

        /// <summary>
        /// Генерация выражения вида a * x^3 + b * x^2 + c * x + d.
        /// </summary>
        /// <returns></returns>
        private static string[] GeneratePowerExpression()
        {
            // Возможные задачи.
            string[] possibleTasks = { "Найти точку <b><u>минимума</u></b> функции", "Найти точку <b><u>максимума</u></b> функции" };

            // Генерация происходит при помощи трех равенств. Выбор этого равенства:
            int chance = random.Next(0, 3);

            if (chance == 0)
            {
                // Раверство: x = 0 ИЛИ x = (-2 * b) / (3 * a) (случай, если c = 0).

                // Инициализация переменных, в которых будут храниться точки экстремум.
                // В данном случае одна из точек всегда равна нулю.
                int extr1 = 0;
                int extr2;

                // Генерация коэффициента a, не равного нулю.
                int a;
                int[] possibleA = { Utils.random.Next(-10, 0), Utils.random.Next(1, 11) };
                a = possibleA[Utils.random.Next(possibleA.Length)];

                // b = k * 3 * a (чтобы экстремума была красивым числом, а не дробью).
                // Генерация коэффициента k, не равного нулю.
                int k;
                int[] possibleK = { Utils.random.Next(-10, 0), Utils.random.Next(1, 11) };
                k = possibleK[Utils.random.Next(possibleK.Length)];

                int b = k * 3 * a;

                // Нахождение второй точки экстремума.
                extr2 = (-2 * b) / (3 * a);

                // Создание массива из точек экстремум.
                int[] extrs = { extr1, extr2 };
                Array.Sort(extrs);

                // Коэффициент d может быть любым, он не влияет на решение задачи.
                int d = Utils.random.Next(-100, 101);

                // Отрезок, на котором надо найти точку минимума или максимума.
                int[] segment = { extrs[0] - Utils.random.Next(1, 6), extrs[1] + Utils.random.Next(1, 6) };

                // Что надо найти: точку минимума или максимума?
                // 0 - минимума, 1 - максимума.
                int taskID = Utils.random.Next(possibleTasks.Length);

                // Функция.
                Expression<int> expr = (x) => { return a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + d; };

                // Нахождение ответа и определение условия задачи.
                int ans = GetTaskAnswer(expr, new List<int> { segment[0], segment[1], extrs[0], extrs[1]}, taskID ); // .ToArray() работает долго, может, стоит заменить на что-нибудь другое?
                string task = possibleTasks[taskID];

                // Вывод сгенерированного выражения в виде LaTeX и ответа.
                string taskCondition = $"{task}";
                string taskExpression = $"$$ {a}x^3 + {b}x^2 + {d} $$ на отрезке [{segment[0]}, {segment[1]}]";
                string taskAnswer = ($"Ответ: {ans}");

                return new string[] { taskCondition, taskExpression, taskAnswer };
            }
            else if (chance == 1)
            {
                // Раверство: x = ±\sqrt{-c / (3 * a)} (случай, если b = 0).

                // Инициализация переменных, в которых будут храниться точки экстремум.
                int extr1, extr2;

                // Генерация коэффициента a, не равного нулю.
                int a;
                int[] possibleA = { Utils.random.Next(-10, 0), Utils.random.Next(1, 11) };
                a = possibleA[Utils.random.Next(possibleA.Length)];

                // c = k * 3 * a, где k - квадрат числа.
                // Генерация коэффициента c.
                // Так как под корнем должно быть неотриательное число, то c должен быть противоположного от a знака.
                int c = (int)Math.Pow(random.Next(0, 6), 2) * 3 * a;
                c = a > 0 ? -c : c;

                // Нахождение точек экстремум. Данные числа будут гарантированно целыми, так как создавались "удобные" коэффициенты.
                extr1 = (int)Math.Sqrt(-c / (3 * a));
                extr2 = -extr1;

                // Создание массива из точек экстремум.
                int[] extrs = { extr1, extr2 };
                Array.Sort(extrs);

                // Коэффициент d может быть любым, он не влияет на решение задачи.
                int d = Utils.random.Next(-100, 101);

                // Отрезок, на котором надо найти точку минимума или максимума.
                int[] segment = { extrs[0] - Utils.random.Next(1, 6), extrs[1] + Utils.random.Next(1, 6) };

                // Что надо найти: точку минимума или максимума?
                // 0 - минимума, 1 - максимума.
                int taskID = Utils.random.Next(possibleTasks.Length);

                // Функция.
                Expression<int> expr = (x) => { return a * Math.Pow(x, 3) + c * x + d; };

                // Нахождение ответа и определение условия задачи.
                int ans = GetTaskAnswer(expr, new List<int> { segment[0], segment[1], extrs[0], extrs[1] }, taskID); // .ToArray() работает долго, может, стоит заменить на что-нибудь другое?
                string task = possibleTasks[taskID];

                // Вывод сгенерированного выражения в виде LaTeX и ответа.
                string taskCondition = $"{task}";
                string taskExpression = $"$$ {a}x^3 + {c}x + {d} $$ на отрезке [{segment[0]}, {segment[1]}]";
                string taskAnswer = ($"Ответ: {ans}");

                return new string[] { taskCondition, taskExpression, taskAnswer };
            }
            else
            { 
                // Равенство: x = -c / (2 * b) (случай, если a = 0).

                // Инициализация переменной, в которой будет храниться точка экстремума.
                int extr;

                // Генерация коэффициента b, не равного нулю.
                int b;
                int[] possibleB = { Utils.random.Next(-10, 0), Utils.random.Next(1, 11) };
                b = possibleB[Utils.random.Next(possibleB.Length)];

                // c = k * 2 * b.
                // Генерация коэффициента c.
                int c = random.Next(0, 11) * 2 * b;

                // Нахождение точки экстремума.
                extr = -c / (2 * b);

                // Коэффициент d может быть любым, он не влияет на решение задачи.
                int d = Utils.random.Next(-100, 101);

                // Отрезок, на котором надо найти точку минимума или максимума.
                int[] segment = { extr - Utils.random.Next(1, 6), extr + Utils.random.Next(1, 6) };

                // Что надо найти: точку минимума или максимума?
                // 0 - минимума, 1 - максимума.
                int taskID = Utils.random.Next(possibleTasks.Length);

                // Функция.
                Expression<int> expr = (x) => { return b * Math.Pow(x, 2) + c * x + d; };

                // Нахождение ответа и определение условия задачи.
                int ans = GetTaskAnswer(expr, new List<int> { segment[0], segment[1], extr }, taskID); // .ToArray() работает долго, может, стоит заменить на что-нибудь другое?
                string task = possibleTasks[taskID];

                // Вывод сгенерированного выражения в виде LaTeX и ответа.
                string taskCondition = $"{task}";
                string taskExpression = $"$$ {b}x^2 + {c}x + {d} $$ на отрезке [{segment[0]}, {segment[1]}]";
                string taskAnswer = ($"Ответ: {ans}");

                return new string[] { taskCondition, taskExpression, taskAnswer };
            }
        }

        /// <summary>
        /// Генерация выражения вида n * ln(a * x + b) + c * x^2 + d * x + e.
        /// </summary>
        /// <returns></returns>
        private static string[] GenerateLogExpression()
        {
            // Возможные задачи.
            string[] possibleTasks = { "Найти точку <b><u>минимума</u></b> функции", "Найти точку <b><u>максимума</u></b> функции" };

            // Генерация происходит при помощи трех равенств. Выбор этого равенства:
            int chance = random.Next(0, 2);

            // if (chance == 0)
            // Равенство: x = -(n / (a * d) + b / a) (случай, если c = 0).
            // Условие, чтобы подлогарифмическое выражение было больше нуля: ((-n * a) / d) > 0.

            // Инициализация переменной, в которой будет храниться точка экстремума.
            int extr;

            // Генерация коэффициентов a и d, не равных нулю.
            int a, d;
            int[] possibleA = { random.Next(-10, 0), random.Next(1, 11) };
            int[] possibleD = { random.Next(-10, 0), random.Next(1, 11) };
            a = possibleA[random.Next(possibleA.Length)];
            d = possibleD[random.Next(possibleD.Length)];

            // n = k * a * d.
            // Генерация коэффициента n, не равного нулю.
            int n = random.Next(1, 4) * a * d;
            n = a * d > 0 ? (n > 0 ? -n : n) : (n > 0 ? n : -n);

            // b = m * a.
            // Генерация коэффициента b.
            int b = -random.Next(-10, 11) * a;

            // Коэффициент e может быть любым, он не влияет на решение задачи.
            int e = Utils.random.Next(-100, 101);

            // Нахождение точки экстремума.
            extr = -(n / d + b / a);

            // Отрезок, на котором надо найти точку минимума или максимума.
            // Во всех найденных мной задачах избегают случая, где a * x + b = 0 (не включают такой x в отрезок).

            // Нахождение a * x + b = 0. Причем a * x + b > 0.
            Fraction frac = (new Fraction(-b, a)).IncreaseNumAndDenumBy(2);

            Fraction[] segment;

            if (extr > frac.ToDouble())
            {
                segment = new Fraction[] { extr - new Fraction(Math.Abs(random.Next(1, extr * frac.Denominator - frac.Numerator + 1)), frac.Denominator), 
                    new Fraction(extr) + Utils.random.Next(1, 6) };
            }
            else
            {
                segment = new Fraction[] { new Fraction(extr) - Utils.random.Next(1, 6), 
                    extr + new Fraction(Math.Abs(random.Next(1, frac.Numerator - extr * frac.Denominator)), frac.Denominator) };
            }

            // Что надо найти: точку минимума или максимума?
            // 0 - минимума, 1 - максимума.
            int taskID = Utils.random.Next(possibleTasks.Length);

            // Функция.
            Expression<Fraction> expr = (x) => { return n * Math.Log((a * x + b).ToDouble()) + (d * x).ToDouble() + e; };

            // Нахождение ответа и определение условия задачи.
            var ans = GetTaskAnswer(expr, new List<Fraction> { segment[0], segment[1], new Fraction(extr)}, taskID); // .ToArray() работает долго, может, стоит заменить на что-нибудь другое?
            string task = possibleTasks[taskID];

            // Вывод сгенерированного выражения в виде LaTeX и ответа.
            string taskCondition = $"{task}";
            string taskExpression = $"$$ {n}\\ln({a}x + {b}) + {d}x + {e} $$ на отрезке [{segment[0]}, {segment[1]}]";
            string taskAnswer = ($"Ответ: {ans}");

            return new string[] { taskCondition, taskExpression, taskAnswer };
        }

        /// <summary>
        /// Возвращает ответ на задачу.
        /// </summary>
        /// <param name="expr">Выражение задачи</param>
        /// <param name="koefA">Коэффициент A</param>
        /// <param name="koefB">Коэффициент B</param>
        /// <param name="koefC">Коэффициент C</param>
        /// <param name="koefD">Коэффициент D</param>
        /// <param name="possibleAnswers">Возможные ответы на задачу</param>
        /// <param name="taskID">Идентификатор задания</param>
        /// <returns></returns>
        private static T1 GetTaskAnswer<T1>(Expression<T1> expr, List<T1> possibleAnswers, int taskID)
        {
            // Инициализация списка со всеми возможными значениями функции expr.
            List<double> values = new List<double>();

            // Заполнение списка всеми возможными значениями функции expr.
            for (int i = 0; i < possibleAnswers.Count; i++)
            {
                values.Add(expr(possibleAnswers[i]));
            }

            // Нахождение ответа задачи.
            int ans;

            if (taskID == 0)
            {
                // Если надо найти минимум функции.
                double minValue = values.Min();

                for (int i = 0; i < values.Count; i++)
                {
                    if (minValue == values[i])
                    {
                        return possibleAnswers[i];
                    }
                }
            }
            else
            {
                // Если надо найти максимум функции.
                double maxValue = values.Max();

                for (int i = 0; i < values.Count; i++)
                {
                    if (maxValue == values[i])
                    {
                        return possibleAnswers[i];
                    }
                }
            }

            throw new Exception("Ответ не найден!");
        }

        /// <summary>
        /// Генерирует HTML документ с заданиями.
        /// </summary>
        /// <param name="typeOfExpression">Тип запрашиваемых выражений</param>
        /// <param name="HtmlDoc">Документ, куда добавляются новые задания</param>
        /// <param name="numOfTasks">Количество вариантов</param>
        /// <param name="numOfExpressions">Количество задач</param>
        public static void generateHTMLDoc(string typeOfExpression, DummyHTML HtmlDoc, int numOfTasks, int numOfExpressions)
        {
            // Обнуление делегата.
            GeneratorDelegate generatorFunc = null;

            // Выбор задачи.
            if (typeOfExpression == "Исследование показательных функций и произведений")
            {
                generatorFunc = GenerateExpExpression;
            }
            else if(typeOfExpression == "Исследование степенных и иррациональных функций")
            {
                generatorFunc = GeneratePowerExpression;
            }
            else if(typeOfExpression == "Исследование логарифмических функций")
            {
                generatorFunc = GenerateLogExpression;
            }

            AddTasksToHtml(generatorFunc, HtmlDoc, numOfTasks, numOfExpressions);
        }

        /// <summary>
        /// Добавляет в Html документ новые задания.
        /// </summary>
        /// <param name="generatorFunc">Генератор новых заданий</param>
        /// <param name="HtmlDoc">Документ, куда добавляются новые задания</param>
        /// <param name="numOfTasks">Количество вариантов</param>
        /// <param name="numOfExpressions">Количество задач</param>
        private static void AddTasksToHtml(GeneratorDelegate generatorFunc, DummyHTML HtmlDoc, int numOfTasks, int numOfExpressions)
        {
            if (numOfExpressions == 1)
            {
                for (int i = 0; i < numOfTasks; i++)
                {
                    string[] task = generatorFunc();

                    HtmlDoc.AddTag("div", "task_wrapper", HtmlDoc.CreateTag("div", "taskVariant", $"Вариант {i + 1}") +
                                    Environment.NewLine + HtmlDoc.CreateTag("div", "taskCondition", task[0]) +
                                    Environment.NewLine + HtmlDoc.CreateTag("div", "taskExpression", task[1] +
                                    Environment.NewLine + HtmlDoc.CreateTag("div", "taskAnswer", task[2])));
                }
            }
            else
            {
                StringBuilder tasks = new StringBuilder();

                for (int i = 0; i < numOfTasks; i++)
                {
                    tasks = new StringBuilder();

                    for (int j = 0; j < numOfExpressions; j++)
                    {
                        string[] task = generatorFunc();

                        string tempTask = HtmlDoc.CreateTag("div", "taskCondition", (char)('а' + j) + ") " + task[0]) +
                            Environment.NewLine + HtmlDoc.CreateTag("div", "taskExpression", task[1]) +
                            Environment.NewLine + HtmlDoc.CreateTag("div", "taskAnswer", task[2]);

                        tasks.Append(tempTask);
                    }
                    HtmlDoc.AddTag("div", "task_wrapper", HtmlDoc.CreateTag("div", "taskVariant", $"Вариант {i + 1}") +
                        Environment.NewLine + tasks.ToString());
                }
            }
        }
    }
}
