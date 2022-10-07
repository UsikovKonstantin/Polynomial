namespace ClassLibraryPolynomial
{
    /// <summary>
    /// Класс точка.
    /// </summary>
    public class Point
    {
        public double X { get; set; }  // координата x
        public double Y { get; set; }  // координата y

        /// <summary>
        /// Конструктор по умолчанию.
        /// Создает точку (0; 0).
        /// </summary>
        public Point()
        {
            X = 0;
            Y = 0;
        }
        /// <summary>
        /// Конструктор.
        /// Создает точку (x; y).
        /// </summary>
        /// <param name="x"> координата x </param>
        /// <param name="y"> координата y </param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// Класс матрица.
    /// </summary>
    public class Matrix
    {
        public double[,] Args { get; set; }  // матрица
        public int RowCount { get; set; }  // количество строк
        public int ColCount { get; set; }  // количество столбцов

        #region Конструкторы
        /// <summary>
        /// Конструктор.
        /// Создает матрицу из одной строки (вектор).
        /// </summary>
        /// <param name="x"> вектор </param>
        public Matrix(double[] x)
        {
            RowCount = x.Length;
            ColCount = 1;
            Args = new double[RowCount, ColCount];
            for (int i = 0; i < Args.GetLength(0); i++)
                for (int j = 0; j < Args.GetLength(1); j++)
                    Args[i, j] = x[i];
        }

        /// <summary>
        /// Конструктор.
        /// Копирует переданные данные в матрицу.
        /// </summary>
        /// <param name="x"> двумерный массив </param>
        public Matrix(double[,] x)
        {
            RowCount = x.GetLength(0);
            ColCount = x.GetLength(1);
            Args = new double[RowCount, ColCount];
            for (int i = 0; i < Args.GetLength(0); i++)
                for (int j = 0; j < Args.GetLength(1); j++)
                    Args[i, j] = x[i, j];
        }

        /// <summary>
        /// Конструктор.
        /// Копирует переданные данные в матрицу.
        /// </summary>
        /// <param name="other"> другая матрица </param>
        public Matrix(Matrix other)
        {
            RowCount = other.RowCount;
            ColCount = other.ColCount;
            Args = new double[RowCount, ColCount];
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColCount; j++)
                    Args[i, j] = other.Args[i, j];
        }
        #endregion

        #region Методы
        /// <summary>
        /// Переопределение ToString()
        /// </summary>
        /// <returns> строковое представление матрицы </returns>
        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < Args.GetLength(0); i++)
            {
                for (int j = 0; j < Args.GetLength(1); j++)
                {
                    s += string.Format("{0} ", Args[i, j]);
                }
                s += "\n";
            }
            return s;
        }

        /// <summary>
        /// Получение транспонированной матрицы.
        /// </summary>
        /// <returns> транспонированная матрица </returns>
        public Matrix Transposition()
        {
            double[,] t = new double[ColCount, RowCount];
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColCount; j++)
                    t[j, i] = Args[i, j];
            return new Matrix(t);
        }

        /// <summary>
        /// Умножение матрицы на число.
        /// </summary>
        /// <param name="m"> матрица </param>
        /// <param name="k"> число </param>
        /// <returns> матрица, умноженная на число </returns>
        public static Matrix operator *(Matrix m, double k)
        {
            Matrix ans = new Matrix(m);
            for (int i = 0; i < ans.RowCount; i++)
                for (int j = 0; j < ans.ColCount; j++)
                    ans.Args[i, j] = m.Args[i, j] * k;
            return ans;
        }

        /// <summary>
        /// Умножение матрицы на матрицу
        /// </summary>
        /// <param name="m1"> первая матрица </param>
        /// <param name="m2"> вторая матрица </param>
        /// <returns> матрица - результат умножения </returns>
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            double[,] ans = new double[m1.RowCount, m2.ColCount];
            for (int i = 0; i < m1.RowCount; i++)
            {
                for (int j = 0; j < m2.ColCount; j++)
                {
                    for (int k = 0; k < m2.RowCount; k++)
                    {
                        ans[i, j] += m1.Args[i, k] * m2.Args[k, j];
                    }
                }
            }
            return new Matrix(ans);
        }

        /// <summary>
        /// Получение минора матрицы.
        /// </summary>
        /// <param name="row"> индекс строки </param>
        /// <param name="column"> индекс столбца </param>
        /// <returns> минор матрицы </returns>
        private Matrix GetMinor(int row, int column)
        {
            double[,] minor = new double[RowCount - 1, ColCount - 1];
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColCount; j++)
                {
                    if ((i != row) || (j != column))
                    {
                        if (i > row && j < column) minor[i - 1, j] = Args[i, j];
                        if (i < row && j > column) minor[i, j - 1] = Args[i, j];
                        if (i > row && j > column) minor[i - 1, j - 1] = Args[i, j];
                        if (i < row && j < column) minor[i, j] = Args[i, j];
                    }
                }
            }
            return new Matrix(minor);
        }

        /// <summary>
        /// Поиск определителя матрицы
        /// </summary>
        /// <param name="m"> матрица </param>
        /// <returns> определитель матрицы </returns>
        public static double Determ(Matrix m)
        {
            double det = 0;
            int length = m.RowCount;

            if (length == 1) det = m.Args[0, 0];
            if (length == 2) det = m.Args[0, 0] * m.Args[1, 1] - m.Args[0, 1] * m.Args[1, 0];

            if (length > 2)
                for (int i = 0; i < m.ColCount; i++)
                    det += Math.Pow(-1, 0 + i) * m.Args[0, i] * Determ(m.GetMinor(0, i));
            return det;
        }

        /// <summary>
        /// Поиск матрицы миноров (алгебраических дополнений)
        /// </summary>
        /// <returns> матрица миноров </returns>
        public Matrix MinorMatrix()
        {
            double[,] ans = new double[RowCount, ColCount];

            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColCount; j++)
                    ans[i, j] = Math.Pow(-1, i + j) * Determ(this.GetMinor(i, j));

            return new Matrix(ans);
        }

        /// <summary>
        /// Получение обратной матрицы.
        /// </summary>
        /// <returns> обратная матрица </returns>
        public Matrix InverseMatrix()
        {
            if (Math.Abs(Determ(this)) <= 0.000000001) throw new ArgumentException("Обратная матрица не существует!");
            double k = 1 / Determ(this);
            Matrix minorMatrix = MinorMatrix();
            return minorMatrix.Transposition() * k;
        }
        #endregion
    }

    /// <summary>
    /// Класс, позволяющий строить интра- и экстраполяционные полиномы.
    /// </summary>
    public class PolynomialPrediction : PolynomialWithRoots
    {
        private Point[] points = new Point[0];  // точки, по которым строится полином
        // Свойство для доступа к точкам
        public Point[] Points
        {
            get { return points; }
        }

        #region Конструкторы
        /// <summary>
        /// Конструктор по умолчанию.
        /// Создает полином второй степени и задаёт корни.
        /// </summary>
        public PolynomialPrediction() : base()
        {
            roots.Add(1);
            roots.Add(2);
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
        /// Конструктор.
        /// Создаёт интерполяционный полином Лагранжа по заданным точкам.
        /// </summary>
        /// <param name="points"> массив точек </param>
        public PolynomialPrediction(Point[] points)
        {
            PolynomialPrediction t = GetPredictionPolynomial(points);
            coefs = t.coefs;
            n = t.n;
            roots = t.roots;
            stationaryPoints = t.stationaryPoints;
            this.points = points;
        }

        /// <summary>
        /// Поиск множителя Лагранжа.
        /// </summary>
        /// <param name="index"> индекс X </param>
        /// <param name="points"> массив точек </param>
        /// <returns></returns>
        private PolynomialPrediction L(int index, Point[] points)
        {
            PolynomialPrediction L = new PolynomialPrediction(new double[] { 1 });
            for (int i = 0; i < points.Length; i++)
            {
                if (i != index)
                {
                    PolynomialPrediction r = new PolynomialPrediction(new double[] { -points[i].X, 1 });
                    L *= r * (1 / (points[index].X - points[i].X));
                }
            }
            return L;
        }

        /// <summary>
        /// Построение полинома Лагранжа по точкам.
        /// </summary>
        /// <param name="points"> точки </param>
        /// <returns> полином Лагранжа </returns>
        private PolynomialPrediction GetPredictionPolynomial(Point[] points)
        {
            PolynomialPrediction p = new PolynomialPrediction(new double[] { 0 });
            for (int i = 0; i < points.Length; i++)
            {
                p += L(i, points) * points[i].Y;
            }
            return p;
        }

        /// <summary>
        /// Конструктор.
        /// Создаёт экстраполяционный полином методом наименьших квадратов.
        /// </summary>
        /// <param name="m"> порядок полинома </param>
        /// <param name="points"> массив точек </param>
        public PolynomialPrediction(int m, Point[] points)
        {
            PolynomialPrediction t = LeastSquaresMethod(m, points);
            coefs = t.coefs;
            n = t.n;
            roots = t.roots;
            stationaryPoints = t.stationaryPoints;
            this.points = points;
        }

        /// <summary>
        /// Построение экстраполяционного полинома методом наименьших квадратов.
        /// </summary>
        /// <param name="m"> порядок полинома </param>
        /// <param name="points"> массив точек </param>
        /// <returns> экстраполяционный полином </returns>
        public PolynomialPrediction LeastSquaresMethod(int m, Point[] points)
        {
            if (m <= 0) throw new ArgumentException("Порядок полинома должен быть больше 0");
            if (m >= points.Length) throw new ArgumentException("Порядок полинома должен быть на много меньше количества точек!");

            // Массив для хранения значений базисных функций
            double[,] basic = new double[points.Length, m + 1];
            // Заполнение массива для базисных функций
            for (int i = 0; i < basic.GetLength(0); i++)
                for (int j = 0; j < basic.GetLength(1); j++)
                    basic[i, j] = Math.Pow(points[i].X, j);
            // Создание матрицы из массива значений базисных функций (МЗБФ)
            Matrix basicFuncMatr = new Matrix(basic);
            // Транспонирование МЗБФ
            Matrix transBasicFuncMatr = basicFuncMatr.Transposition();
            // Произведение транспонированного  МЗБФ на МЗБФ
            Matrix lambda = transBasicFuncMatr * basicFuncMatr;
            // Произведение транспонированого МЗБФ на следящую матрицу 
            double[] Y = new double[points.Length];
            for (int i = 0; i < Y.Length; i++)
                Y[i] = points[i].Y;
            Matrix beta = transBasicFuncMatr * new Matrix(Y);
            // Решение СЛАУ путем умножения обратной матрицы лямбда на бету
            Matrix a = lambda.InverseMatrix() * beta;
            // Получение результирующего полинома
            double[] coeff = new double[a.RowCount];
            for (int i = 0; i < coeff.Length; i++)
            {
                coeff[i] = a.Args[i, 0];
            }
            return new PolynomialPrediction(coeff);
        }
        #endregion

        #region Арифметические операции
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

        /// <summary>
        /// Вычитание полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> разность полиномов </returns>
        public static PolynomialPrediction operator -(PolynomialPrediction p1, PolynomialPrediction p2)
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
            return new PolynomialPrediction(resCoef);
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
        /// Деление полиномов нацело.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> полином - результат деления нацело </returns>
        public static PolynomialPrediction operator /(PolynomialPrediction p1, PolynomialPrediction p2)
        {
            int n = p1.n;
            int m = p2.n;
            if (n < m)
            {
                return new PolynomialPrediction(0);
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
            return new PolynomialPrediction(pCoef);
        }

        /// <summary>
        /// Остаток от деления нацело полиномов.
        /// </summary>
        /// <param name="p1"> первый полином </param>
        /// <param name="p2"> второй полином </param>
        /// <returns> полином - остаток от деления нацело </returns>
        public static PolynomialPrediction operator %(PolynomialPrediction p1, PolynomialPrediction p2)
        {
            int n = p1.n;
            int m = p2.n;
            if (n < m)
            {
                return new PolynomialPrediction(p1.coefs);
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
            return new PolynomialPrediction(resCoef);
        }

        /// <summary>
        /// Умножение полинома на число.
        /// </summary>
        /// <param name="n"> число, на которое умножается полином </param>
        /// <param name="p"> полином для умножения </param>
        /// <returns> полином - результат умножения </returns>
        public static PolynomialPrediction operator *(double n, PolynomialPrediction p)
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
        #endregion

        /// <summary>
        /// Метод нахождения среднеквадратичного отклонения.
        /// </summary>
        /// <param name="p"> полином </param>
        /// <param name="points"> точки </param>
        /// <returns> среднеквадратичное отклонение </returns>
        public double? GetDelta(Point[] points)
        {
            if (Coefs == null) return null;
            double[] dif = new double[points.Length];
            double[] f = new double[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < coefs.Length; j++)
                {
                    f[i] += coefs[j] * Math.Pow(points[i].X, j);
                }
                dif[i] = Math.Pow(f[i] - points[i].Y, 2);
            }
            return Math.Sqrt(dif.Sum() / points.Length);
        }
    }
}