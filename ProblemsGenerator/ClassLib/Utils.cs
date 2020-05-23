using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    class Utils
    {
        /// <summary>
        /// Склеивает вещественный коэфициент и дробь в виде строки.
        /// </summary>
        /// <param name="coef">Коэфициент</param>
        /// <param name="numerator">Числитель дроби</param>
        /// <param name="denominator">Знаменатель дроби</param>
        /// <returns></returns>
        public static string MergeCoefWithStringCoef(double coef, string numerator, string denominator)
        {
            string tempNumerator;
            string tempDenominator;

            double tryParseIndicator;

            if (Math.Abs(coef) == 1) return denominator != "1" ? $"\\frac{{{(Math.Sign(coef) == -1 ? "-" + numerator : numerator)}}}{{{denominator}}}"
                                                               : numerator == "-1" ? "-" : (numerator == "1" ? "" : numerator);

            if (double.TryParse(numerator, out tryParseIndicator) == true)
            {
                if (double.TryParse(denominator, out tryParseIndicator) == true)
                {
                    double gcd = FindGCD(coef, int.Parse(denominator));

                    tempNumerator = (coef * int.Parse(numerator) / gcd).ToString();
                    tempDenominator = (int.Parse(denominator) / gcd).ToString();
                }
                else
                {
                    tempNumerator = (coef * int.Parse(numerator)).ToString();
                    tempDenominator = denominator;
                }
            }
            else
            {
                if (double.TryParse(denominator, out tryParseIndicator) == true)
                {
                    double gcd = FindGCD(coef, int.Parse(denominator));

                    tempNumerator = ((coef / gcd == 1 ? "" : (coef / gcd).ToString()) + numerator).ToString();
                    tempDenominator = (int.Parse(denominator) / gcd).ToString();
                }
                else
                {
                    tempNumerator = coef + numerator;
                    tempDenominator = denominator;
                }
            }

            return tempDenominator != "1" ? $"\\frac{{{tempNumerator}}}{{{tempDenominator}}}"
                                            : tempNumerator;
        }

        /// <summary>
        /// Меняет порядок элементов списка.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Список</param>
        public static void ChangeListOrder<T>(List<T> list)
        {
            for (int k = 0; k < list.Count; k++)
            {
                T temp = list[k];
                list.RemoveAt(k);
                list.Insert(Generators.random.Next(list.Count), temp); ;
            }
        }

        /// <summary>
        /// Находит НОД двух чисел.
        /// </summary>
        /// <returns></returns>
        public static double FindGCD(double firstValue, double secondValue)
        {
            // Нахождение НОД по алгоритму Евклида. НОД запишется в переменную gcd.
            double gcd = 1;
            while (secondValue != 0)
            {
                gcd = secondValue;
                secondValue = firstValue % secondValue;
                firstValue = gcd;
            }

            return gcd;
        }
    }
}
