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

        const int MAX_N = 1000;  // ������������ ������� ��������
        PolynomialWithRoots A = new PolynomialWithRoots(new double[] { 3, 2, 1 });  // ������ �������
        PolynomialWithRoots B = new PolynomialWithRoots(new double[] { 6, 5, 4 });  // ������ �������
        PolynomialWithRoots R = new PolynomialWithRoots();  // ��������� �������� ��� ����� ����������

        #region ������� TextChanged
        // ��������� �������� ������������� ��� �������� A.
        private void tbACoefs_TextChanged(object sender, EventArgs e)
        {
            string[] coefsStr = tbACoefs.Text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (coefsStr.Length > MAX_N + 1)
            {
                epACoefs.SetError(tbACoefs, "������� ����� �������������.");
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
                        epACoefs.SetError(tbACoefs, "������� ������� ������������.");
                        tbACoefs.Margin = new Padding(3, 3, 20, 3);
                        tbAPolynomial.Text = "";
                        return;
                    }
                    coefs[i] = n;
                }
                else
                {
                    epACoefs.SetError(tbACoefs, "���������� �������� ��� �������� � �����.");
                    tbACoefs.Margin = new Padding(3, 3, 20, 3);
                    tbAPolynomial.Text = "";
                    return;
                }
            epACoefs.Clear();
            tbACoefs.Margin = new Padding(3, 3, 3, 3);
            A = new PolynomialWithRoots(coefs);
            tbAPolynomial.Text = A.ToString();
        }

        // ��������� �������� ������������� ��� �������� B.
        private void tbBCoefs_TextChanged(object sender, EventArgs e)
        {
            string[] coefsStr = tbBCoefs.Text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (coefsStr.Length > MAX_N + 1)
            {
                epBCoefs.SetError(tbBCoefs, "������� ����� �������������.");
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
                        epBCoefs.SetError(tbBCoefs, "������� ������� ������������.");
                        tbBCoefs.Margin = new Padding(3, 3, 20, 3);
                        tbBPolynomial.Text = "";
                        return;
                    }
                    coefs[i] = n;
                }
                else
                {
                    epBCoefs.SetError(tbBCoefs, "���������� �������� ��� �������� � �����.");
                    tbBCoefs.Margin = new Padding(3, 3, 20, 3);
                    tbBPolynomial.Text = "";
                    return;
                }
            epBCoefs.Clear();
            tbBCoefs.Margin = new Padding(3, 3, 3, 3);
            B = new PolynomialWithRoots(coefs);
            tbBPolynomial.Text = B.ToString();
        }

        // ��������� ��������� �������� ��� ���������� �������� �������� A � ����� X.
        private void tbAInputX_TextChanged(object sender, EventArgs e)
        {
            string s = tbAInputX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epAInputX.SetError(tbAInputX, "���������� �������� ���� � �����.");
                tbAInputX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epAInputX.Clear();
                tbAInputX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // ��������� ��������� �������� ��� ���������� �������� �������� B � ����� X.
        private void tbBInputX_TextChanged(object sender, EventArgs e)
        {
            string s = tbBInputX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epBInputX.SetError(tbBInputX, "���������� �������� ���� � �����.");
                tbBInputX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBInputX.Clear();
                tbBInputX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // ��������� ��������� �������� ��� ��������� �������� A �� ����� N.
        private void tbAInputN_TextChanged(object sender, EventArgs e)
        {
            string s = tbAInputN.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epAInputN.SetError(tbAInputN, "���������� �������� ���� � �����.");
                tbAInputN.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epAInputN.Clear();
                tbAInputN.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // ��������� ��������� �������� ��� ��������� �������� B �� ����� N.
        private void tbBInputN_TextChanged(object sender, EventArgs e)
        {
            string s = tbBInputN.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epBInputN.SetError(tbBInputN, "���������� �������� ���� � �����.");
                tbBInputN.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBInputN.Clear();
                tbBInputN.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // ��������� ��������� �������� ��� ���������� �������� A � �������.
        private void tbAPow_TextChanged(object sender, EventArgs e)
        {
            string s = tbAPow.Text.Trim();
            if (s != "" && !int.TryParse(s, out int _))
            {
                epAPow.SetError(tbAPow, "���������� �������� ���� � ������ �����.");
                tbAPow.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epAPow.Clear();
                tbAPow.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // ��������� ��������� �������� ��� ���������� �������� B � �������.
        private void tbBPow_TextChanged(object sender, EventArgs e)
        {
            string s = tbBPow.Text.Trim();
            if (s != "" && !int.TryParse(s, out int _))
            {
                epBPow.SetError(tbBPow, "���������� �������� ���� � ������ �����.");
                tbBPow.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBPow.Clear();
                tbBPow.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // ��������� ��������� �������� ��� ������ ������ �������� A.
        private void tbARoot_TextChanged(object sender, EventArgs e)
        {
            string s = tbARoot.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epARoot.SetError(tbARoot, "���������� �������� ���� � �����.");
                tbARoot.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epARoot.Clear();
                tbARoot.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // ��������� ��������� �������� ��� ������ ������ �������� B.
        private void tbBRoot_TextChanged(object sender, EventArgs e)
        {
            string s = tbBRoot.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epBRoot.SetError(tbBRoot, "���������� �������� ���� � �����.");
                tbBRoot.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBRoot.Clear();
                tbBRoot.Margin = new Padding(3, 3, 3, 3);
            }
        }
        #endregion

        #region �������� ��� ����� ����������
        // �������� �������� �������.
        private void btnSwap_Click(object sender, EventArgs e)
        {
            (tbACoefs.Text, tbBCoefs.Text) = (tbBCoefs.Text, tbACoefs.Text);
        }

        // �������� ���������.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "������� ������� ��������.";
                return;
            }
            R = A + B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "�������������� ������� ����� ������� ������� ������������.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // ��������� ���������.
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "������� ������� ��������.";
                return;
            }
            R = A - B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "�������������� ������� ����� ������� ������� ������������.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // ��������� ���������.
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "������� ������� ��������.";
                return;
            }
            if (A.N + B.N > MAX_N)
            {
                tbOutput.Text = "�������������� ������� ����� ������� ������� �������.";
                return;
            }
            R = A * B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "�������������� ������� ����� ������� ������� ������������.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // ������� ��������� ������.
        private void btnDivide_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "������� ������� ��������.";
                return;
            }
            R = A / B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "�������������� ������� ����� ������� ������� ������������.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }

        // ������� �� ������� ��������� ������.
        private void btnMod_Click(object sender, EventArgs e)
        {
            SetInsertButtons(false);
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                tbOutput.Text = "������� ������� ��������.";
                return;
            }
            R = A % B;
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "�������������� ������� ����� ������� ������� ������������.";
                    return;
                }
            tbOutput.Text = R.ToString();
            SetInsertButtons(true);
        }
        #endregion

        #region �������� ��� ����� ���������
        // ��������� ��������
        private void Generate(string textN, string textMin, string textMax, RichTextBox output)
        {
            if (int.TryParse(textN, out int n) && long.TryParse(textMin, out long min) && long.TryParse(textMax, out long max))
            {
                if (n < 0 || n > MAX_N)
                {
                    tbOutput.Text = $"N ������ ���� � ��������� [0, {MAX_N}].";
                    SetInsertButtons(false);
                    return;
                }
                if (min > max)
                {
                    tbOutput.Text = $"����������� �������� ������ ���� ������ �������������.";
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
                tbOutput.Text = "������� ������ ���������� �������� � ������ �����.";
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

        // ��������� �������� �������� � �����.
        private void GetValue(PolynomialWithRoots pol, string textPol, string textA)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "������� ������� �������.";
                return;
            }
            if (double.TryParse(textA, out double x))
            {
                double resInPoint = pol.P(x);
                if (resInPoint == double.NegativeInfinity || resInPoint == double.PositiveInfinity)
                {
                    tbOutput.Text = "��������� ������� �������.";
                    return;
                }
                R = new PolynomialWithRoots(new double[] { resInPoint });
                tbOutput.Text = R.ToString();
                SetInsertButtons(true);
            }
            else
                tbOutput.Text = "���� ���������� �������� � �����.";
        }
        private void btnAGetValue_Click(object sender, EventArgs e)
        {
            GetValue(A, tbAPolynomial.Text, tbAInputX.Text);
        }
        private void btnBGetValue_Click(object sender, EventArgs e)
        {
            GetValue(B, tbBPolynomial.Text, tbBInputX.Text);
        }

        // ��������� �������� �� �����.
        private void MultiplyByN(PolynomialWithRoots pol, string textPol, string textN)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "������� ������� �������.";
                return;
            }
            if (double.TryParse(textN, out double n))
            {
                R = pol * n;
                for (int i = 0; i <= R.N; i++)
                    if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                    {
                        tbOutput.Text = "�������������� ������� ����� ������� ������� ������������.";
                        return;
                    }
                tbOutput.Text = R.ToString();
                SetInsertButtons(true);
            }
            else
                tbOutput.Text = "���� ���������� �������� � �����.";
        }
        private void btnAMultiplyByN_Click(object sender, EventArgs e)
        {
            MultiplyByN(A, tbAPolynomial.Text, tbAInputN.Text);
        }
        private void btnBMultiplyByN_Click(object sender, EventArgs e)
        {
            MultiplyByN(B, tbBPolynomial.Text, tbBInputN.Text);
        }

        // ���������� �������� � �������.
        private void Pow(PolynomialWithRoots pol, string textPol, string textA)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "������� ������� �������.";
                return;
            }
            if (int.TryParse(textA, out int n))
            {
                if (n < 0)
                {
                    tbOutput.Text = "������� �� ������ ���� ������ ����.";
                    return;
                }
                if (pol.N * n > MAX_N)
                {
                    tbOutput.Text = "������� ������� �������.";
                    return;
                }
                R = new PolynomialWithRoots(pol.Pow(n).Coefs);
                for (int i = 0; i <= R.N; i++)
                    if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                    {
                        tbOutput.Text = "�������������� ������� ����� ������� ������� ������������.";
                        return;
                    }
                tbOutput.Text = R.ToString();
                SetInsertButtons(true);
            }
            else
                tbOutput.Text = "���� ���������� �������� � ������ �����.";
        }
        private void btnAPow_Click(object sender, EventArgs e)
        {
            Pow(A, tbAPolynomial.Text, tbAPow.Text);
        }
        private void btnBPow_Click(object sender, EventArgs e)
        {
            Pow(B, tbBPolynomial.Text, tbBPow.Text);
        }

        // ����� ��������.
        private void GetRoots(PolynomialWithRoots pol, string textPol, string textA)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "������� ������� �������.";
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
                    tbOutput.Text = "������ ���";
                else
                    tbOutput.Text = s;
            }
            else
                tbOutput.Text = "���� ���������� �������� � �����.";
        }
        private void btnAGetRoots_Click(object sender, EventArgs e)
        {
            GetRoots(A, tbAPolynomial.Text, tbARoot.Text);
        }
        private void btnBGetRoots_Click(object sender, EventArgs e)
        {
            GetRoots(B, tbBPolynomial.Text, tbBRoot.Text);
        }

        // ����������� ��������.
        private void GetDerivative(PolynomialWithRoots pol, string textPol)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "������� ������� �������.";
                return;
            }
            R = new PolynomialWithRoots(pol.GetDerivative().Coefs);
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "�������������� ������� ����� ������� ������� ������������.";
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

        // ������������� ��������.
        private void GetPrimitive(PolynomialWithRoots pol, string textPol)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "������� ������� �������.";
                return;
            }
            if (pol.N >= MAX_N)
            {
                tbOutput.Text = "������� ������� ������� ��������� ��������.";
                return;
            }
            R = new PolynomialWithRoots(pol.GetPrimitive().Coefs);
            for (int i = 0; i <= R.N; i++)
                if (R.Coefs[i] == double.NegativeInfinity || R.Coefs[i] == double.PositiveInfinity)
                {
                    tbOutput.Text = "�������������� ������� ����� ������� ������� ������������.";
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

        // ����� ���������� ��������.
        private void GetStationaryPoints(PolynomialWithRoots pol, string textPol)
        {
            SetInsertButtons(false);
            if (textPol == "")
            {
                tbOutput.Text = "������� ������� �������.";
                return;
            }
            if (pol.N <= 1)
            {
                tbOutput.Text = "����� ���������� ���";
                return;
            }
            const int MAX_X = 10000;
            List<(double x, double y, StationaryPointType stPointType)> stationaryPoints = pol.FindAllStationaryPoints(-MAX_X, MAX_X);
            stationaryPoints = stationaryPoints.OrderBy(item => item.x).ToList();
            string s = "";
            foreach (var item in stationaryPoints)
                s += $"({item.x}; {item.y}) - ����� " + (item.stPointType == StationaryPointType.Min ? "��������" : "���������") + "\n";
            if (s == "")
                s = "����� ���������� ���";
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

        // ������ ��������.
        private void ChartOutout(PolynomialWithRoots pol, string textPol)
        {
            if (textPol == "")
            {
                tbOutput.Text = "������� ������� �������.";
                SetInsertButtons(false);
                return;
            }
            if (pol.N > 40)
            {
                tbOutput.Text = "������� ������� ������� ��������.";
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
                    tbOutput.Text = "������� ������� ������� ��������";
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
                tbOutput.Text = "�� ������� ��������� ������";
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

        #region ��������������� �������
        // ��������� ������� �� ������ � ������� A.
        private void btnInsertA_Click(object sender, EventArgs e)
        {
            double[] coefs = R.Coefs;
            string s = "";
            for (int i = coefs.Length - 1; i >= 0; i--)
                s += coefs[i].ToString() + " ";
            tbACoefs.Text = s;
        }

        // ��������� ������� �� ������ � ������� B.
        private void btnInsertB_Click(object sender, EventArgs e)
        {
            double[] coefs = R.Coefs;
            string s = "";
            for (int i = coefs.Length - 1; i >= 0; i--)
                s += coefs[i].ToString() + " ";
            tbBCoefs.Text = s;
        }

        // ��������� ����������� ������.
        void SetInsertButtons(bool enabled)
        {
            btnInsertA.Enabled = enabled;
            btnInsertB.Enabled = enabled;
        }
        #endregion

        #region ������������ / �������������
        List<Point> points = new List<Point>();  // ������ �����, �� ������� �������� �������
        List<IPlottable> charts = new List<IPlottable>();  // ������
        List<IPlottable> redPoints = new List<IPlottable>();  // ��������� �����
        List<IPlottable> bluePoints = new List<IPlottable>();  // �������� �����

        // ��������� ��������� �������� ���������� X �����.
        private void rtbInputX_TextChanged(object sender, EventArgs e)
        {
            string s = rtbInputX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epInputX.SetError(rtbInputX, "���������� �������� � �����.");
                rtbInputX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epInputX.Clear();
                rtbInputX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // ��������� ��������� �������� ���������� Y �����.
        private void rtbInputY_TextChanged(object sender, EventArgs e)
        {
            string s = rtbInputY.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epInputY.SetError(rtbInputY, "���������� �������� � �����.");
                rtbInputY.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epInputY.Clear();
                rtbInputY.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // ��������� ��������� �������� ���������� X ����� ��� ������ ������� ��������.
        private void tbLagrangeX_TextChanged(object sender, EventArgs e)
        {
            string s = tbLagrangeX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epLagrangeX.SetError(tbLagrangeX, "���������� �������� � �����.");
                tbLagrangeX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epLagrangeX.Clear();
                tbLagrangeX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // ��������� ��������� �������� ���������� X ����� ��� ������ ������� ���������� ���������.
        private void tbSquareX_TextChanged(object sender, EventArgs e)
        {
            string s = tbSquareX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epSquareX.SetError(tbSquareX, "���������� �������� � �����.");
                tbSquareX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epSquareX.Clear();
                tbSquareX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // ��������� ��������� �������� ������� �������� N ��� ������ ������� ���������� ���������.
        private void tbSquareN_TextChanged(object sender, EventArgs e)
        {
            string s = tbSquareN.Text.Trim();
            if (s != "" && !double.TryParse(s, out double n))
            {
                epSquareN.SetError(tbSquareN, "���������� �������� � �����.");
                tbSquareN.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epSquareN.Clear();
                tbSquareN.Margin = new Padding(3, 3, 3, 3);
            }
        }

        // ���������� �����.
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
                tbOutput2.Text = "��������� ���������� ���������� �������� � �����.";
        }

        // ������� �����.
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

        // ���������� �������� ������� ��������.
        private void btnLagrange_Click(object sender, EventArgs e)
        {
            if (points.Count == 0)
            {
                tbOutput2.Text = "��� �����.";
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
                        tbOutput2.Text = "�� ������� ��������� ������� ��������.";
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
                tbOutput2.Text = "���������� �������:\n" + polynomial.ToString() + "\n";
                tbOutput2.Text += "������������������ ����������:\n" + polynomial.GetDelta(points.ToArray()).ToString();
            }
            else
                tbOutput2.Text = "��������� ���������� ���������� �������� � �����.";
        }

        // ���������� �������� ������� ���������� ���������.
        private void btnSquare_Click(object sender, EventArgs e)
        {
            if (points.Count == 0)
            {
                tbOutput2.Text = "��� �����.";
                return;
            }
            if (double.TryParse(tbSquareX.Text, out double x) && int.TryParse(tbSquareN.Text, out int N))
            {
                if (points.Count <= N)
                {
                    tbOutput2.Text = "���������� ����� ������ ���� ������ ������� ��������.";
                    return;
                }
                if (N <= 0)
                {
                    tbOutput2.Text = "������� �������� ������ ���� ������ ����.";
                    return;
                }

                PolynomialPrediction polynomial;
                try
                {
                    polynomial = new PolynomialPrediction(N, points.ToArray());
                }
                catch (Exception)
                {
                    tbOutput2.Text = "�� ������� ��������� ������� ������� ���������� ���������.";
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
                        tbOutput2.Text = "�� ������� ��������� ������� ������� ���������� ���������.";
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
                tbOutput2.Text = "���������� �������:\n" + polynomial.ToString() + "\n";
                tbOutput2.Text += "������������������ ����������:\n" + polynomial.GetDelta(points.ToArray()).ToString();
            }
            else
                tbOutput2.Text = "X ��� N ���������� �������� � �����.";
        }

        // ����� ������� ���� ����� (������� � ���������� X �� Y)
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

        // ����� ������� ���� ����� (������� � ���������� Y �� X)
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

        // ����� ������� ���� ����� (����������� ������ ����� �� ��������� �������)
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