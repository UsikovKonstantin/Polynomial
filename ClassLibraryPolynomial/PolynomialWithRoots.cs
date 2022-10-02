namespace ClassLibraryPolynomial
{
    /// <summary>
    /// Класс полином с возможностью вычисления корней и точек экстремума.
    /// </summary>
    public class PolynomialWithRoots : Polynomial
    {
        private protected List<double> roots = new List<double>();  // корни полинома
        private protected List<(double, int)> stationaryPoints;  // точки экстремума

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

        // Свойство для доступа к точкам экстремума
        public List<(double, int)> StationaryPoints
        {
            get 
            {
                List<(double, int)> res = new List<(double, int)>();
                foreach ((double, int) item in stationaryPoints)
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
            return new PolynomialWithRoots(resCoef);
        }

        /// <summary>
        /// Вычитание полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> разность полиномов </returns>
        public static PolynomialWithRoots operator -(PolynomialWithRoots p1, PolynomialWithRoots p2)
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
            return new PolynomialWithRoots(resCoef);
        }

        /// <summary>
        /// Умножение полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> произведение полиномов </returns>
        public static PolynomialWithRoots operator *(PolynomialWithRoots p1, PolynomialWithRoots p2)
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
            PolynomialWithRoots res = new PolynomialWithRoots(resCoef);

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
        /// Деление полиномов нацело.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> полином - результат деления нацело </returns>
        public static PolynomialWithRoots operator /(PolynomialWithRoots p1, PolynomialWithRoots p2)
        {
            int n = p1.n;
            int m = p2.n;
            if (n < m)
            {
                return new PolynomialWithRoots(0);
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
            return new PolynomialWithRoots(pCoef);
        }

        /// <summary>
        /// Остаток от деления нацело полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> полином - остаток от деления нацело </returns>
        public static PolynomialWithRoots operator %(PolynomialWithRoots p1, PolynomialWithRoots p2)
        {
            int n = p1.n;
            int m = p2.n;
            if (n < m)
            {
                return new PolynomialWithRoots(p1.coefs);
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
            return new PolynomialWithRoots(resCoef);
        }

        /// <summary>
        /// Умножение полинома на число.
        /// </summary>
        /// <param name="n"> число, на которое умножается полином </param>
        /// <param name="p"> полином для умножения </param>
        /// <returns> полином - результат умножения </returns>
        public static PolynomialWithRoots operator *(double n, PolynomialWithRoots p)
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
            return new PolynomialWithRoots(resCoefs);
        }

        /// <summary>
        /// Умножение полинома на число.
        /// </summary>
        /// <param name="p"> полином для умножения </param>
        /// <param name="n"> число, на которое умножается полином </param>
        /// <returns> полином - результат умножения </returns>
        public static PolynomialWithRoots operator *(PolynomialWithRoots p, double n)
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
            return new PolynomialWithRoots(resCoefs);
        }

        /// <summary>
        /// Существует ли корень полинома на заданном интервале.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <returns> true - если существует, иначе - false </returns>
        public bool ExistRoot(ref double a, ref double b)
        {
            double eps = 1e-1;
            if (P(a) * P(b) <= 0)
            {
                return true;
            }
            else
            {
                if (b - a < eps)
                {
                    return false;
                }
                else
                {
                    double mid = (a + b) / 2;
                    if (ExistRoot(ref a, ref mid))
                    {
                        b = mid;
                        return true;
                    }
                    else if (ExistRoot(ref mid, ref b))
                    {
                        a = mid;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Поиск корня на заданном интервале
        /// при условии, что корень существует.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <returns> корень </returns>
        public double FindRoot(double a, double b)
        {
            double eps = 1e-7;
            double mid = (a + b) / 2;
            while (Math.Abs(P(mid)) > eps)
            {
                if (P(a) * P(mid) > 0)
                {
                    a = mid;
                }
                else
                {
                    b = mid;
                }
                mid = (a + b) / 2;
            }
            return mid;
        }

        /// <summary>
        /// Поиск всех корней полинома на заданном интервале.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <returns> список всех корней </returns>
        public List<double> FindAllRoots(double a, double b)
        {
            double ta = a, tb = b;
            List<double> res = new List<double>();
            PolynomialWithRoots q = new PolynomialWithRoots(Coefs);
            double r;
            PolynomialWithRoots one = new PolynomialWithRoots(1);
            one.coefs[1] = 1;
            while (q.ExistRoot(ref a, ref b))
            {
                r = q.FindRoot(a, b);
                res.Add(r);
                one.coefs[0] = -r;
                q = q / one;
                a = ta;
                b = tb;
            }
            return res;
        }

        /// <summary>
        /// Поиск всех точек экстремума на заданном интервале.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <returns> список всех точек экстремума </returns>
        public List<(double, int)> FindAllStationaryPoints(double a, double b)
        {
            double eps = 1e-5;
            PolynomialWithRoots derivative = Parse(GetDerivative());
            List<double> roots = derivative.FindAllRoots(a, b);
            List<(double, int)> res = new List<(double, int)>();
            for (int i = 0; i < roots.Count; i++)
            {
                if (P(roots[i]) < P(roots[i] + eps) && P(roots[i]) < P(roots[i] - eps))
                {
                    res.Add((roots[i], -1));
                }
                else
                {
                    res.Add((roots[i], 1));
                }
            }
            return res;
        }

        /// <summary>
        /// Поиск корня на заданном интервале
        /// при условии, что корень существует.
        /// Использует метод Ньютона.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <returns> корень </returns>
        public double FindRootNewton(double a, double b)
        {
            double eps = 1e-7;
            double x0 = 0;

            if (P(a) * GetDerivative().GetDerivative().P(a) > 0)
            {
                x0 = a;
            }
            else if (P(b) * GetDerivative().GetDerivative().P(b) > 0)
            {
                x0 = b;
            }

            double xn = x0 - P(x0) / GetDerivative().P(x0);
            double xnp1 = xn - P(xn) / GetDerivative().P(xn);

            while (Math.Abs(xn - xnp1) >= eps)
            {
                xn = xnp1;
                xnp1 = xn - P(xn) / GetDerivative().P(xn);
            }
            return xnp1;
        }

        /// <summary>
        /// Поиск всех корней полинома на заданном интервале.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <returns> список всех корней </returns>
        public List<double> FindAllRootsNewton(double a, double b)
        {
            double ta = a, tb = b;
            List<double> res = new List<double>();
            PolynomialWithRoots q = new PolynomialWithRoots(Coefs);
            double r;
            PolynomialWithRoots one = new PolynomialWithRoots(1);
            one.coefs[1] = 1;
            while (q.ExistRoot(ref a, ref b))
            {
                r = q.FindRootNewton(a, b);
                res.Add(r);
                one.coefs[0] = -r;
                q = q / one;
                a = ta;
                b = tb;
            }
            return res;
        }
    }
}