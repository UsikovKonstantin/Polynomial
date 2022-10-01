namespace ClassLibraryPolynomial
{
    /// <summary>
    /// Класс полином с возможностью вычисления корней и точек экстремума.
    /// </summary>
    public class PolynomialWithRoots : Polynomial
    {
        private List<double> roots = new List<double>();  // корни полинома

        // Свойство для доступа к корням.
        public List<double> Roots
        {
            get 
            {
                List<double> res = new List<double>();
                foreach (double item in roots)
                {
                    res.Add(item);
                }
                return res;
            }
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// Создает полином второй степени и задаёт корни.
        /// </summary>
        public PolynomialWithRoots() : base()
        {
            roots.Add(1);
            roots.Add(1);
        }

        /// <summary>
        /// Конструктор.
        /// Создает полином n-й степени с нулевыми коэффициентами.
        /// Список корней пока пуст.
        /// </summary>
        /// <param name="n"> степень полинома </param>
        public PolynomialWithRoots(int n) : base(n)
        { }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином n-й степени со случайными коэффициентами
        /// целого типа из диапазона [min, max). 
        /// </summary>
        /// <param name="n"> степень полинома </param>
        /// <param name="min"> нижняя граница </param>
        /// <param name="max"> верхняя граница </param>
        public PolynomialWithRoots(int n, long min, long max) : base(n, min, max)
        { }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином n-й степени со случайными коэффициентами
        /// дробного типа из диапазона [min, max). 
        /// </summary>
        /// <param name="n"> степень полинома </param>
        /// <param name="min"> нижняя граница </param>
        /// <param name="max"> верхняя граница </param>
        /// <param name="round"> количество знаков после запятой </param>
        public PolynomialWithRoots(int n, double min, double max, int round) : base(n, min, max, round)
        { }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином, копируя переданные коэффициенты.
        /// </summary>
        /// <param name="coefs"> набор коэффициентов </param>
        public PolynomialWithRoots(double[] coefs) : base(coefs)
        { }

        /// <summary>
        /// Конструктор.
        /// Создает полином, используя переданные корни.
        /// </summary>
        /// <param name="roots"> корни полинома </param>
        public PolynomialWithRoots(List<double> roots)
        {
            n = roots.Count;
            this.roots = roots;
            coefs = RootsToCoefficients();
        }

        /// <summary>
        /// Переход от корней к коэффициентам.
        /// </summary>
        /// <returns> коэффициенты полинома </returns>
        private double[] RootsToCoefficients()
        {
            int m = roots.Count;
            double[] coefs = new double[m + 1];
            coefs[0] = -roots[0];
            coefs[1] = 1;
            for (int k = 1; k < m; k++)
            {
                coefs[k + 1] = 1;
                for (int i = k; i > 0; i--)
                {
                    coefs[i] = -coefs[i] * roots[k] + coefs[i - 1];
                }
                coefs[0] = -coefs[0] * roots[k];
            }
            return coefs;
        }

        /// <summary>
        /// Переопределение метода ToString().
        /// </summary>
        /// <returns> описание полинома с указанием его корней </returns>
        public override string ToString()
        {
            string s = "\nКорни полинома:";
            int m = roots.Count;
            for (int i = 0; i < m; i++)
            {
                s += " " + roots[i];
            }
            return base.ToString() + s;
        }

        /// <summary>
        /// Приведение объекта типа Polynomial к типу PolynomialWithRoots.
        /// </summary>
        /// <param name="p"> объект типа Polynomial </param>
        /// <returns> объект типа PolynomialWithRoots </returns>
        public static PolynomialWithRoots Parse(Polynomial p)
        {
            return new PolynomialWithRoots(p.Coefs);
        }

        /// <summary>
        /// Сложение полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> сумма полиномов </returns>
        public static PolynomialWithRoots operator +(PolynomialWithRoots p1, PolynomialWithRoots p2)
        {
            return Parse(p1 + p2);
        }

        /// <summary>
        /// Вычитание полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> разность полиномов </returns>
        public static PolynomialWithRoots operator -(PolynomialWithRoots p1, PolynomialWithRoots p2)
        {
            return Parse(p1 - p2);
        }

        /// <summary>
        /// Умножение полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> произведение полиномов </returns>
        public static PolynomialWithRoots operator *(PolynomialWithRoots p1, PolynomialWithRoots p2)
        {
            PolynomialWithRoots p = Parse(p1 * p2);
            // Получение корней произведения полиномов
            foreach (double root in p1.Roots)
            {
                p.roots.Add(root);
            }
            foreach (double root in p2.Roots)
            {
                p.roots.Add(root);
            }
            return p;
        }

        /// <summary>
        /// Деление полиномов нацело.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> полином - результат деления нацело </returns>
        public static PolynomialWithRoots operator /(PolynomialWithRoots p1, PolynomialWithRoots p2)
        {
            return Parse(p1 / p2);
        }

        /// <summary>
        /// Остаток от деления нацело полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> полином - остаток от деления нацело </returns>
        public static PolynomialWithRoots operator %(PolynomialWithRoots p1, PolynomialWithRoots p2)
        {
            return Parse(p1 % p2);
        }

        /// <summary>
        /// Умножение полинома на число.
        /// </summary>
        /// <param name="n"> число, на которое умножается полином </param>
        /// <param name="p"> полином для умножения </param>
        /// <returns> полином - результат умножения </returns>
        public static PolynomialWithRoots operator *(double n, PolynomialWithRoots p)
        {
            return Parse(n * p);
        }

        /// <summary>
        /// Умножение полинома на число.
        /// </summary>
        /// <param name="p"> полином для умножения </param>
        /// <param name="n"> число, на которое умножается полином </param>
        /// <returns> полином - результат умножения </returns>
        public static PolynomialWithRoots operator *(PolynomialWithRoots p, double n)
        {
            return Parse(p * n);
        }
    }
}
