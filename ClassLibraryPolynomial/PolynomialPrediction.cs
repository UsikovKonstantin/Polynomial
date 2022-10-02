namespace ClassLibraryPolynomial
{
    public class PolynomialPrediction : PolynomialWithRoots
    {


        /// <summary>
        /// Конструктор по умолчанию.
        /// Создает полином второй степени и задаёт корни.
        /// </summary>
        public PolynomialPrediction() : base()
        {
        }

        /// <summary>
        /// Конструктор.
        /// Создает полином n-й степени с нулевыми коэффициентами.
        /// Список корней пока пуст.
        /// </summary>
        /// <param name="n"> степень полинома </param>
        public PolynomialPrediction(int n) : base(n)
        { }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином n-й степени со случайными коэффициентами
        /// целого типа из диапазона [min, max). 
        /// </summary>
        /// <param name="n"> степень полинома </param>
        /// <param name="min"> нижняя граница </param>
        /// <param name="max"> верхняя граница </param>
        public PolynomialPrediction(int n, long min, long max) : base(n, min, max)
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
        public PolynomialPrediction(int n, double min, double max, int round) : base(n, min, max, round)
        { }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином, копируя переданные коэффициенты.
        /// </summary>
        /// <param name="coefs"> набор коэффициентов </param>
        public PolynomialPrediction(double[] coefs) : base(coefs)
        { }

        /// <summary>
        /// Конструктор.
        /// Создает полином, используя переданные корни.
        /// </summary>
        /// <param name="roots"> корни полинома </param>
        public PolynomialPrediction(List<double> roots)
        {
            n = roots.Count;
            this.roots = roots;
            //coefs = RootsToCoefficients();
        }


        /// <summary>
        /// Умножение полинома на число.
        /// </summary>
        /// <param name="p"> полином для умножения </param>
        /// <param name="n"> число, на которое умножается полином </param>
        /// <returns> полином - результат умножения </returns>
        public static PolynomialPrediction operator *(PolynomialPrediction p, double n)
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
            return new PolynomialPrediction(resCoefs);
        }



        /// <summary>
        /// Умножение полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> произведение полиномов </returns>
        public static PolynomialPrediction operator *(PolynomialPrediction p1, PolynomialPrediction p2)
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
            PolynomialPrediction res = new PolynomialPrediction(resCoef);

            // Получение корней произведения полиномов
            foreach (double root in p1.Roots)
            {
                res.roots.Add(root);
            }
            foreach (double root in p2.Roots)
            {
                res.roots.Add(root);
            }
            return res;
        }


        /// <summary>
        /// Сложение полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> сумма полиномов </returns>
        public static PolynomialPrediction operator +(PolynomialPrediction p1, PolynomialPrediction p2)
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
            return new PolynomialPrediction(resCoef);
        }



        private PolynomialPrediction L(int index, double[] X)
        {
            PolynomialPrediction L = new PolynomialPrediction(new double[] { 1 });
            for (int i = 0; i < X.Length; i++)
            {
                if (i != index)
                {
                    var r = new PolynomialPrediction(new double[] { -X[i], 1 });
                    L *= r * (1 / (X[index] - X[i]));
                }
            }
            return L;
        }

        public PolynomialPrediction GetPredictionPol(double[] X, double[] Y)
        {
            //double y = 0;
            PolynomialPrediction p = new PolynomialPrediction(new double[] {0});
            for (int i = 0; i < X.Length; i++)
            {
                //y += Y[i] * L(i, X, x);
                p += L(i, X) * Y[i];
            }
            return p;
        }
    }
}
