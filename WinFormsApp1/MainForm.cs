using ClassLibraryPolynomial;
using ScottPlot.Plottable;
using Point = ClassLibraryPolynomial.Point;

namespace WinFormsAppPolynomial
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        const int MAX_N = 1000;  // максимальная степень полинома
        PolynomialWithRoots A = new PolynomialWithRoots(new double[] { 3, 2, 1 });  // первый полином
        PolynomialWithRoots B = new PolynomialWithRoots(new double[] { 6, 5, 4 });  // второй полином
        PolynomialWithRoots R = new PolynomialWithRoots();  // результат операций над двумя полиномами

        #region События TextChanged
        // Изменение введённых коэффициентов для полинома A.
        private void tbACoefs_TextChanged(object sender, EventArgs e)
        {
            string[] coefsStr = tbACoefs.Text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (coefsStr.Length > MAX_N + 1)
            {
                epACoefs.SetError(tbACoefs, "Слишком много коэффициентов.");
                tbACoefs.Margin = new Padding(3, 3, 20, 3);
                tbAPolynomial.Text = "";
                return;
            }
            double[] coefs = new double[coefsStr.Length];
            for (int i = 0; i < coefs.Length; i++)
                if (double.TryParse(coefsStr[coefs.Length - i - 1], out double n))
                {
                    if (n == double.PositiveInfinity || n == double.NegativeInfinity)
                    {
                        epACoefs.SetError(tbACoefs, "Слишком большие коэффициенты.");
                        tbACoefs.Margin = new Padding(3, 3, 20, 3);
                        tbAPolynomial.Text = "";
                        return;
                    }
                    coefs[i] = n;
                }
                else
                {
                    epACoefs.SetError(tbACoefs, "Невозможно привести все значения к числу.");
                    tbACoefs.Margin = new Padding(3, 3, 20, 3);
                    tbAPolynomial.Text = "";
                    return;
                }
            epACoefs.Clear();
            tbACoefs.Margin = new Padding(3, 3, 3, 3);
            A = new PolynomialWithRoots(coefs);
            tbAPolynomial.Text = A.ToString();
        }

        // Изменение введённых коэффициентов для полинома B.
        private void tbBCoefs_TextChanged(object sender, EventArgs e)
        {
            string[] coefsStr = tbBCoefs.Text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (coefsStr.Length > MAX_N + 1)
            {
                epBCoefs.SetError(tbBCoefs, "Слишком много коэффициентов.");
                tbBCoefs.Margin = new Padding(3, 3, 20, 3);
                tbBPolynomial.Text = "";
                return;
            }
            double[] coefs = new double[coefsStr.Length];
            for (int i = 0; i < coefs.Length; i++)
                if (double.TryParse(coefsStr[coefs.Length - i - 1], out double n))
                {
                    if (n == double.PositiveInfinity || n == double.NegativeInfinity)
                    {
                        epBCoefs.SetError(tbBCoefs, "Слишком большие коэффициенты.");
                        tbBCoefs.Margin = new Padding(3, 3, 20, 3);
                        tbBPolynomial.Text = "";
                        return;
                    }
                    coefs[i] = n;
                }
                else
                {
                    epBCoefs.SetError(tbBCoefs, "Невозможно привести все значения к числу.");
                    tbBCoefs.Margin = new Padding(3, 3, 20, 3);
                    tbBPolynomial.Text = "";
                    return;
                }
            epBCoefs.Clear();
            tbBCoefs.Margin = new Padding(3, 3, 3, 3);
            B = new PolynomialWithRoots(coefs);
            tbBPolynomial.Text = B.ToString();
        }

        // Изменение введённого значения для вычисления значения полинома A в точке X.
        private void tbAInputX_TextChanged(object sender, EventArgs e)
        {
            string s = tbAInputX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epAInputX.SetError(tbAInputX, "Невозможно привести ввод к числу.");
                tbAInputX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epAInputX.Clear();
                tbAInputX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для вычисления значения полинома B в точке X.
        private void tbBInputX_TextChanged(object sender, EventArgs e)
        {
            string s = tbBInputX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epBInputX.SetError(tbBInputX, "Невозможно привести ввод к числу.");
                tbBInputX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBInputX.Clear();
                tbBInputX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для умножения полинома A на число N.
        private void tbAInputN_TextChanged(object sender, EventArgs e)
        {
            string s = tbAInputN.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epAInputN.SetError(tbAInputN, "Невозможно привести ввод к числу.");
                tbAInputN.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epAInputN.Clear();
                tbAInputN.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для умножения полинома B на число N.
        private void tbBInputN_TextChanged(object sender, EventArgs e)
        {
            string s = tbBInputN.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epBInputN.SetError(tbBInputN, "Невозможно привести ввод к числу.");
                tbBInputN.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBInputN.Clear();
                tbBInputN.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для возведения полинома A в степень.
        private void tbAPow_TextChanged(object sender, EventArgs e)
        {
            string s = tbAPow.Text.Trim();
            if (s != "" && !int.TryParse(s, out int _))
            {
                epAPow.SetError(tbAPow, "Невозможно привести ввод к целому числу.");
                tbAPow.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epAPow.Clear();
                tbAPow.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для возведения полинома B в степень.
        private void tbBPow_TextChanged(object sender, EventArgs e)
        {
            string s = tbBPow.Text.Trim();
            if (s != "" && !int.TryParse(s, out int _))
            {
                epBPow.SetError(tbBPow, "Невозможно привести ввод к целому числу.");
                tbBPow.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBPow.Clear();
                tbBPow.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для поиска корней полинома A.
        private void tbARoot_TextChanged(object sender, EventArgs e)
        {
            string s = tbARoot.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epARoot.SetError(tbARoot, "Невозможно привести ввод к числу.");
                tbARoot.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epARoot.Clear();
                tbARoot.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения для поиска корней полинома B.
        private void tbBRoot_TextChanged(object sender, EventArgs e)
        {
            string s = tbBRoot.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epBRoot.SetError(tbBRoot, "Невозможно привести ввод к числу.");
                tbBRoot.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBRoot.Clear();
                tbBRoot.Margin = new Padding(3, 3, 3, 3);
            }
        }
        #endregion

        #region Операции над двумя полиномами
        // Поменять полиномы местами.
        private void btnSwap_Click(object sender, EventArgs e)
        {
            (tbACoefs.Text, tbBCoefs.Text) = (tbBCoefs.Text, tbACoefs.Text);
        }

        // Сложение полиномов.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полиномы.";
                return;
            }
            R = A + B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // Вычитание полиномов.
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полиномы.";
                return;
            }
            R = A - B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // Умножение полиномов.
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полиномы.";
                return;
            }
            if (A.N + B.N > MAX_N)
            {
                tbOutput.Text = "Результирующий полином имеет слишком высокую степень.";
                return;
            }
            R = A * B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // Деление полиномов нацело.
        private void btnDivide_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полиномы.";
                return;
            }
            R = A / B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // Остаток от деления полиномов нацело.
        private void btnMod_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полиномы.";
                return;
            }
            R = A % B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }
        #endregion

        #region Операции над одним полиномом
        // Генерация полинома
        private void Generate(string textN, string textMin, string textMax, RichTextBox output)
        {
            if (int.TryParse(textN, out int n) && long.TryParse(textMin, out long min) && long.TryParse(textMax, out long max))
            {
                if (n < 0 || n > MAX_N)
                {
                    tbOutput.Text = $"N должно быть в диапазоне [0, {MAX_N}].";
                    SetInsertButtons(false);
                    return;
                }
                if (min > max)
                {
                    tbOutput.Text = $"Минимальное значение должно быть меньше максимального.";
                    SetInsertButtons(false);
                    return;
                }
                string s = "";
                A = new PolynomialWithRoots(n, min, max + 1);
                foreach (double item in A.Coefs)
                {
                    s += item + " ";
                }
                output.Text = s;
            }
            else
            {
                tbOutput.Text = "Входные данные невозможно привести к целому числу.";
                SetInsertButtons(false);
            }
        }
        private void btnGenerateA_Click(object sender, EventArgs e)
        {
            Generate(rtbN_A.Text, rtbMin_A.Text, rtbMax_A.Text, tbACoefs);
        }
        private void btnGenerateB_Click(object sender, EventArgs e)
        {
            Generate(rtbN_B.Text, rtbMin_B.Text, rtbMax_B.Text, tbBCoefs);
        }

        // Получение значения полинома в точке.
        private void GetValue(PolynomialWithRoots pol, string textPol, string textA)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (double.TryParse(textA, out double x))
            {
                double resInPoint = pol.P(x);
                if (resInPoint == double.NegativeInfinity || resInPoint == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результат слишком большой.";
                    return;
                }
                R = new PolynomialWithRoots(new double[] { resInPoint });
                tbOutput.Text = R.ToString();
                SetInsertButtons(true);
            }
            else
                tbOutput.Text = "Ввод невозможно привести к числу.";
        }
        private void btnAGetValue_Click(object sender, EventArgs e)
        {
            GetValue(A, tbAPolynomial.Text, tbAInputX.Text);
        }
        private void btnBGetValue_Click(object sender, EventArgs e)
        {
            GetValue(B, tbBPolynomial.Text, tbBInputX.Text);
        }

        // Умножение полинома на число.
        private void MultiplyByN(PolynomialWithRoots pol, string textPol, string textN)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (double.TryParse(textN, out double n))
            {
                R = pol * n;
                for (int i = 0; i <= R.N; i++)
                    if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                    {
                        tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                        return;
                    }
                tbOutput.Text = R.ToString();
                SetInsertButtons(true);
            }
            else
                tbOutput.Text = "Ввод невозможно привести к числу.";
        }
        private void btnAMultiplyByN_Click(object sender, EventArgs e)
        {
            MultiplyByN(A, tbAPolynomial.Text, tbAInputN.Text);
        }
        private void btnBMultiplyByN_Click(object sender, EventArgs e)
        {
            MultiplyByN(B, tbBPolynomial.Text, tbBInputN.Text);
        }

        // Возведение полинома в степень.
        private void Pow(PolynomialWithRoots pol, string textPol, string textA)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (int.TryParse(textA, out int n))
            {
                if (n < 0)
                {
                    tbOutput.Text = "Степень не должна быть меньше нуля.";
                    return;
                }
                if (pol.N * n > MAX_N)
                {
                    tbOutput.Text = "Слишком высокая степень.";
                    return;
                }
                R = new PolynomialWithRoots(pol.Pow(n).Coefs);
                for (int i = 0; i <= R.N; i++)
                    if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                    {
                        tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                        return;
                    }
                tbOutput.Text = R.ToString();
                SetInsertButtons(true);
            }
            else
                tbOutput.Text = "Ввод невозможно привести к целому числу.";
        }
        private void btnAPow_Click(object sender, EventArgs e)
        {
            Pow(A, tbAPolynomial.Text, tbAPow.Text);
        }
        private void btnBPow_Click(object sender, EventArgs e)
        {
            Pow(B, tbBPolynomial.Text, tbBPow.Text);
        }

        // Корни полинома.
        private void GetRoots(PolynomialWithRoots pol, string textPol, string textA)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            const int MAX_X = 10000;
            if (double.TryParse(textA, out double y))
            {
                List<double> roots = pol.FindAllRootsNewton(-MAX_X, MAX_X, y);
                roots.Sort();
                string s = "";
                if (roots.Count >= 2)
                {
                    if (Math.Abs(roots[1] - roots[0]) < 1e-5)
                        s += Math.Round(roots[1], 6) + "\n";
                    else
                        s += roots[0] + "\n";
                    for (int i = 1; i < roots.Count; i++)
                        if (Math.Abs(roots[i] - roots[i - 1]) > 1e-5)
                            s += roots[i] + "\n";
                }
                else if (roots.Count == 1)
                    s += roots[0];
                if (s == "")
                    tbOutput.Text = "Корней нет";
                else
                    tbOutput.Text = s;
            }
            else
                tbOutput.Text = "Ввод невозможно привести к числу.";
        }
        private void btnAGetRoots_Click(object sender, EventArgs e)
        {
            GetRoots(A, tbAPolynomial.Text, tbARoot.Text);
        }
        private void btnBGetRoots_Click(object sender, EventArgs e)
        {
            GetRoots(B, tbBPolynomial.Text, tbBRoot.Text);
        }

        // Производная полинома.
        private void GetDerivative(PolynomialWithRoots pol, string textPol)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            R = new PolynomialWithRoots(pol.GetDerivative().Coefs);
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }
        private void btnAGetDerivative_Click(object sender, EventArgs e)
        {
            GetDerivative(A, tbAPolynomial.Text);
        }
        private void btnBGetDerivative_Click(object sender, EventArgs e)
        {
            GetDerivative(B, tbBPolynomial.Text);
        }

        // Первообразная полинома.
        private void GetPrimitive(PolynomialWithRoots pol, string textPol)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (pol.N >= MAX_N)
            {
                tbOutput.Text = "Слишком высокая степень исходного полинома.";
                return;
            }
            R = new PolynomialWithRoots(pol.GetPrimitive().Coefs);
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }
        private void btnAGetPrimitive_Click(object sender, EventArgs e)
        {
            GetPrimitive(A, tbAPolynomial.Text);
        }
        private void btnBGetPrimitive_Click(object sender, EventArgs e)
        {
            GetPrimitive(B, tbBPolynomial.Text);
        }

        // Точки экстремума полинома.
        private void GetStationaryPoints(PolynomialWithRoots pol, string textPol)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (pol.N <= 1)
            {
                tbOutput.Text = "Точек экстремума нет";
                return;
            }
            const int MAX_X = 10000;
            List<(double x, double y, StationaryPointType stPointType)> stationaryPoints = pol.FindAllStationaryPoints(-MAX_X, MAX_X);
            stationaryPoints = stationaryPoints.OrderBy(item => item.x).ToList();
            string s = "";
            foreach (var item in stationaryPoints)
                s += $"({item.x}; {item.y}) - точка " + (item.stPointType == StationaryPointType.Min ? "минимума" : "максимума") + "\n";
            if (s == "")
                s = "Точек экстремума нет";
            tbOutput.Text = s;
        }
        private void bntAGetStationaryPoints_Click(object sender, EventArgs e)
        {
            GetStationaryPoints(A, tbAPolynomial.Text);
        }
        private void bntBGetStationaryPoints_Click(object sender, EventArgs e)
        {
            GetStationaryPoints(B, tbBPolynomial.Text);
        }

        // График полинома.
        private void ChartOutout(PolynomialWithRoots pol, string textPol)
        {
            if (textPol == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                SetInsertButtons(false);
                return;
            }
            if (pol.N > 40)
            {
                tbOutput.Text = "Слишком высокая степень полинома.";
                SetInsertButtons(false);
                return;
            }
            int n = 2 * Math.Max(100, 10000 / ((int)Math.Pow(10, pol.N / 10)));
            List<(double x, double y, StationaryPointType type)> stPoints = pol.FindAllStationaryPoints(-100000, 100000);
            stPoints = stPoints.OrderBy(item => item.x).ToList();
            double start, end;
            if (stPoints.Count == 0)
            {
                start = -10;
                end = 10;
            }
            else if (stPoints.Count == 1)
            {
                start = stPoints[0].x - 10;
                end = stPoints[0].x + 10;
            }
            else
            {
                double maxDif = -1;
                for (int i = 1; i < stPoints.Count; i++)
                    if (stPoints[i].x - stPoints[i - 1].x > maxDif)
                        maxDif = stPoints[i].x - stPoints[i - 1].x;
                int c = stPoints.Count - 1;
                start = stPoints[0].x - Math.Max(maxDif, 10);
                end = stPoints[c].x + Math.Max(maxDif, 10);
            }
            double step = (end - start) / n;
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            while (start <= end)
            {
                x.Add(start);
                double Y = pol.P(start);
                if (Y > 1.4e87 || Y < -1.4e87)
                {
                    tbOutput.Text = "Слишком высокая степень полинома";
                    SetInsertButtons(false);
                    return;
                }
                y.Add(Y);
                start += step;
            }
            ChartOutput f;
            try
            {
                f = new ChartOutput(x.ToArray(), y.ToArray());
            }
            catch (Exception)
            {
                tbOutput.Text = "Не удалось построить график";
                SetInsertButtons(false);
                return;
            }
            f.Show();
        }
        private void btnAChartOutout_Click(object sender, EventArgs e)
        {
            ChartOutout(A, tbAPolynomial.Text);
        }
        private void btnBChartOutout_Click(object sender, EventArgs e)
        {
            ChartOutout(B, tbBPolynomial.Text);
        }
        #endregion

        #region Вспомогательные функции
        // Поместить полином из вывода в полином A.
        private void btnInsertA_Click(object sender, EventArgs e)
        {
            double[] coefs = R.Coefs;
            string s = "";
            for (int i = coefs.Length - 1; i >= 0; i--)
                s += coefs[i].ToString() + " ";
            tbACoefs.Text = s;
        }

        // Поместить полином из вывода в полином B.
        private void btnInsertB_Click(object sender, EventArgs e)
        {
            double[] coefs = R.Coefs;
            string s = "";
            for (int i = coefs.Length - 1; i >= 0; i--)
                s += coefs[i].ToString() + " ";
            tbBCoefs.Text = s;
        }

        // Установка доступности кнопок.
        void SetInsertButtons(bool enabled)
        {
            btnInsertA.Enabled = enabled;
            btnInsertB.Enabled = enabled;
        }
        #endregion

        #region Интерполяция / экстраполяция
        List<Point> points = new List<Point>();  // список точек, по которым строится полином
        List<IPlottable> charts = new List<IPlottable>();  // график
        List<IPlottable> redPoints = new List<IPlottable>();  // найденная точка
        List<IPlottable> bluePoints = new List<IPlottable>();  // заданные точки

        // Изменение введённого значения координаты X точки.
        private void rtbInputX_TextChanged(object sender, EventArgs e)
        {
            string s = rtbInputX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epInputX.SetError(rtbInputX, "Невозможно привести к числу.");
                rtbInputX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epInputX.Clear();
                rtbInputX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения координаты Y точки.
        private void rtbInputY_TextChanged(object sender, EventArgs e)
        {
            string s = rtbInputY.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epInputY.SetError(rtbInputY, "Невозможно привести к числу.");
                rtbInputY.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epInputY.Clear();
                rtbInputY.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения координаты X точки для поиска методом Лагранжа.
        private void tbLagrangeX_TextChanged(object sender, EventArgs e)
        {
            string s = tbLagrangeX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epLagrangeX.SetError(tbLagrangeX, "Невозможно привести к числу.");
                tbLagrangeX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epLagrangeX.Clear();
                tbLagrangeX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения координаты X точки для поиска методом наименьших квадратов.
        private void tbSquareX_TextChanged(object sender, EventArgs e)
        {
            string s = tbSquareX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epSquareX.SetError(tbSquareX, "Невозможно привести к числу.");
                tbSquareX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epSquareX.Clear();
                tbSquareX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Изменение введённого значения степени полинома N для поиска методом наименьших квадратов.
        private void tbSquareN_TextChanged(object sender, EventArgs e)
        {
            string s = tbSquareN.Text.Trim();
            if (s != "" && !double.TryParse(s, out double n))
            {
                epSquareN.SetError(tbSquareN, "Невозможно привести к числу.");
                tbSquareN.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epSquareN.Clear();
                tbSquareN.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // Добавление точки.
        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            if (double.TryParse(rtbInputX.Text, out double x) && double.TryParse(rtbInputY.Text, out double y))
            {
                bluePoints.Add(plot.Plot.AddPoint(x, y, Color.Blue, 10));
                plot.Refresh();
                foreach (var item in points)
                    if (item.X == x && item.Y == y)
                        return;
                points.Add(new Point(x, y));
                rtbInputX.Text = "";
                rtbInputY.Text = "";
                rtbInputX.Focus();
            }
            else
                tbOutput2.Text = "Введенные координаты невозможно привести к числу.";
        }

        // Очистка точек.
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (charts.Count != 0)
            {
                plot.Plot.Remove(charts[charts.Count - 1]);
                charts.Remove(charts[charts.Count - 1]);
                plot.Plot.Remove(redPoints[redPoints.Count - 1]);
                redPoints.Remove(redPoints[redPoints.Count - 1]);
                plot.Refresh();
                return;
            }
            if (bluePoints.Count != 0)
            {
                plot.Plot.Remove(bluePoints[bluePoints.Count - 1]);
                bluePoints.Remove(bluePoints[bluePoints.Count - 1]);
                points.RemoveAt(points.Count - 1);
                plot.Refresh();
            }
        }

        // Вычисление полинома методом Лагранжа.
        private void btnLagrange_Click(object sender, EventArgs e)
        {
            if (points.Count == 0)
            {
                tbOutput2.Text = "Нет точек.";
                return;
            }
            if (double.TryParse(tbLagrangeX.Text, out double x))
            {
                PolynomialPrediction polynomial = new PolynomialPrediction(points.ToArray());

                double xMin = double.MaxValue;
                double xMax = double.MinValue;
                foreach (var item in points)
                {
                    if (item.X < xMin)
                        xMin = item.X;
                    if (item.X > xMax)
                        xMax = item.X;
                }
                if (x < xMin)
                    xMin = x;
                if (x > xMax)
                    xMax = x;

                List<double> X = new List<double>();
                List<double> Y = new List<double>();

                double i = xMin - 10;
                double step = (xMax - xMin + 20) / 1000;
                while (i <= xMax + 10)
                {
                    X.Add(i);
                    double y = polynomial.P(i);
                    if (double.IsNaN(y))
                    {
                        tbOutput2.Text = "Не удалось вычислить полином Лагранжа.";
                        return;
                    }
                    Y.Add(y);
                    i += step;
                }

                if (charts.Count != 0)
                {
                    plot.Plot.Remove(charts[charts.Count - 1]);
                    charts.Remove(charts[charts.Count - 1]);
                    plot.Plot.Remove(redPoints[redPoints.Count - 1]);
                    redPoints.Remove(redPoints[redPoints.Count - 1]);
                    plot.Refresh();
                }

                charts.Add(plot.Plot.AddScatter(X.ToArray(), Y.ToArray(), Color.Black, 2, 0));
                redPoints.Add(plot.Plot.AddPoint(x, polynomial.P(x), Color.Red, 10));
                plot.Refresh();
                tbLagrangeY.Text = polynomial.P(x).ToString();
                tbOutput2.Text = "Полученный полином:\n" + polynomial.ToString() + "\n";
                tbOutput2.Text += "Среднеквадратичное отклонение:\n" + polynomial.GetDelta(points.ToArray()).ToString();
            }
            else
                tbOutput2.Text = "Введенные координаты невозможно привести к числу.";
        }

        // Вычисление полинома методом наименьших квадратов.
        private void btnSquare_Click(object sender, EventArgs e)
        {
            if (points.Count == 0)
            {
                tbOutput2.Text = "Нет точек.";
                return;
            }
            if (double.TryParse(tbSquareX.Text, out double x) && int.TryParse(tbSquareN.Text, out int N))
            {
                if (points.Count <= N)
                {
                    tbOutput2.Text = "Количество точек должно быть больше степени полинома.";
                    return;
                }
                if (N <= 0)
                {
                    tbOutput2.Text = "Степень полинома должна быть больше нуля.";
                    return;
                }

                PolynomialPrediction polynomial;
                try
                {
                    polynomial = new PolynomialPrediction(N, points.ToArray());
                }
                catch (Exception)
                {
                    tbOutput2.Text = "Не удалось вычислить полином методом наименьших квадратов.";
                    return;
                }

                double xMin = double.MaxValue;
                double xMax = double.MinValue;
                foreach (var item in points)
                {
                    if (item.X < xMin)
                        xMin = item.X;
                    if (item.X > xMax)
                        xMax = item.X;
                }
                if (x < xMin)
                    xMin = x;
                if (x > xMax)
                    xMax = x;

                List<double> X = new List<double>();
                List<double> Y = new List<double>();

                double i = xMin - 10;
                double step = (xMax - xMin + 20) / 1000;
                while (i <= xMax + 10)
                {
                    X.Add(i);
                    double y = polynomial.P(i);
                    if (double.IsNaN(y))
                    {
                        tbOutput2.Text = "Не удалось вычислить полином методом наименьших квадратов.";
                        return;
                    }
                    Y.Add(y);
                    i += step;
                }

                if (charts.Count != 0)
                {
                    plot.Plot.Remove(charts[charts.Count - 1]);
                    charts.Remove(charts[charts.Count - 1]);
                    plot.Plot.Remove(redPoints[redPoints.Count - 1]);
                    redPoints.Remove(redPoints[redPoints.Count - 1]);
                    plot.Refresh();
                }

                charts.Add(plot.Plot.AddScatter(X.ToArray(), Y.ToArray(), Color.Black, 2, 0));
                redPoints.Add(plot.Plot.AddPoint(x, polynomial.P(x), Color.Red, 10));
                plot.Refresh();
                tbSquareY.Text = polynomial.P(x).ToString();
                tbOutput2.Text = "Полученный полином:\n" + polynomial.ToString() + "\n";
                tbOutput2.Text += "Среднеквадратичное отклонение:\n" + polynomial.GetDelta(points.ToArray()).ToString();
            }
            else
                tbOutput2.Text = "X или N невозможно привести к числу.";
        }

        // Более удобный ввод точек (переход с текстбокса X на Y)
        private void rtbInputX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (rtbInputX.Focused)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    rtbInputY.Focus();
                }
                else if (rtbInputY.Focused)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    rtbInputX.Focus();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                btnAddPoint_Click(sender, e);
            }
        }

        // Более удобный ввод точек (переход с текстбокса Y на X)
        private void rtbInputY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (rtbInputX.Focused)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    rtbInputY.Focus();
                }
                else if (rtbInputY.Focused)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    rtbInputX.Focus();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                btnAddPoint_Click(sender, e);
            }
        }

        // Более удобный ввод точек (возможность задать точку по положению курсора)
        private void plot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                (double x, double y) = plot.GetMouseCoordinates();
                bluePoints.Add(plot.Plot.AddPoint(x, y, Color.Blue, 10));
                plot.Refresh();
                foreach (var item in points)
                    if (item.X == x && item.Y == y)
                        return;
                points.Add(new Point(x, y));
            }
        }
        #endregion
    }
}