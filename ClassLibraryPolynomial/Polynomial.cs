﻿namespace ClassLibraryPolynomial
{
    /// <summary>
    /// Класс Полином
    /// </summary>
    public class Polynomial
    {
        private static Random rnd = new Random();  // генератор случайных чисел
        private protected int n;  // степень полинома
        private protected double[] coefs;  // коэффициенты полинома

        // Свойство для доступа к степени полинома.
        public int N
        {
            get { return n; }
        }
        // Свойство для доступа к коэффициентам полинома.
        public double[] Coefs
        {
            get 
            {
                double[] res = new double[N + 1];
                for (int i = 0; i <= N; i++)
                {
                    res[i] = coefs[i];
                }
                return res;
            }
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// Создает полином x^2 - 3x + 2.
        /// </summary>
        public Polynomial()
        {
            n = 2;
            coefs = new double[] { 2, -3, 1 };
        }

        /// <summary>
        /// Коструктор.
        /// Создаёт полином n-й степени с нулевыми коэффициентами. 
        /// </summary>
        /// <param name="n"> степень полинома </param>
        public Polynomial(int n)
        {
            this.n = n;
            coefs = new double[N + 1];
        }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином n-й степени со случайными коэффициентами
        /// целого типа из диапазона [min, max). 
        /// </summary>
        /// <param name="n"> степень полинома </param>
        /// <param name="min"> нижняя граница </param>
        /// <param name="max"> верхняя граница </param>
        public Polynomial(int n, long min, long max)
        {
            this.n = n;
            coefs = new double[N + 1];
            for (int i = 0; i <= n; i++)
            {
                coefs[i] = rnd.NextInt64(min, max);
            }
        }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином n-й степени со случайными коэффициентами
        /// дробного типа из диапазона [min, max). 
        /// </summary>
        /// <param name="n"> степень полинома </param>
        /// <param name="min"> нижняя граница </param>
        /// <param name="max"> верхняя граница </param>
        /// <param name="round"> количество знаков после запятой </param>
        public Polynomial(int n, double min, double max, int round)
        {
            this.n = n;
            coefs = new double[N + 1];
            for (int i = 0; i <= n; i++)
            {
                coefs[i] = Math.Round(rnd.NextDouble() * (max - min) + min, round);
            }
        }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином, копируя переданные коэффициенты.
        /// </summary>
        /// <param name="coefs"> набор коэффициентов </param>
        public Polynomial(double[] coefs)
        {
            n = coefs.Count() - 1;
            this.coefs = coefs;
        }

        /// <summary>
        /// Переопределение метода ToString().
        /// </summary>
        /// <returns> строка, представляющая полином </returns>
        public override string ToString()
        {
            string res = GetFirstNotNullMember(out int position);
            for (int i = position - 1; i >= 0; i--)
            {
                if (coefs[i] == 0) continue;
                if (Math.Abs(coefs[i]) == 1)
                {
                    if (i == 0)
                        res += SetGign(coefs[i]) + Math.Abs(coefs[i]);
                    else if (i == 1)
                        res += SetGign(coefs[i]) + "x";
                    else
                        res += SetGign(coefs[i]) + "x^" + i;
                }
                else
                {
                    if (i == 0)
                        res += SetGign(coefs[i]) + Math.Abs(coefs[i]);
                    else if (i == 1)
                        res += SetGign(coefs[i]) + Math.Abs(coefs[i]) + "x";
                    else
                        res += SetGign(coefs[i]) + Math.Abs(coefs[i]) + "x^" + i;
                }
            }
            return res;
        }

        /// <summary>
        /// Возвращает строковое представление первого ненулевого элемента в полиноме.
        /// </summary>
        /// <param name="position"> позиция ненулевого элемента </param>
        /// <returns> первый ненулевой элемент в полиноме </returns>
        private string GetFirstNotNullMember(out int position)
        {
            string res = "";
            int i;
            for (i = n; i >= 0; i--)
            {
                if (coefs[i] == 0) continue;
                if (Math.Abs(coefs[i]) == 1)
                {
                    if (i == 0)
                        res += coefs[i];
                    else if (i == 1)
                        res += coefs[i] == 1 ? "x" : "-x";
                    else
                        res += (coefs[i] == 1 ? "x^" : "-x^") + i;
                }
                else
                {
                    if (i == 0)
                        res += coefs[i];
                    else if (i == 1)
                        res += coefs[i] + "x";
                    else
                        res += coefs[i] + "x^" + i;
                }
                break;
            }
            if (res == "")
                res = "0";
            position = i;
            return res;
        }

        /// <summary>
        /// Получает знак числа.
        /// </summary>
        /// <param name="n"> число, знак которого нужно получить </param>
        /// <returns> знак числа (+ или -) </returns>
        private string SetGign(double n)
        {
            if (n >= 0)
                return " + ";
            return " - ";
        }

        /// <summary>
        /// Вычисление значения полинома в точке x.
        /// Схема Горнера.
        /// </summary>
        /// <param name="x"> точка </param>
        /// <returns> значение полинома в точке </returns>
        public double P(double x)
        {
            double res = 0;
            for (int i = n; i >= 0; i--)
            {
                res = res * x + coefs[i];
            }
            return res;
        }

        /// <summary>
        /// Производная полинома.
        /// </summary>
        /// <returns> полином, представляющий производную </returns>
        public Polynomial GetDerivative()
        {
            double[] resCoefs = new double[n];
            for (int i = n; i > 0; i--)
            {
                resCoefs[i - 1] = i * coefs[i];
            }
            return new Polynomial(resCoefs);
        }

        /// <summary>
        /// Сложение полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> сумма полиномов </returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            int m = Math.Min(p1.n, p2.n);
            int n = Math.Max(p1.n, p2.n);
            double[] resCoef = new double[n + 1];
            for (int i = 0; i <= m; i++)
            {
                resCoef[i] = p1.coefs[i] + p2.coefs[i];
            }
            for (int i = m + 1; i <= n; i++)
            {
                resCoef[i] = (p1.n >= p2.n) ? p1.coefs[i] : p2.coefs[i];
            }
            return new Polynomial(resCoef);
        }

        /// <summary>
        /// Вычитание полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> разность полиномов </returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            int m = Math.Min(p1.n, p2.n);
            int n = Math.Max(p1.n, p2.n);
            double[] resCoef = new double[n + 1];
            for (int i = 0; i <= m; i++)
            {
                resCoef[i] = p1.coefs[i] - p2.coefs[i];
            }
            for (int i = m + 1; i <= n; i++)
            {
                resCoef[i] = (p1.n >= p2.n) ? p1.coefs[i] : -p2.coefs[i];
            }
            return new Polynomial(resCoef);
        }

        /// <summary>
        /// Умножение полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> произведение полиномов </returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            int n = p1.n;
            int m = p2.n;
            double[] resCoef = new double[n + m + 1];
            for (int i = 0; i <= n + m; i++)
            {
                for (int k = 0; k <= Math.Min(i, n); k++)
                {
                    int j = i - k;
                    if (j <= m)
                    {
                        resCoef[i] += p1.coefs[k] * p2.coefs[j];
                    }
                }
            }
            return new Polynomial(resCoef);
        }

        /// <summary>
        /// Деление полиномов нацело.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> полином - результат деления нацело </returns>
        public static Polynomial operator /(Polynomial p1, Polynomial p2)
        {
            int n = p1.n;
            int m = p2.n;
            if (n < m)
            {
                return new Polynomial(0);
            }
            double d;
            double[] pCoef = new double[n - m + 1];
            double[] tCoef = new double[n + 1];
            for (int i = 0; i <= n; i++)
            {
                tCoef[i] = p1.coefs[i];
            }
            for (int i = 0; i <= n - m; i++)
            {
                d = tCoef[n - i] / p2.coefs[m];
                pCoef[n - m - i] = d;
                tCoef[n - i] = 0;
                for (int k = 1; k <= m; k++)
                {
                    tCoef[n - i - k] -= d * p2.coefs[m - k];
                }
            }
            return new Polynomial(pCoef);
        }

        /// <summary>
        /// Остаток от деления нацело полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> полином - остаток от деления нацело </returns>
        public static Polynomial operator %(Polynomial p1, Polynomial p2)
        {
            int n = p1.n;
            int m = p2.n;
            if (n < m)
            {
                return new Polynomial(p1.coefs);
            }
            double d;
            double[] pCoef = new double[n - m + 1];
            double[] tCoef = new double[n + 1];
            for (int i = 0; i <= n; i++)
            {
                tCoef[i] = p1.coefs[i];
            }
            for (int i = 0; i <= n - m; i++)
            {
                d = tCoef[n - i] / p2.coefs[m];
                pCoef[n - m - i] = d;
                tCoef[n - i] = 0;
                for (int k = 1; k <= m; k++)
                {
                    tCoef[n - i - k] -= d * p2.coefs[m - k];
                }
            }
            int j = 0;
            while (j <= n && tCoef[n - j] == 0)
            {
                j++;
            }
            double[] resCoef = new double[1];
            if (j <= n)
            {
                resCoef = new double[n - j + 1];
                for (int i = 0; i <= n - j; i++)
                {
                    resCoef[i] = tCoef[i];
                }
            }
            return new Polynomial(resCoef);
        }

        /// <summary>
        /// Умножение полинома на число.
        /// </summary>
        /// <param name="n"> число, на которое умножается полином </param>
        /// <param name="p"> полином для умножения </param>
        /// <returns> полином - результат умножения </returns>
        public static Polynomial operator *(double n, Polynomial p)
        {
            int k = p.n;
            double[] resCoefs = new double[k + 1];
            for (int i = 0; i <= k; i++)
            {
                resCoefs[i] = p.coefs[i];
            }
            for (int i = 0; i <= k; i++)
            {
                resCoefs[i] *= n;
            }
            return new Polynomial(resCoefs);
        }

        /// <summary>
        /// Умножение полинома на число.
        /// </summary>
        /// <param name="p"> полином для умножения </param>
        /// <param name="n"> число, на которое умножается полином </param>
        /// <returns> полином - результат умножения </returns>
        public static Polynomial operator *(Polynomial p, double n)
        {
            int k = p.n;
            double[] resCoefs = new double[k + 1];
            for (int i = 0; i <= k; i++)
            {
                resCoefs[i] = p.coefs[i];
            }
            for (int i = 0; i <= k; i++)
            {
                resCoefs[i] *= n;
            }
            return new Polynomial(resCoefs);
        } 
    }
}