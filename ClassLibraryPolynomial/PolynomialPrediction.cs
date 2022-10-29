using PluSolver;

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

        #endregion

        #region Методы
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
        #endregion
    }

    /// <summary>
    /// Класс, позволяющий строить интра- и экстраполяционные полиномы.
    /// </summary>
    public class PolynomialPrediction : PolynomialWithRoots
    {
        #region Поля
        private Point[] points = new Point[0];  // точки, по которым строится полином
        // Свойство для доступа к точкам
        public Point[] Points
        {
            get { return points; }
        }
        #endregion

        #region Констукторы, вызывающие базовые конструкторы
        /// <summary>
        /// Конструктор по умолчанию.
        /// Создает полином второй степени и задаёт корни.
        /// </summary>
        public PolynomialPrediction() : base()
        { }

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
        public PolynomialPrediction(List<double> roots) : base(roots)
        { }
        #endregion

        #region Конструктор полинома Лагранжа (интерполяция)
        /// <summary>
        /// Конструктор.
        /// Создаёт интерполяционный полином Лагранжа по заданным точкам.
        /// </summary>
        /// <param name="points"> массив точек </param>
        public PolynomialPrediction(Point[] points)
        {
            PolynomialWithRoots p = new PolynomialWithRoots(new double[] { 0 });
            for (int i = 0; i < points.Length; i++)
            {
                p += L(i, points) * points[i].Y;
            }
            coefs = p.Coefs;
            n = p.N;
            roots = p.Roots;
            stationaryPoints = p.StationaryPoints;
            this.points = points;
        }

        /// <summary>
        /// Поиск множителя Лагранжа.
        /// </summary>
        /// <param name="index"> индекс X </param>
        /// <param name="points"> массив точек </param>
        /// <returns></returns>
        private PolynomialWithRoots L(int index, Point[] points)
        {
            PolynomialWithRoots L = new PolynomialWithRoots(new double[] { 1 });
            for (int i = 0; i < points.Length; i++)
                if (i != index)
                {
                    PolynomialWithRoots r = new PolynomialWithRoots(new double[] { -points[i].X, 1 });
                    L *= r * (1 / (points[index].X - points[i].X));
                }
            return L;
        }
        #endregion

        #region Конструктор по методу наименьших квадратов (экстраполяция)
        /// <summary>
        /// Конструктор.
        /// Создаёт экстраполяционный полином методом наименьших квадратов.
        /// </summary>
        /// <param name="m"> порядок полинома </param>
        /// <param name="points"> массив точек </param>
        public PolynomialPrediction(int m, Point[] points)
        {
            PolynomialWithRoots p = LeastSquaresMethod(m, points);
            coefs = p.Coefs;
            n = p.N;
            roots = p.Roots;
            stationaryPoints = p.StationaryPoints;
            this.points = points;
        }

        /// <summary>
        /// Построение экстраполяционного полинома методом наименьших квадратов.
        /// </summary>
        /// <param name="m"> порядок полинома </param>
        /// <param name="points"> массив точек </param>
        /// <returns> экстраполяционный полином </returns>
        public PolynomialWithRoots LeastSquaresMethod(int m, Point[] points)
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
            // Произведение транспонированого МЗБФ на матрицу значений
            double[] Y = new double[points.Length];
            for (int i = 0; i < Y.Length; i++)
                Y[i] = points[i].Y;
            Matrix beta = transBasicFuncMatr * new Matrix(Y);
            // Решение СЛАУ 
            double[] beta2 = new double[m + 1];
            for (int i = 0; i < beta2.Length; i++)
                beta2[i] = beta.Args[i, 0];
            var solver = new Solver(lambda.Args, beta2);
            double[] coeff = solver.SolveX();
            // Получение результирующего полинома
            return new PolynomialWithRoots(coeff);
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод нахождения среднеквадратичного отклонения.
        /// </summary>
        /// <param name="p"> полином </param>
        /// <param name="points"> точки </param>
        /// <returns> среднеквадратичное отклонение </returns>
        public double GetDelta(Point[] points)
        {
            double[] dif = new double[points.Length];
            double[] f = new double[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                f[i] = P(points[i].X);
                dif[i] = Math.Pow(f[i] - points[i].Y, 2);
            }
            return Math.Sqrt(dif.Sum() / points.Length);
        }
        #endregion
    }
}