namespace ClassLibraryPolynomial
{
    /// <summary>
    /// Перечисление точка экстремума.
    /// </summary>
    public enum StationaryPointType
    {
        Min,  // точка минимума
        Max   // точка максимума
    }

    /// <summary>
    /// Класс полином с возможностью вычисления корней и точек экстремума.
    /// </summary>
    public class PolynomialWithRoots : Polynomial
    {
        #region Поля
        private protected List<double> roots = new List<double>();  // корни полинома
        private protected List<(double x, double y, StationaryPointType stPoint)> stationaryPoints = new();  // точки экстремума

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
        // Свойство для доступа к точкам экстремума.
        public List<(double x, double y, StationaryPointType stPoint)> StationaryPoints
        {
            get 
            {
                List<(double x, double y, StationaryPointType stPoint)> res = new();
                foreach ((double x, double y, StationaryPointType stPoint) item in stationaryPoints)
                {
                    res.Add(item);
                }
                return res;
            }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор по умолчанию.
        /// Создает полином второй степени и задаёт корни.
        /// </summary>
        public PolynomialWithRoots() : base()
        {
            roots = new List<double>();
            stationaryPoints = new List<(double x, double y, StationaryPointType stPoint)>();
            roots.Add(1);
            roots.Add(2);
        }

        /// <summary>
        /// Конструктор.
        /// Создает полином n-й степени с нулевыми коэффициентами.
        /// Список корней пока пуст.
        /// </summary>
        /// <param name="n"> степень полинома </param>
        public PolynomialWithRoots(int n) : base(n)
        {
            roots = new List<double>();
            stationaryPoints = new List<(double x, double y, StationaryPointType stPoint)>();
        }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином n-й степени со случайными коэффициентами
        /// целого типа из диапазона [min, max). 
        /// </summary>
        /// <param name="n"> степень полинома </param>
        /// <param name="min"> нижняя граница </param>
        /// <param name="max"> верхняя граница </param>
        public PolynomialWithRoots(int n, long min, long max) : base(n, min, max)
        {
            roots = new List<double>();
            stationaryPoints = new List<(double x, double y, StationaryPointType stPoint)>();
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
        public PolynomialWithRoots(int n, double min, double max, int round) : base(n, min, max, round)
        {
            roots = new List<double>();
            stationaryPoints = new List<(double x, double y, StationaryPointType stPoint)>();
        }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином, копируя переданные коэффициенты.
        /// </summary>
        /// <param name="coefs"> набор коэффициентов </param>
        public PolynomialWithRoots(double[] coefs) : base(coefs)
        {
            roots = new List<double>();
            stationaryPoints = new List<(double x, double y, StationaryPointType stPoint)>();
        }

        /// <summary>
        /// Конструктор.
        /// Создает полином, используя переданные корни.
        /// </summary>
        /// <param name="roots"> корни полинома </param>
        public PolynomialWithRoots(List<double> roots)
        {
            stationaryPoints = new List<(double x, double y, StationaryPointType stPoint)>();
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
            coefs[0] = -roots[0]; coefs[1] = 1;  // коэффициенты полинома 1-ой степени
            for (int k = 1; k < m; k++)
            {
                // вычисление коэффициентов полинома (k+1)-ой степени по коэффициентам полинома степени k
                coefs[k + 1] = 1;
                for (int i = k; i > 0; i--)
                    coefs[i] = -coefs[i] * roots[k] + coefs[i - 1];
                coefs[0] = -coefs[0] * roots[k];
            }
            return coefs;
        }
        #endregion

        #region Арифметические операции
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
            // Сложение коэффициентов, которые есть в 1-ом и 2-ом полиномах
            for (int i = 0; i <= m; i++)
                resCoef[i] = p1.coefs[i] + p2.coefs[i];
            // Копирование коэффициентов, которые есть только в одном полиноме
            for (int i = m + 1; i <= n; i++)
                resCoef[i] = (p1.n >= p2.n) ? p1.coefs[i] : p2.coefs[i];
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
            // Вычитание коэффициентов, которые есть в 1-ом и 2-ом полиномах
            for (int i = 0; i <= m; i++)
                resCoef[i] = p1.coefs[i] - p2.coefs[i];
            // Копирование коэффициентов, которые есть только в одном полиноме
            for (int i = m + 1; i <= n; i++)
                resCoef[i] = (p1.n >= p2.n) ? p1.coefs[i] : -p2.coefs[i];
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
            for (int i = 0; i <= n + m; i++)  // i указывает на индекс в итоговом массиве
                for (int k = 0; k <= Math.Min(i, n); k++)  // k указывает на индекс элемента в полиноме с меньшей степенью
                {
                    int j = i - k;  // j указывает на индекс элемента в полиноме с большей степенью
                    if (j <= m)  // если j не вышло за границы массива коэффициентов
                        resCoef[i] += p1.coefs[k] * p2.coefs[j];
                }
            PolynomialWithRoots res = new PolynomialWithRoots(resCoef);
            // Получение корней произведения полиномов
            foreach (double root in p1.Roots)
                res.roots.Add(root);
            foreach (double root in p2.Roots)
                res.roots.Add(root);
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
            int n = p1.n, m = p2.n;
            if (n < m)  // если степень первого полинома меньше степени второго, то результат деления нацело - 0
                return new PolynomialWithRoots(0);
            double[] pCoef = new double[n - m + 1];  // коэффициенты итогового полинома 
            double[] tCoef = new double[n + 1];  // коэффициенты делимого
            for (int i = 0; i <= n; i++)
                tCoef[i] = p1.coefs[i];
            for (int i = 0; i <= n - m; i++)
            {
                double d = tCoef[n - i] / p2.coefs[m];  // коэффициент итогового полинома
                pCoef[n - m - i] = d;
                tCoef[n - i] = 0;  // старший коэффициент делимого уничтожается
                for (int k = 1; k <= m; k++)
                    tCoef[n - i - k] -= d * p2.coefs[m - k];  // вычитание из делимого результата умножения d на p2
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
            int n = p1.n, m = p2.n;
            if (n < m)  // если степень первого полинома меньше степени второго, то остаток от деления нацело - первый полином
                return new PolynomialWithRoots(p1.coefs);
            double[] pCoef = new double[n - m + 1];
            double[] tCoef = new double[n + 1];
            for (int i = 0; i <= n; i++)
                tCoef[i] = p1.coefs[i];
            for (int i = 0; i <= n - m; i++)
            {
                double d = tCoef[n - i] / p2.coefs[m];
                pCoef[n - m - i] = d;
                tCoef[n - i] = 0;
                for (int k = 1; k <= m; k++)
                    tCoef[n - i - k] -= d * p2.coefs[m - k];
            }
            int j = 0;
            while (j <= n && tCoef[n - j] == 0)  // поиск ненулевого элемента в массиве tCoef
                j++;
            double[] resCoef = new double[1];
            if (j <= n)  // если был найден ненулевой элемент (остаток не равен нулю)
            {
                resCoef = new double[n - j + 1];
                for (int i = 0; i <= n - j; i++)
                    resCoef[i] = tCoef[i];  // копируем коэффициенты из массива tCoef
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
                resCoefs[i] = p.coefs[i];  // копируем коэффициенты из полинома
            for (int i = 0; i <= k; i++)
                resCoefs[i] *= n;  // умножаем коэффициенты на число
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
                resCoefs[i] = p.coefs[i];  // копируем коэффициенты из полинома
            for (int i = 0; i <= k; i++)
                resCoefs[i] *= n;  // умножаем коэффициенты на число
            return new PolynomialWithRoots(resCoefs);
        }
        #endregion

        #region Поиск корней полинома
        /// <summary>
        /// Существует ли корень полинома на заданном интервале.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <param name="y"> корень (по умолчанию 0) </param>
        /// <returns> true - если существует, иначе - false </returns>
        public bool ExistRoot(ref double a, ref double b, double y = 0)
        {
            PolynomialWithRoots pol = new PolynomialWithRoots(coefs);
            pol.coefs[0] -= y;
            double eps = 1e-1;
            if (pol.P(a) * pol.P(b) <= 0)
                return true;
            else if (b - a < eps)
                return false;
            else
            {
                double mid = (a + b) / 2;
                if (pol.ExistRoot(ref a, ref mid))
                {
                    b = mid;
                    return true;
                }
                else if (pol.ExistRoot(ref mid, ref b))
                {
                    a = mid;
                    return true;
                }
                else
                    return false;
            }
        }

        /// <summary>
        /// Поиск корня на заданном интервале
        /// при условии, что корень существует.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <param name="y"> корень (по умолчанию 0) </param>
        /// <returns> корень </returns>
        public double FindRoot(double a, double b, double y = 0)
        {
            PolynomialWithRoots pol = new PolynomialWithRoots(coefs);
            pol.coefs[0] -= y;
            double eps = 1e-7;
            double mid = (a + b) / 2;
            while (Math.Abs(pol.P(mid)) > eps)
            {
                if (pol.P(a) * pol.P(mid) > 0)
                    a = mid;
                else
                    b = mid;
                mid = (a + b) / 2;
            }
            return mid;
        }

        /// <summary>
        /// Поиск всех корней полинома на заданном интервале.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <param name="y"> корень (по умолчанию 0) </param>
        /// <returns> список всех корней </returns>
        public List<double> FindAllRoots(double a, double b, double y = 0)
        {
            double ta = a, tb = b;
            List<double> res = new List<double>();
            PolynomialWithRoots q = new PolynomialWithRoots(Coefs);
            q.coefs[0] -= y;
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
            roots = res;
            return res;
        }
        #endregion

        #region Поиск корней полинома (метод Ньютона)
        /// <summary>
        /// Поиск корня на заданном интервале
        /// при условии, что корень существует.
        /// Использует метод Ньютона.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <param name="y"> корень (по умолчанию 0) </param>
        /// <returns> корень </returns>
        public double FindRootNewton(double a, double b, double y = 0)
        {
            PolynomialWithRoots pol = new PolynomialWithRoots(coefs);
            pol.coefs[0] -= y;
            double eps = 1e-7;
            double x0 = 0;
            if (pol.P(a) * pol.GetDerivative().GetDerivative().P(a) > 0)
                x0 = a;
            else if (pol.P(b) * pol.GetDerivative().GetDerivative().P(b) > 0)
                x0 = b;
            double xn = x0 - pol.P(x0) / pol.GetDerivative().P(x0);
            double xnp1 = xn - pol.P(xn) / pol.GetDerivative().P(xn);
            while (Math.Abs(xn - xnp1) >= eps)
            {
                xn = xnp1;
                xnp1 = xn - pol.P(xn) / pol.GetDerivative().P(xn);
            }
            return xnp1;
        }

        /// <summary>
        /// Поиск всех корней полинома на заданном интервале.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <param name="y"> корень (по умолчанию 0) </param>
        /// <returns> список всех корней </returns>
        public List<double> FindAllRootsNewton(double a, double b, double y = 0)
        {
            double ta = a, tb = b;
            List<double> res = new List<double>();
            PolynomialWithRoots q = new PolynomialWithRoots(Coefs);
            q.coefs[0] -= y;
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
            roots = res;
            return res;
        }
        #endregion

        #region Поиск точек экстремума
        /// <summary>
        /// Поиск всех точек экстремума на заданном интервале.
        /// </summary>
        /// <param name="a"> левая граница интервала </param>
        /// <param name="b"> правая граница интервала </param>
        /// <returns> список всех точек экстремума </returns>
        public List<(double x, double y, StationaryPointType stPoint)> FindAllStationaryPoints(double a, double b)
        {
            double eps = 1e-5;
            PolynomialWithRoots derivative = new PolynomialWithRoots(GetDerivative().Coefs);
            List<double> roots = derivative.FindAllRoots(a, b);
            List<(double, double, StationaryPointType)> res = new List<(double, double, StationaryPointType)>();
            for (int i = 0; i < roots.Count; i++)
                if (P(roots[i]) < P(roots[i] + eps) && P(roots[i]) < P(roots[i] - eps))
                    res.Add((roots[i], P(roots[i]), StationaryPointType.Min));
                else
                    res.Add((roots[i], P(roots[i]), StationaryPointType.Max));
            stationaryPoints = res;
            return res;
        }
        #endregion
    }
}