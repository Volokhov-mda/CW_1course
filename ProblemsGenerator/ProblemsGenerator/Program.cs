using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLib;
using Utils;

namespace ProblemsGenerator
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            
            string[] GenerateExpExpression()
            {
                // Генерация происходит при помощи равенства ans = -b / a - 1 / c.
                // Возможные задачи.
                string[] possibleTasks = { "найти точку минимума функции", "найти точку максимума функции" };

                // Генерация нуля производной.
                int funcZero = Utils.Utils.random.Next(-10, 11);

                // Генерация коэффициента c, не равного нулю.
                int c;
                int[] possibleC = { Utils.Utils.random.Next(-10, 0), Utils.Utils.random.Next(1, 11) };
                c = possibleC[Utils.Utils.random.Next(possibleC.Length)];

                // Создание дроби 1 / c.
                Fraction divideC = new Fraction(1, c);

                // Создание дроби -b / a.
                Fraction minusBDivideA = (funcZero + divideC);

                // Коэффициенты b и a.
                int b = -minusBDivideA.Numerator;
                int a = minusBDivideA.Denominator;

                // Коэффициент d может быть любым, он не влияет на решение задачи.
                int d = Utils.Utils.random.Next(-100, 101);

                // Отрезок, на котором надо найти точку минимума или максимума.
                int[] segment = { funcZero - Utils.Utils.random.Next(1, 6), funcZero + Utils.Utils.random.Next(1, 6) };

                // Что надо найти: точку минимума или максимума?
                // 0 - минимума, 1 - максимума.
                int taskID = Utils.Utils.random.Next(possibleTasks.Length);

                // Значения функции при разных значениях переменной x из отрезка segment (начало отрезка, ноль функции, конец отрезка)
                double firstValue = (a * segment[0] + b) * Math.Exp(c * segment[0] + d);
                double secondValue = (a * funcZero + b) * Math.Exp(c * funcZero + d);
                double thirdValue = (a * segment[1] + b) * Math.Exp(c * segment[1] + d);

                // Нахождение ответа и определение условия задачи.
                int ans;
                string task = possibleTasks[taskID];

                if (taskID == 0)
                {
                    double minValue = Math.Min(Math.Min(firstValue, secondValue), Math.Min(secondValue, thirdValue));

                    if (minValue == firstValue)
                    {
                        ans = segment[0];
                    }
                    else if (minValue == secondValue)
                    {
                        ans = funcZero;
                    }
                    else
                    {
                        ans = segment[1];
                    }
                }
                else
                {
                    double maxValue = Math.Max(Math.Max(firstValue, secondValue), Math.Max(secondValue, thirdValue));

                    if (maxValue == firstValue)
                    {
                        ans = segment[0];
                    }
                    else if (maxValue == secondValue)
                    {
                        ans = funcZero;
                    }
                    else
                    {
                        ans = segment[1];
                    }
                }

                // Вывод сгенерированного выражения в виде LaTeX и ответа.
                string taskCondition = $"Задача: {task}" + Environment.NewLine +
                                       $"$$ ({a} * x + {b}) * \\exp^({c} * x + {d}) $$ на отрезке [{segment[0]}, {segment[1]}]";
                string taskAnswer = ($"Ответ: {ans}");

                return new string[] { taskCondition, taskAnswer };
            }

            Console.ReadKey();
        }
    }
}