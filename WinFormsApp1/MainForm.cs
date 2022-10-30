using ClassLibraryPolynomial;

namespace WinFormsAppPolynomial
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        const int MAX_N = 10000;  // максимальная степень полинома
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
        // Получение значения в точке для полинома A.
        private void btnAGetValue_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (double.TryParse(tbAInputX.Text, out double x))
            {
                double resInPoint = A.P(x);
                if (resInPoint == double.NegativeInfinity || resInPoint == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результат слишком большой.";
                    return;
                }
                tbOutput.Text = resInPoint.ToString();
            }
            else
                tbOutput.Text = "Ввод невозможно привести к числу.";
        }

        // Получение значения в точке для полинома B.
        private void btnBGetValue_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (double.TryParse(tbBInputX.Text, out double x))
            {
                double resInPoint = B.P(x);
                if (resInPoint == double.NegativeInfinity || resInPoint == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результат слишком большой.";
                    return;
                }
                tbOutput.Text = resInPoint.ToString();
            }
            else
                tbOutput.Text = "Ввод невозможно привести к числу.";
        }

        // Умножение полинома A на число.
        private void btnAMultiplyByN_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (double.TryParse(tbAInputN.Text, out double n))
            {
                R = A * n;
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

        // Умножение полинома B на число.
        private void btnBMultiplyByN_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (double.TryParse(tbBInputN.Text, out double n))
            {
                R = B * n;
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

        // Возведение полинома A в степень.
        private void btnAPow_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (int.TryParse(tbAPow.Text, out int n))
            {
                if (n < 0)
                {
                    tbOutput.Text = "Степень не должна быть меньше нуля.";
                    return;
                }
                if (A.N * n > MAX_N)
                {
                    tbOutput.Text = "Слишком высокая степень.";
                    return;
                }
                R = new PolynomialWithRoots(A.Pow(n).Coefs);
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

        // Возведение полинома B в степень.
        private void btnBPow_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (int.TryParse(tbBPow.Text, out int n))
            {
                if (n < 0)
                {
                    tbOutput.Text = "Степень не должна быть меньше нуля.";
                    return;
                }
                if (B.N * n > MAX_N)
                {
                    tbOutput.Text = "Слишком высокая степень.";
                    return;
                }
                R = new PolynomialWithRoots(B.Pow(n).Coefs);
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

        // Производная полинома A.
        private void btnAGetDerivative_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            R = new PolynomialWithRoots(A.GetDerivative().Coefs);
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // Производная полинома B.
        private void btnBGetDerivative_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            R = new PolynomialWithRoots(B.GetDerivative().Coefs);
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // Первообразная полинома A.
        private void btnAGetPrimitive_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (A.N >= MAX_N)
            {
                tbOutput.Text = "Слишком высокая степень исходного полинома.";
                return;
            }
            R = new PolynomialWithRoots(A.GetPrimitive().Coefs);
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // Первообразная полинома B.
        private void btnBGetPrimitive_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (B.N >= MAX_N)
            {
                tbOutput.Text = "Слишком высокая степень исходного полинома.";
                return;
            }
            R = new PolynomialWithRoots(B.GetPrimitive().Coefs);
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "Результирующий полином имеет слишком большие коэффициенты.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // Точки экстремума полинома A.
        private void bntAGetStationaryPoints_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (A.N <= 1)
            {
                tbOutput.Text = "Точек экстремума нет";
                return;
            }
            const int MAX_X = 100000;
            List<(double x, double y, StationaryPointType stPointType)> stationaryPoints = A.FindAllStationaryPoints(-MAX_X, MAX_X);
            stationaryPoints = stationaryPoints.OrderBy(item => item.x).ToList();
            string s = "";
            foreach (var item in stationaryPoints)
                s += $"({item.x}; {item.y}) - точка " + (item.stPointType == StationaryPointType.Min ? "минимума" : "максимума") + "\n";
            if (s == "")
                s = "Точек экстремума нет";
            tbOutput.Text = s;
        }

        // Точки экстремума полинома B.
        private void bntBGetStationaryPoints_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (B.N <= 1)
            {
                tbOutput.Text = "Точек экстремума нет";
                return;
            }
            const int MAX_X = 100000;
            List<(double x, double y, StationaryPointType stPointType)> stationaryPoints = B.FindAllStationaryPoints(-MAX_X, MAX_X);
            stationaryPoints = stationaryPoints.OrderBy(item => item.x).ToList();
            string s = "";
            foreach (var item in stationaryPoints)
                s += $"({item.x}; {item.y}) - точка " + (item.stPointType == StationaryPointType.Min ? "минимума" : "максимума") + "\n";
            if (s == "")
                s = "Точек экстремума нет";
            tbOutput.Text = s;
        }

        // Корни полинома A.
        private void btnAGetRoots_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            const int MAX_X = 100000;
            if (double.TryParse(tbARoot.Text, out double y))
            {
                List<double> roots = A.FindAllRootsNewton(-MAX_X, MAX_X, y);
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

        // Корни полинома B.
        private void btnBGetRoots_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            const int MAX_X = 100000;
            if (double.TryParse(tbBRoot.Text, out double y))
            {
                List<double> roots = B.FindAllRootsNewton(-MAX_X, MAX_X, y);
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

        // График полинома A
        private void btnAChartOutout_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (A.N > 40)
            {
                tbOutput.Text = "Слишком высокая степень полинома.";
                return;
            }
            int n = 2 * Math.Max(100, 10000 / ((int)Math.Pow(10, A.N / 10)));
            List<(double x, double y, StationaryPointType type)> stPoints = A.FindAllStationaryPoints(-100000, 100000);
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
                double Y = A.P(start);
                if (Y > 1.4e87 || Y < -1.4e87)
                {
                    tbOutput.Text = "Слишком высокая степень полинома";
                    return;
                }
                y.Add(Y);
                start += step;
            }
            ChartOutput f = new ChartOutput(x.ToArray(), y.ToArray());
            f.Show();
            SetInsertButtons(true);
        }

        // График полинома B
        private void btnBChartOutout_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbBPolynomial.Text == "")
            {
                tbOutput.Text = "Сначала введите полином.";
                return;
            }
            if (B.N > 40)
            {
                tbOutput.Text = "Слишком высокая степень полинома";
                return;
            }
            int n = 2 * Math.Max(100, 10000 / ((int)Math.Pow(10, B.N / 10)));
            List<(double x, double y, StationaryPointType type)> stPoints = B.FindAllStationaryPoints(-100000, 100000);
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
                double Y = B.P(start);
                if (Y > 1.4e87 || Y < -1.4e87)
                {
                    tbOutput.Text = "Слишком высокая степень полинома";
                    return;
                }
                y.Add(Y);
                start += step;
            }
            ChartOutput f = new ChartOutput(x.ToArray(), y.ToArray());
            f.Show();
            SetInsertButtons(true);
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
        
        // Форма для работы с интерполяцией и экстраполяцией.
        private void btnInterpolationExtrapolation_Click(object sender, EventArgs e)
        {
            PredictionForm f = new PredictionForm();
            f.Show();
        }

        // Установка доступности кнопок.
        void SetInsertButtons(bool enabled)
        {
            btnInsertA.Enabled = enabled;
            btnInsertB.Enabled = enabled;
        }
        #endregion
    }
}