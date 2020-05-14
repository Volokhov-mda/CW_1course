using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Fraction
    {
        private double numerator, denominator;

        public double Numerator
        {
            get => numerator;
            set => numerator = value;
        }
        public double Denominator
        {
            get => denominator;
            set => denominator = value != 0 ? value : throw new DivideByZeroException("Fractional denominator can't be equal to 0");
        }

        // Методы.
        /// <summary>
        /// Увеличивает числитель и знаменатель дроби в заданное количество раз.
        /// </summary>
        /// <param name="increaseValue">Значение увеличения дроби</param>
        /// <returns></returns>
        public Fraction IncreaseNumAndDenumBy(int increaseValue)
        {
            return new Fraction(Numerator * increaseValue, Denominator * increaseValue);
        }

        /// <summary>
        /// Неявное преобразование типа int в Fraction.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Fraction(int value)
        {
            return new Fraction(value);
        }

        /// <summary>
        /// Сокращает дробь.
        /// </summary>
        /// <returns></returns>
        public Fraction Reduce()
        {
            double num = this.Numerator;
            double denum = this.Denominator;

            // Нахождение НОД по алгоритму Евклида. НОД запишется в переменную gcd.
            double gcd = 1;
            while (denum != 0)
            {
                gcd = denum;
                denum = num % denum;
                num = gcd;
            }

            // Дробь, числитель и знаменатель которой поделены на НОД.
            return new Fraction(this.Numerator / gcd, this.Denominator / gcd);
        }

        /// <summary>
        /// Возвращает знак дроби.
        /// </summary>
        /// <returns></returns>
        public int Sign()
        {
            return Math.Sign(Numerator);
        }

        /// <summary>
        /// Добавляет \\pi в числитель дроби и возвращает выражение LaTeX.
        /// </summary>
        /// <returns></returns>
        public string AddPiToNumeratorLaTeX()
        {
            if (this.Numerator == 0) return "0";

            string numerator = $"{(this.Numerator == 1 ? "\\pi" : (this.Numerator == -1 ? "-\\pi" : this.Numerator + "\\pi"))}";
            return this.Denominator == 1 ? $"\\({numerator}\\)" : $"\\(\\frac{{{numerator}}}{{{this.Denominator}}}\\)";
        }

        // Операторы.
        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.Numerator, a.Denominator);
        }

        public static Fraction operator +(Fraction a)
        {
            return a;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a + (-b);
        }

        public static Fraction operator +(Fraction a, int b)
        {
            return new Fraction(a.Numerator + b * a.Denominator, a.Denominator);
        }

        public static Fraction operator +(int a, Fraction b)
        {
            return b + a;
        }

        public static Fraction operator -(Fraction a, int b)
        {
            return a + (-b);
        }

        public static Fraction operator -(int a, Fraction b)
        {
            return a + (-b);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator *(Fraction a, int b)
        {
            return new Fraction(a.Numerator * b, a.Denominator);
        }

        public static Fraction operator *(int a, Fraction b)
        {
            return b * a;
        }

        public static Fraction operator *(Fraction a, double b)
        {
            return new Fraction(a.Numerator * b, a.Denominator);
        }

        public static Fraction operator *(double a, Fraction b)
        {
            return b * a;
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static Fraction operator /(int a, Fraction b)
        {
            return new Fraction(b.Denominator * a, b.numerator);
        }

        public static Fraction operator /(Fraction a, int b)
        {
            return new Fraction(a.Numerator, a.Denominator * b);
        }

        // Конструкторы.
        public Fraction(double numerator)
        {
            this.numerator = numerator;
            this.denominator = 1;
        }

        public Fraction(double numerator, double denominator)
        {
            if (denominator < 0 && numerator > 0)
            {
                this.numerator = -numerator;
                this.denominator = -denominator;
            }
            else if (denominator < 0 && denominator < 0)
            {
                this.numerator = -numerator;
                this.denominator = -denominator;
            }
            else
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }
        }

        /// <summary>
        /// Представление дроби в записи LaTeX со скобками.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Fraction frac = this.Reduce();
            return frac.Denominator == 1 ? $"{frac.Numerator}" 
                                         : $"\\frac{{{frac.Numerator.ToString()}}}{{{frac.Denominator}}}";
        }

        /// <summary>
        /// Представление дроби в записи LaTeX.
        /// </summary>
        /// <returns></returns>
        public string ToStringLaTeX()
        {
            Fraction frac = this.Reduce();
            return frac.Denominator == 1 ? $"\\({frac.Numerator}\\)"
                                         : $"\\(\\frac{{{frac.Numerator}}}{{{frac.Denominator}}}\\)";
        }

        /// <summary>
        /// Представление дроби в десятичной записи.
        /// </summary>
        /// <returns></returns>
        public double ToDouble()
        {
            return numerator / denominator;
        }
    }
}
