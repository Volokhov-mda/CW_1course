using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLib;

namespace ClassLib
{
    public class Generators
    {
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        public static Random random;

        // Возможные названия задач.
        private static string[] possibleNamesOfExpression = { "Исследование показательных функций и произведений",
                                                      "Исследование частных",
                                                      "Исследование степенных и иррациональных функций",
                                                      "Исследование логарифмических функций",
                                                      "Исследование тригонометрических функций",
                                                      "Исследование функций без помощи производной" };

        // Возможные генераторы задач.
        private static GeneratorDelegate[] possibleGeneratorsOfExpression = { GenerateExpExpression,
                                                                      GenerateQuotientExpression,
                                                                      GeneratePowerExpression,
                                                                      GenerateLogExpression,
                                                                      GenerateTrigonometricExpression,
                                                                      GenerateExpressionNotRequiringDerivative };

        // Возможные задачи.
        private static string[] possibleTasks = { "Найти точку <b><u>минимума</u></b> функции", "Найти точку <b><u>максимума</u></b> функции" };

        // Делегат генератора функции.
        public delegate string[] GeneratorDelegate();

        // Делегат выражения функции.
        delegate double Expression<T>(T x);

        /// <summary>
        /// Генерирует выражение вида a * x^3 + b * x^2 + c * x + d.
        /// </summary>
        /// <returns></returns>
        public static string[] GeneratePowerExpression()
        {
            // Инициализация необходимых переменных для генерации задач.
            string task, aToShow, bToShow, cToShow, dToShow;
            int[] segment;
            int ans;

            // Генерация происходит при помощи трех равенств. Выбор этого равенства:
            int chance = random.Next(0, 3);

            if (chance == 0)
            {
                // Равенство: extr1 = 0 И extr2 = (-2 * b) / (3 * a) (случай, если c = 0).

                // Инициализация переменных, в которых будут храниться точки экстремум.
                // В данном случае одна из точек всегда равна нулю.
                int extr1 = 0;
                int extr2;

                // Генерация коэффициента a, не равного нулю.
                int a;
                int[] possibleA = { Generators.random.Next(-10, 0), Generators.random.Next(1, 11) };
                a = possibleA[Generators.random.Next(possibleA.Length)];

                // b = k * 3 * a (чтобы экстремума была красивым числом, а не дробью).
                // Генерация коэффициента k, не равного нулю.
                int k;
                int[] possibleK = { Generators.random.Next(-10, 0), Generators.random.Next(1, 11) };
                k = possibleK[Generators.random.Next(possibleK.Length)];

                int b = k * 3 * a;

                // Нахождение второй точки экстремума.
                extr2 = (-2 * b) / (3 * a);

                // Создание массива из точек экстремум.
                int[] extrs = { extr1, extr2 };
                Array.Sort(extrs);

                // Коэффициент d может быть любым, он не влияет на решение задачи.
                int d = Generators.random.Next(-100, 101);

                // Отрезок, на котором надо найти точку минимума или максимума.
                segment = new int[] { extrs[0] - Generators.random.Next(1, 6), extrs[1] + Generators.random.Next(1, 6) };

                // Что надо найти: точку минимума или максимума?
                // 0 - минимума, 1 - максимума.
                int taskID = Generators.random.Next(possibleTasks.Length);

                // Функция.
                Expression<int> expr = (x) => { return a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + d; };

                // Нахождение ответа и определение условия задачи.
                ans = GetTaskAnswer(expr, new List<int> { segment[0], segment[1], extrs[0], extrs[1] }, taskID); // .ToArray() работает долго, может, стоит заменить на что-нибудь другое?
                task = possibleTasks[taskID];

                // Формирование коэфициентов в виде строк.
                aToShow = $"{(a == 1 ? "" : (a == -1 ? "-" : a.ToString()))}x^3";
                bToShow = $"{(Math.Sign(b) == -1 ? $"- {(Math.Abs(b) == 1 ? "" : Math.Abs(b).ToString())}" : $"+ {(Math.Abs(b) == 1 ? "" : Math.Abs(b).ToString())}")}x^2";
                cToShow = "";
                dToShow = $"{(d == 0 ? "" : (Math.Sign(d) == -1 ? $"- {Math.Abs(d)}" : $"+ {d}"))}";
            }
            else if (chance == 1)
            {
                // Равенство: extr = ±\sqrt{-c / (3 * a)} (случай, если b = 0).

                // Инициализация переменных, в которых будут храниться точки экстремум.
                int extr1, extr2;

                // Генерация коэффициента a, не равного нулю.
                int a;
                int[] possibleA = { Generators.random.Next(-10, 0), Generators.random.Next(1, 11) };
                a = possibleA[Generators.random.Next(possibleA.Length)];

                // c = k * 3 * a, где k - квадрат числа.
                // Генерация коэффициента c, не равного нулю.
                // Так как под корнем должно быть неотриательное число, то c должен быть противоположного от a знака.
                int c = (int)Math.Pow(random.Next(1, 6), 2) * 3 * a;
                c = Math.Sign(c) == Math.Sign(a) ? -c : c;

                // Нахождение точек экстремум. Данные числа будут гарантированно целыми, так как создавались "удобные" коэффициенты.
                extr1 = (int)Math.Sqrt(-c / (3 * a));
                extr2 = -extr1;

                // Создание массива из точек экстремум.
                int[] extrs = { extr1, extr2 };
                Array.Sort(extrs);

                // Коэффициент d может быть любым, он не влияет на решение задачи.
                int d = Generators.random.Next(-100, 101);

                // Отрезок, на котором надо найти точку минимума или максимума.
                segment = new int[] { extrs[0] - Generators.random.Next(1, 6), extrs[1] + Generators.random.Next(1, 6) };

                // Что надо найти: точку минимума или максимума?
                // 0 - минимума, 1 - максимума.
                int taskID = Generators.random.Next(possibleTasks.Length);

                // Функция.
                Expression<int> expr = (x) => { return a * Math.Pow(x, 3) + c * x + d; };

                // Нахождение ответа и определение условия задачи.
                ans = GetTaskAnswer(expr, new List<int> { segment[0], segment[1], extrs[0], extrs[1] }, taskID); // .ToArray() работает долго, может, стоит заменить на что-нибудь другое?
                task = possibleTasks[taskID];

                // Формирование коэфициентов в виде строк.
                aToShow = $"{(a == 1 ? "" : (a == -1 ? "-" : a.ToString()))}x^3";
                bToShow = "";
                cToShow = $"{(Math.Sign(c) == -1 ? $"- {(Math.Abs(c) == 1 ? "" : Math.Abs(c).ToString())}" : $"+ {(Math.Abs(c) == 1 ? "" : Math.Abs(c).ToString())}")}x";
                dToShow = $"{(d == 0 ? "" : (Math.Sign(d) == -1 ? $"- {Math.Abs(d)}" : $"+ {d}"))}";
            }
            else
            {
                // Равенство: extr = -c / (2 * b) (случай, если a = 0).

                // Инициализация переменной, в которой будет храниться точка экстремума.
                int extr;

                // Генерация коэффициента b, не равного нулю.
                int b;
                int[] possibleB = { Generators.random.Next(-10, 0), Generators.random.Next(1, 11) };
                b = possibleB[Generators.random.Next(possibleB.Length)];

                // c = k * 2 * b.
                // Генерация коэффициента c.
                int c = random.Next(1, 11) * 2 * b;
                c = random.Next(2) == 0 ? c : -c;

                // Нахождение точки экстремума.
                extr = -c / (2 * b);

                // Коэффициент d может быть любым, он не влияет на решение задачи.
                int d = Generators.random.Next(-100, 101);

                // Отрезок, на котором надо найти точку минимума или максимума.
                segment = new int[] { extr - Generators.random.Next(1, 6), extr + Generators.random.Next(1, 6) };

                // Что надо найти: точку минимума или максимума?
                // 0 - минимума, 1 - максимума.
                int taskID = Generators.random.Next(possibleTasks.Length);

                // Функция.
                Expression<int> expr = (x) => { return b * Math.Pow(x, 2) + c * x + d; };

                // Нахождение ответа и определение условия задачи.
                ans = GetTaskAnswer(expr, new List<int> { segment[0], segment[1], extr }, taskID); // .ToArray() работает долго, может, стоит заменить на что-нибудь другое?
                task = possibleTasks[taskID];

                // Формирование коэфициентов в виде строк.
                aToShow = "";
                bToShow = $"{(b == 1 ? "" : (b == -1 ? "-" : b.ToString()))}x^2";
                cToShow = $"{(Math.Sign(c) == -1 ? $"- {(Math.Abs(c) == 1 ? "" : Math.Abs(c).ToString())}" : $"+ {(Math.Abs(c) == 1 ? "" : Math.Abs(c).ToString())}")}x";
                dToShow = $"{(d == 0 ? "" : (Math.Sign(d) == -1 ? $"- {Math.Abs(d)}" : $"+ {d}"))}";
            }

            // Вывод сгенерированного выражения в виде LaTeX и ответа.
            string taskCondition = $"{task}";
            string taskExpression = $"$$ {aToShow} {bToShow} {cToShow} {dToShow} $$ на отрезке [{segment[0]}, {segment[1]}]";
            string taskAnswer = ($"Ответ: {ans}");

            return new string[] { taskCondition, taskExpression, taskAnswer };
        }

        /// <summary>
        /// Генерирует выражение вида (a + b * x^2) / (x) + c (= a / x + b * x + c)
        /// </summary>
        /// <returns></returns>
        public static string[] GenerateQuotientExpression()
        {
            // Равенство: extr = ±\sqrt{a / b}.
            // a и b имеют одинаковый знак.

            // Инициализация переменных, в которых будут храниться точки экстремум.
            int extr1, extr2;

            // Генерация коэффициента b, не равного нулю.
            int b;
            int[] possibleB = { Generators.random.Next(-10, 0), Generators.random.Next(1, 11) };
            b = possibleB[random.Next(possibleB.Length)];

            // a = k * b, не равного нулю, где k - квадрат числа.
            int a = (int)Math.Pow(random.Next(1, 6), 2) * b;

            // Коэффициент c может быть любым, он не влияет на решение задачи.
            int c = Generators.random.Next(-100, 101);

            // Экстремума - целое число, так как a / b - гарантированно полный квадрат.
            extr1 = (int)Math.Sqrt(a / b);
            extr2 = -extr1;

            // Создание массива из точек экстремум.
            int[] extrs = { extr1, extr2 };
            Array.Sort(extrs);

            int[] segment = { extrs[0] - random.Next(0, 6), extrs[1] + random.Next(0, 6) };

            // Так как в точке 0 существует разрыв, то если один из концов отрезка = 0, то прибавляется/вычитается 1.
            segment[0] = segment[0] == 0 ? segment[0] - 1 : segment[0];
            segment[1] = segment[1] == 0 ? segment[1] + 1 : segment[1];

            // Что надо найти: точку минимума или максимума?
            // 0 - минимума, 1 - максимума.
            int taskID = Generators.random.Next(possibleTasks.Length);

            // Функция.
            Expression<int> expr = (x) => { return a / x + b * x + c; };

            // Нахождение ответа и определение условия задачи.
            int ans = GetTaskAnswer(expr, new List<int> { segment[0], segment[1], extrs[0], extrs[1] }, taskID); // .ToArray() работает долго, может, стоит заменить на что-нибудь другое?
            string task = possibleTasks[taskID];

            // Формирование коэфициентов в виде строк.
            string aToShow = $"{(a == 1 ? "" : (a == -1 ? "-" : a.ToString()))}";
            string bToShow = $"{(Math.Sign(b) == -1 ? $"- {(Math.Abs(b) == 1 ? "" : Math.Abs(b).ToString())}" : $"+ {(Math.Abs(b) == 1 ? "" : Math.Abs(b).ToString())}")}";
            string cToShow = $"{(c == 0 ? "" : (Math.Sign(c) == -1 ? $"- {Math.Abs(c)}" : $"+ {c}"))}";

            // Вывод сгенерированного выражения в виде LaTeX и ответа.
            string taskCondition = $"{task}";
            // Выбор одной из друх записей сгенерированного выражения.
            string taskExpression = (random.Next(2) == 0 ?
                $"$$ \\frac{{{aToShow} {bToShow}x^2}}x {cToShow} $$" : $"$$ \\frac{{{aToShow}}}x {bToShow}x {cToShow} $$") +
                $"на отрезке [{segment[0]}, {segment[1]}]";
            string taskAnswer = ($"Ответ: {ans}");

            return new string[] { taskCondition, taskExpression, taskAnswer };
        }

        /// <summary>
        /// Генерирует выражение вида (a * x + b) * e^(c * x + d).
        /// </summary>
        /// <returns></returns>
        public static string[] GenerateExpExpression()
        {
            // Генерация происходит при помощи равенства ans = -b / a - 1 / c.

            // Генерация точки экстремумы.
            int extr = Generators.random.Next(-10, 11);

            // Генерация коэффициента c, не равного нулю.
            int c;
            int[] possibleC = { Generators.random.Next(-10, 0), Generators.random.Next(1, 11) };
            c = possibleC[Generators.random.Next(possibleC.Length)];

            // Создание дроби 1 / c.
            Fraction divideC = new Fraction(1, c);

            // Создание дроби -b / a. Числитель и знаменатель умножается на число [1, 3], чтобы не всегда c = a.
            Fraction minusBDivideA = (extr + divideC).IncreaseNumAndDenumBy(random.Next(1, 4));

            // Коэффициенты b и a.
            int b = -(int)minusBDivideA.Numerator;
            int a = (int)minusBDivideA.Denominator;

            // Коэффициент d может быть любым, он не влияет на решение задачи.
            int d = Generators.random.Next(-100, 101);

            // Отрезок, на котором надо найти точку минимума или максимума.
            int[] segment = { extr - Generators.random.Next(1, 6), extr + Generators.random.Next(1, 6) };

            // Что надо найти: точку минимума или максимума?
            // 0 - минимума, 1 - максимума.
            int taskID = Generators.random.Next(possibleTasks.Length);

            // Функция.
            Expression<int> expr = (x) => { return (a * x + b) * Math.Exp(c * x + d); };

            // Нахождение ответа и определение условия задачи.
            int ans = GetTaskAnswer(expr, new List<int> { segment[0], segment[1], extr }, taskID);
            string task = possibleTasks[taskID];

            // Формирование коэфициентов в виде строк.
            string aToShow = $"{(a == 1 ? "" : (a == -1 ? "-" : a.ToString()))}x";
            string bToShow = $"{(b == 0 ? "" : (Math.Sign(b) == -1 ? $"- {Math.Abs(b)}" : $"+ {b}"))}";
            string cToShow = $"{(c == 1 ? "" : (c == -1 ? "-" : c.ToString()))}x";
            string dToShow = $"{(d == 0 ? "" : (Math.Sign(d) == -1 ? $"- {Math.Abs(d)}" : $"+ {d}"))}";

            // Вывод сгенерированного выражения в виде LaTeX и ответа.
            string taskCondition = $"{task}";
            string taskExpression = $"$$ ({aToShow} {bToShow})e^{{({cToShow} {dToShow})}} $$ на отрезке [{segment[0]}, {segment[1]}]";
            string taskAnswer = ($"Ответ: {ans}");

            return new string[] { taskCondition, taskExpression, taskAnswer };
        }

        /// <summary>
        /// Генерирует выражение вида n * ln(a * x + b) + c * x + d.
        /// </summary>
        /// <returns></returns>
        public static string[] GenerateLogExpression()
        {
            // Равенство: extr = -(n / c) + b / a).
            // Условие, чтобы подлогарифмическое выражение было больше нуля: ((-n * a) / с) > 0.

            // Инициализация переменной, в которой будет храниться точка экстремума.
            int extr;

            // Генерация коэффициентов a и c, не равных нулю.
            int a, c;
            int[] possibleA = { random.Next(-10, 0), random.Next(1, 11) };
            int[] possibleC = { random.Next(-10, 0), random.Next(1, 11) };
            a = possibleA[random.Next(possibleA.Length)];
            c = possibleC[random.Next(possibleC.Length)];

            // n = k * a * c.
            // Генерация коэффициента n, не равного нулю.
            int n = random.Next(1, 4) * a * c;
            n = a * c > 0 ? (n > 0 ? -n : n) : (n > 0 ? n : -n);

            // b = m * a.
            // Генерация коэффициента b.
            int b = -random.Next(-10, 11) * a;

            // Коэффициент d может быть любым, он не влияет на решение задачи.
            int d = Generators.random.Next(-100, 101);

            // Нахождение точки экстремума.
            extr = -(n / c + b / a);

            // Отрезок, на котором надо найти точку минимума или максимума.
            // Во всех найденных мной задачах избегают случая, где a * x + b <= 0 (не включают такую точку в отрезок).

            // Нахождение a * x + b = 0. Причем a * x + b > 0.
            Fraction frac = (new Fraction(-b, a)).IncreaseNumAndDenumBy(2);

            Fraction[] segment;

            if (extr > frac.ToDouble())
            {
                segment = new Fraction[] { extr - new Fraction(Math.Abs(random.Next(1, (int)(extr * frac.Denominator - frac.Numerator + 1))), frac.Denominator),
                    new Fraction(extr) + Generators.random.Next(1, 6) };
            }
            else
            {
                segment = new Fraction[] { new Fraction(extr) - Generators.random.Next(1, 6),
                    extr + new Fraction(Math.Abs(random.Next(1, (int)(frac.Numerator - extr * frac.Denominator))), frac.Denominator) };
            }

            // Что надо найти: точку минимума или максимума?
            // 0 - минимума, 1 - максимума.
            int taskID = Generators.random.Next(possibleTasks.Length);

            // Функция.
            Expression<Fraction> expr = (x) => { return n * Math.Log((a * x + b).ToDouble()) + (c * x).ToDouble() + d; };

            // Нахождение ответа и определение условия задачи.
            var ans = GetTaskAnswer(expr, new List<Fraction> { segment[0], segment[1], new Fraction(extr) }, taskID);
            string task = possibleTasks[taskID];

            // Формирование коэфициентов в виде строк.
            string aToShow = $"{(a == 1 ? "" : (a == -1 ? "-" : a.ToString()))}x";
            string bToShow = $"{(b == 0 ? "" : (Math.Sign(b) == -1 ? $"- {Math.Abs(b)}" : $"+ {b}"))}";
            string cToShow = $"{(Math.Sign(c) == -1 ? $"- {(Math.Abs(c) == 1 ? "" : Math.Abs(c).ToString())}" : $"+ {(Math.Abs(c) == 1 ? "" : Math.Abs(c).ToString())}")}x";
            string dToShow = $"{(d == 0 ? "" : (Math.Sign(d) == -1 ? $"- {Math.Abs(d)}" : $"+ {d}"))}";

            // Вывод сгенерированного выражения в виде LaTeX и ответа.
            string taskCondition = $"{task}";
            string taskExpression = $"$$ {n}\\ln({aToShow} {bToShow}) {cToShow} {dToShow} $$ " +
                $"на отрезке [{segment[0].ToStringLaTeX()}, {segment[1].ToStringLaTeX()}]";
            string taskAnswer = ($"Ответ: {ans.ToStringLaTeX()}");

            return new string[] { taskCondition, taskExpression, taskAnswer };
        }

        /// <summary>
        /// Генерирует выражение вида a * \sin{x} (или \cos{x}) + b * x + c.
        /// </summary>
        /// <returns></returns>
        public static string[] GenerateTrigonometricExpression()
        {
            // Возможные тригонометрические функции.
            string[] trigFuncs = { "sin", "cos" };

            // Какая тригонометрическая функция используется в задаче: sin или cos?
            // 0 - sin, 1 - cos.
            int trigFuncID = random.Next(trigFuncs.Length);

            // Существует два типа задач с тригонометрическими функциями. Выбор этого типа:
            int chance = random.Next(0, 2);

            if (chance == 0)
            {
                // У функции нет экстремумы.
                // Условие: |a| < |b|.

                // Генерация коэффициента a, не равного нулю.
                int a;
                int[] possibleA = { random.Next(-10, 0), random.Next(1, 11) };
                a = possibleA[random.Next(possibleA.Length)];

                // Так как производная (cos)' = -sin, то если выбрана функция cos, необходимо поменять
                // знак коэффициента a для правильного вычисления ответа на задачу.
                int tempA = trigFuncID == 1 ? -a : a;

                // Генерация коэффициента b.
                int b;
                b = (random.Next(2) == 0 ? -1 : 1) *
                    random.Next(Math.Abs(a) + 1, Math.Abs(a) + 12);

                // Коэффициент c может быть любым, он не влияет на решение задачи.
                int c = Generators.random.Next(-100, 101);

                // Генерируется случайный отрезок.
                int randomPoint = random.Next(-10, 11);
                int[] segment = { randomPoint - random.Next(0, 6), randomPoint + random.Next(0, 6) };

                // Что надо найти: точку минимума или максимума?
                // 0 - минимума, 1 - максимума.
                int taskID = random.Next(possibleTasks.Length);

                // Нахождение ответа и определение условия задачи.
                int ans;
                string task = possibleTasks[taskID];

                if ((tempA > b && Math.Sign(tempA + b) == 1) || (b > tempA && Math.Sign(tempA + b) == 1))
                {
                    // Значение производной всегда положительно, поэтому заданная функция возрастающая.
                    // Точка минимума - левая граница отрезка, точка максимума - правая граница отрезка.
                    ans = taskID == 0 ? segment[0] : segment[1];
                }
                else
                {
                    // Значение производной всегда отрицательно, поэтому заданная функция убывающая.
                    // Точка минимума - правая граница отрезка, точка максимума - левая граница отрезка.
                    ans = taskID == 0 ? segment[1] : segment[0];
                }

                // Формирование коэфициентов в виде строк.
                string aToShow = $"{(a == 1 ? "" : (a == -1 ? "-" : a.ToString()))}";
                string bToShow = $"{(Math.Sign(b) == -1 ? $"- {(Math.Abs(b) == 1 ? "" : Math.Abs(b).ToString())}" : $"+ {(Math.Abs(b) == 1 ? "" : Math.Abs(b).ToString())}")}x";
                string cToShow = $"{(c == 0 ? "" : (Math.Sign(c) == -1 ? $"- {Math.Abs(c)}" : $"+ {c}"))}";

                // Вывод сгенерированного выражения в виде LaTeX и ответа.
                string taskCondition = $"{task}";
                string taskExpression = $"$$ {aToShow}\\{trigFuncs[trigFuncID]}{{x}} {bToShow} {cToShow} $$ " +
                $"на отрезке [{segment[0]}, {segment[1]}]";
                string taskAnswer = ($"Ответ: {ans}");

                return new string[] { taskCondition, taskExpression, taskAnswer };
            }
            else
            {
                // У функции есть экстремума (она всегда будет ответом на задачу).
                // Условие: |a| > |b|.

                // Возможные ответы на задачу.
                string[] answersSinString = { "\\(\\frac{\\pi}{4}\\)", "\\(\\frac{\\pi}{4}\\)", "\\(\\frac{\\pi}{3}\\)", "\\(\\frac{\\pi}{6}\\)" };
                string[] answersCosString = { "\\(\\frac{\\pi}{4}\\)", "\\(\\frac{\\pi}{4}\\)", "\\(\\frac{\\pi}{6}\\)", "\\(\\frac{\\pi}{3}\\)" };

                // Вспомогательные дроби для генерации отрезков.
                Fraction[] answersAuxiliaryFractionsSin = { new Fraction(1, 4), new Fraction(1, 4), new Fraction(1, 6), new Fraction(1, 3) };
                Fraction[] answersAuxiliaryFractionsCos = { new Fraction(1, 4), new Fraction(1, 4), new Fraction(1, 3), new Fraction(1, 6) };

                // Возможные коэффициенты k для генерации a или b.
                Fraction[] coefs = { new Fraction(Math.Sqrt(2), 2), new Fraction(1, Math.Sqrt(2)), new Fraction(1, 2), new Fraction(Math.Sqrt(3), 2) };
                var coefsString = new[]
                {
                    new { Numerator = "\\sqrt{2}", Denominator = "2" },
                    new { Numerator = "1", Denominator = "\\sqrt{2}" },
                    new { Numerator = "1", Denominator = "2" },
                    new { Numerator = "\\sqrt{3}", Denominator = "2" }
                };

                // Выбор коэффициента, который умножается на k.
                // 0 - a, 1 - b.
                int aOrB = random.Next(2);

                // Выбор коэфициента k для генерации a или b.
                int coefID = random.Next(coefs.Length);
                Fraction kToCalculate = coefs[coefID];

                // Инициализация переменной, в которой будет храниться точка экстремума.
                Fraction extr;

                // Генерация коэффициента b.
                int b;
                int[] possibleB = { random.Next(-10, 0), random.Next(1, 11) };
                b = possibleB[random.Next(possibleB.Length)];
                string bStringFraction = aOrB == 1 ? Utils.MergeCoefWithStringCoef(b, coefsString[coefID].Numerator, coefsString[coefID].Denominator)
                                                   : b.ToString();

                Fraction bToCalculate = aOrB == 1 ? b * kToCalculate : b;

                // Генерация коэффициента a.
                int a = b;
                a = random.Next(2) == 0 ? -a : a;

                string aStringFraction = aOrB == 0 ? Utils.MergeCoefWithStringCoef(a, coefsString[coefID].Denominator, coefsString[coefID].Numerator)
                                                   : a.ToString();
                Fraction aToCalculate = aOrB == 0 ? a / kToCalculate : a;

                // Коэффициент c может быть любым, он не влияет на решение задачи.
                int c = Generators.random.Next(-100, 101);

                // Нахождение точки экстремума.
                // Так как производная (cos)' = -sin, то если в задаче используется cos, необходимо домножить точку экстремума на -1.
                extr = -bToCalculate / aToCalculate;
                extr = trigFuncID == 1 ? -extr : extr;
                string extrString = trigFuncID == 0
                    ? (extr.Sign() == -1 ? "-" + answersSinString[coefID] : answersSinString[coefID])
                    : (extr.Sign() == -1 ? "-" + answersCosString[coefID] : answersCosString[coefID]);
                // Вспомогательная дробь для генерации отрезка.
                Fraction extrAuxiliaryFraction = trigFuncID == 0
                    ? (extr.Sign() == -1 ? -answersAuxiliaryFractionsSin[coefID] : answersAuxiliaryFractionsSin[coefID])
                    : (extr.Sign() == -1 ? -answersAuxiliaryFractionsCos[coefID] : answersAuxiliaryFractionsCos[coefID]);

                // Отрезок, на котором надо найти точку минимума или максимума.
                // Так как sinx и cosx - периодические функции, то берется отрезок длиной pi, причем ни одна
                // из границ отрезка не совпадает с точкой экстремума (иначе на отрезке будет две точки экстремумы).
                int translation = random.Next(1, (int)extrAuxiliaryFraction.Denominator);
                Fraction[] segment = { (extrAuxiliaryFraction - new Fraction(translation, extrAuxiliaryFraction.Denominator)).Reduce(),
                    (extrAuxiliaryFraction + new Fraction(extrAuxiliaryFraction.Denominator - translation, extrAuxiliaryFraction.Denominator)).Reduce() };

                // Отрезок-строка, в котором в числителе добавляется pi.  
                string[] segmentString = { segment[0].Reduce().AddPiToNumeratorLaTeX(), segment[1].Reduce().AddPiToNumeratorLaTeX() };

                // Функция.
                Expression<double> expr = (x) => { return aToCalculate.ToDouble() * (trigFuncID == 0 ? Math.Sin(x) : Math.Cos(x)) + bToCalculate.ToDouble() * x + c; };

                // Что надо найти: точку минимума или максимума?
                // 0 - минимума, 1 - максимума.
                int taskID = expr(extr.ToDouble()) > expr(segment[0].ToDouble()) && expr(extr.ToDouble()) > expr(segment[1].ToDouble()) ? 1 : 0;
                string task = possibleTasks[taskID];

                // Формирование коэфициентов в виде строк.
                string aToShow = $"{(aStringFraction == "1" ? "" : (aStringFraction == "-1" ? "-" : aStringFraction))}";
                string bToShow = bStringFraction == "1" ? "" : bStringFraction;
                bToShow = $"{(bToShow.IndexOf("-") == -1 ? $"+ {bToShow}" : $"- {bToShow.Replace("-", "")}")}x";
                string cToShow = $"{(c == 0 ? "" : (Math.Sign(c) == -1 ? $"- {Math.Abs(c)}" : $"+ {c}"))}";

                // Вывод сгенерированного выражения в виде LaTeX и ответа.
                string taskCondition = $"{task}";
                string taskExpression = $"$$ {aToShow}\\{trigFuncs[trigFuncID]}{{x}} {bToShow} {cToShow} $$ " +
                    $"на отрезке [{segmentString[0]}, {segmentString[1]}]";
                string taskAnswer = ($"Ответ: {extrString}");

                return new string[] { taskCondition, taskExpression, taskAnswer };
            }
        }

        /// <summary>
        /// Генерирует выражение, исследование которой не требует использования производной, вида
        /// \\sqrt{a * x^2 + b * x + c}, \\log_{n}{a * x^2 + b * x + c} или n^{a * x^2 + b * x + c}.
        /// </summary>
        /// <returns></returns>
        public static string[] GenerateExpressionNotRequiringDerivative()
        {
            // Равенство: extr = -b / (2 * a). Это точка минимума, если a > 0, минимума - a < 0.

            // Так как выбор \\sqrt{}, \\log{} и n^{} не влияет на ответ задачи, выбор производится случайным образом. 
            string[] possibleFuncs = { $"\\sqrt", $"\\log_{{{random.Next(2, 11)}}}", $"{random.Next(2, 11)}^" };

            // Выбор функции.
            // 0 - sqrt, 1 - log, 2 - n^.
            int funcID = random.Next(possibleFuncs.Length);

            // Инициализация переменной, в которой будет храниться точка экстремума.
            int extr;

            // Генерация коэффициента a, не равного нулю.
            int a;
            int[] possibleA = { Generators.random.Next(-10, 0), Generators.random.Next(1, 11) };
            a = possibleA[Generators.random.Next(possibleA.Length)];

            // Генерация коэффициента b, не равного нулю.
            int b;
            int[] possibleB = { Generators.random.Next(-10, 0), Generators.random.Next(1, 11) };
            b = 2 * possibleB[Generators.random.Next(possibleB.Length)] * a;

            // Нахождение точки экстремума.
            extr = -b / (2 * a);

            // Коэффициент c может быть любым, он не влияет на решение задачи.
            int c = Generators.random.Next(-100, 101);

            // Генерация отрезка в этой задаче не требуется.

            // Что надо найти: точку минимума или максимума?
            // 0 - минимума, 1 - максимума.
            int taskID = a > 0 ? 0 : 1;

            // Определение условия задачи.
            string task = possibleTasks[taskID];

            // Формирование коэфициентов в виде строк.
            string aToShow = $"{(a == 1 ? "" : (a == -1 ? "-" : a.ToString()))}x^2";
            string bToShow = $"{(Math.Sign(b) == -1 ? $"- {(Math.Abs(b) == 1 ? "" : Math.Abs(b).ToString())}" : $"+ {(Math.Abs(b) == 1 ? "" : Math.Abs(b).ToString())}")}x";
            string cToShow = $"{(c == 0 ? "" : (Math.Sign(c) == -1 ? $"- {Math.Abs(c)}" : $"+ {c}"))}";

            // Вывод сгенерированного выражения в виде LaTeX и ответа.
            string taskCondition = $"{task}";
            string taskExpression = funcID == 0 ? $"$$ {possibleFuncs[funcID]}{{{aToShow} {bToShow} {cToShow}}} $$"
                                                : $"$$ {possibleFuncs[funcID]}{{({aToShow} {bToShow} {cToShow})}} $$";
            string taskAnswer = ($"Ответ: {extr}");

            return new string[] { taskCondition, taskExpression, taskAnswer };
        }

        /// <summary>
        /// Возвращает ответ на задачу.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr">Выражение задачи</param>
        /// <param name="possibleAnswers">Возможные ответы на задачу</param>
        /// <param name="taskID">Идентификатор задания</param>
        /// <returns></returns>
        private static T GetTaskAnswer<T>(Expression<T> expr, List<T> possibleAnswers, int taskID)
        {
            // Инициализация списка со всеми возможными значениями функции expr.
            List<double> values = new List<double>();

            // Заполнение списка всеми возможными значениями функции expr.
            for (int i = 0; i < possibleAnswers.Count; i++)
            {
                values.Add(expr(possibleAnswers[i]));
            }

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
        /// <param name="HtmlDoc">Документ, куда добавляются новые задания</param>
        /// <param name="numOfTasks">Количество вариантов</param>
        /// <param name="numOfExpressions">Количество задач</param>
        /// <param name="typeOfExpression">Тип запрашиваемых выражений</param>
        public static void GenerateHTMLDoc(DummyHTML HtmlDoc, int numOfTasks, int numOfExpressions, int seed, string stringSeed, string typeOfExpression = null)
        {
            // Создание нового random по ключу генерации seed.
            random = new Random(seed);

            // Обнуление делегата.
            GeneratorDelegate generatorFunc = null;

            // Если тип выражений указан явно, то определяется тип выражения.
            if (typeOfExpression != null)
            {
                // Выбор задачи.
                if (typeOfExpression == possibleNamesOfExpression[0])
                {
                    generatorFunc = GenerateExpExpression;
                }
                else if (typeOfExpression == possibleNamesOfExpression[1])
                {
                    generatorFunc = GenerateQuotientExpression;
                }
                else if (typeOfExpression == possibleNamesOfExpression[2])
                {
                    generatorFunc = GeneratePowerExpression;
                }
                else if (typeOfExpression == possibleNamesOfExpression[3])
                {
                    generatorFunc = GenerateLogExpression;
                }
                else if (typeOfExpression == possibleNamesOfExpression[4])
                {
                    generatorFunc = GenerateTrigonometricExpression;
                }
                else if (typeOfExpression == possibleNamesOfExpression[5])
                {
                    generatorFunc = GenerateExpressionNotRequiringDerivative;
                }
            }

            // Добавление в документ numOfTasks вариантов по numOfExpressions задач в каждом.
            AddTasksToHtml(generatorFunc, HtmlDoc, numOfTasks, numOfExpressions, typeOfExpression == null, stringSeed);
        }

        /// <summary>
        /// Генерирует HTML документ с заданиями.
        /// </summary>
        /// <param name="HtmlDoc">Документ, куда добавляются новые задания</param>
        /// <param name="numOfTasks">Количество вариантов</param>
        /// <param name="generatorsList">Список генераторов</param>
        public static void GenerateHTMLDoc(DummyHTML HtmlDoc, int numOfTasks, List<GeneratorDelegate> generatorsList, int seed, string stringSeed)
        {
            // Создание нового random по ключу генерации seed.
            random = new Random(seed);

            AddTasksToHtml(HtmlDoc, numOfTasks, generatorsList, stringSeed);
        }

        /// <summary>
        /// Добавляет в Html документ новые задания.
        /// </summary>
        /// <param name="generatorFunc">Генератор новых заданий</param>
        /// <param name="HtmlDoc">Документ, куда добавляются новые задания</param>
        /// <param name="numOfTasks">Количество вариантов</param>
        /// <param name="numOfExpressions">Количество задач</param>
        /// <param name="randomFlag">Флаг, отвечающий за то, использовать ли случайные генераторы</param>
        private static void AddTasksToHtml(GeneratorDelegate generatorFunc, DummyHTML HtmlDoc, int numOfTasks, int numOfExpressions, bool randomFlag, string stringSeed)
        {
            // Добавление ключа генерации.
            HtmlDoc.ChangeSeed(stringSeed);

            if (numOfExpressions == 1)
            {
                for (int i = 0; i < numOfTasks; i++)
                {
                    // Если генератор не указан (randomFlag == true), то он выбирается случайным образом. 
                    if (randomFlag) generatorFunc = possibleGeneratorsOfExpression[Generators.random.Next(possibleGeneratorsOfExpression.Length)];

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
                        // Если генератор не указан (randomFlag == true), то он выбирается случайным образом. 
                        if (randomFlag) generatorFunc = possibleGeneratorsOfExpression[Generators.random.Next(possibleGeneratorsOfExpression.Length)];

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

        /// <summary>
        /// Добавляет в Html документ новые задания.
        /// </summary>
        /// <param name="generatorFunc">Генератор новых заданий</param>
        /// <param name="HtmlDoc">Документ, куда добавляются новые задания</param>
        /// <param name="numOfTasks">Количество вариантов</param>
        /// <param name="generatorsList">Список генераторов</param>
        private static void AddTasksToHtml(DummyHTML HtmlDoc, int numOfTasks, List<GeneratorDelegate> generatorsList, string stringSeed)
        {
            // Добавление ключа генерации.
            HtmlDoc.ChangeSeed(stringSeed);

            GeneratorDelegate generatorFunc;

            if (generatorsList.Count == 1)
            {
                for (int i = 0; i < numOfTasks; i++)
                {
                    generatorFunc = generatorsList[0];

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

                    // Изменяется порядок элементов в списке генераторов.
                    Utils.ChangeListOrder(generatorsList);

                    for (int j = 0; j < generatorsList.Count; j++)
                    {
                        generatorFunc = generatorsList[j];

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
