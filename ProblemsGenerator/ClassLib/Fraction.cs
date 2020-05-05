using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Fraction
    {
        private int numerator, denominator;

        public int Numerator
        {
            get => numerator;
            set => numerator = value;
        }
        public int Denominator
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
        /// Сокращает дробь.
        /// </summary>
        /// <returns></returns>
        public Fraction Reduce()
        {
            int num = this.Numerator;
            int denum = this.Denominator;

            // Нахождение НОД по алгоритму Евклида. НОД запишется в переменную gcd.
            int gcd = 1;
            while (denum != 0)
            {
                gcd = denum;
                denum = num % denum;
                num = gcd;
            }

            // Дробь, числитель и знаменатель которой поделены на НОД.
            return new Fraction(this.Numerator / gcd, this.Denominator / gcd);
        }

        // Операторы.
        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.Numerator, a.Denominator);
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

        // Конструкторы.
        public Fraction(int numerator)
        {
            this.numerator = numerator;
            this.denominator = 1;
        }

        public Fraction(int numerator, int denominator)
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
        /// Представление дроби в записи LaTeX.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
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
