namespace ClassLibraryPolynomial
{
    /// <summary>
    /// Класс Полином
    /// </summary>
    public class Polynomial
    {
        private static Random rnd = new Random();  // генератор случайных чисел
        public int N { get; }  // степень полинома
        public List<double> Coefs { get; }  // коэффициенты полинома

        /// <summary>
        /// Конструктор по умолчанию.
        /// Создает полином x^2 - 6x + 9.
        /// </summary>
        public Polynomial()
        {
            N = 2;
            Coefs = new List<double> { 1, -6, 9 };
        }

        /// <summary>
        /// Коструктор.
        /// Создаёт полином n-й степени с нулевыми коэффициентами. 
        /// </summary>
        /// <param name="n"> степень полинома </param>
        public Polynomial(int n)
        {
            N = n;
            Coefs = new List<double>(n);
            for (int i = 0; i <= n; i++)
            {
                Coefs.Add(0);
            }
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
            N = n;
            Coefs = new List<double>(n);
            for (int i = 0; i <= n; i++)
            {
                Coefs.Add(rnd.NextInt64(min, max));
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
            N = n;
            Coefs = new List<double>(n);
            for (int i = 0; i <= n; i++)
            {
                Coefs.Add(Math.Round(rnd.NextDouble() * (max - min) + min, round));
            }
        }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином, копируя переданные коэффициенты.
        /// </summary>
        /// <param name="coefs"> набор коэффициентов </param>
        public Polynomial(params double[] coefs)
        {
            N = coefs.Length - 1;
            Coefs = new List<double>(coefs);
        }

        /// <summary>
        /// Конструктор.
        /// Создаёт полином, копируя переданные коэффициенты.
        /// </summary>
        /// <param name="coefs"> набор коэффициентов </param>
        public Polynomial(IEnumerable<double> coefs)
        {
            N = coefs.Count() - 1;
            Coefs = new List<double>(coefs);
        }

        /// <summary>
        /// Переопределение метода ToString().
        /// </summary>
        /// <returns> строка, представляющая полином </returns>
        public override string ToString()
        {
            string res = GetFirstNotNullMember(out int position);
            for (int i = position + 1; i <= N; i++)
            {
                if (Coefs[i] == 0) continue;
                if (Math.Abs(Coefs[i]) == 1)
                {
                    if (i == N)
                        res += SetGign(Coefs[i]) + Math.Abs(Coefs[i]);
                    else if (i == N - 1)
                        res += SetGign(Coefs[i]) + "x";
                    else
                        res += SetGign(Coefs[i]) + "x^" + (N - i);
                }
                else
                {
                    if (i == N)
                        res += SetGign(Coefs[i]) + Math.Abs(Coefs[i]);
                    else if (i == N - 1)
                        res += SetGign(Coefs[i]) + Math.Abs(Coefs[i]) + "x";
                    else
                        res += SetGign(Coefs[i]) + Math.Abs(Coefs[i]) + "x^" + (N - i);
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
            for (i = 0; i <= N; i++)
            {
                if (Coefs[i] == 0) continue;
                if (Math.Abs(Coefs[i]) == 1)
                {
                    if (i == N)
                        res += Coefs[i];
                    else if (i == N - 1)
                        res += Coefs[i] == 1 ? "x" : "-x";
                    else
                        res += (Coefs[i] == 1 ? "x^" : "-x^") + (N - i);
                }
                else
                {
                    if (i == N)
                        res += Coefs[i];
                    else if (i == N - 1)
                        res += Coefs[i] + "x";
                    else
                        res += Coefs[i] + "x^" + (N - i);
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
    }
}