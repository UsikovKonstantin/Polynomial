using ClassLibraryPolynomial;
using System.Windows.Forms;
using WinFormsAppPolynomial;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        PolynomialWithRoots A = new PolynomialWithRoots(new double[] { 3, 2, 1 });
        PolynomialWithRoots B = new PolynomialWithRoots(new double[] { 6, 5, 4 });
        PolynomialWithRoots R = new PolynomialWithRoots();

        private void tbACoefs_TextChanged(object sender, EventArgs e)
        {
            string s = tbACoefs.Text.Trim();
            string[] coefsStr = s.Split();
            double[] coefs = new double[coefsStr.Length];
            for (int i = 0; i < coefs.Length; i++)
            {
                if (double.TryParse(coefsStr[coefs.Length - i - 1], out double n))
                {
                    coefs[i] = n;
                }
                else
                {
                    epACoefs.SetError(tbACoefs, "Невозможно привести все значения к целому числу");
                    tbACoefs.Margin = new Padding(3, 3, 20, 3);
                    tbAPolynomial.Text = "";
                    return;
                }
            }
            epACoefs.Clear();
            tbACoefs.Margin = new Padding(3, 3, 3, 3);
            A = new PolynomialWithRoots(coefs);
            tbAPolynomial.Text = A.ToString();
        }

        private void tbBCoefs_TextChanged(object sender, EventArgs e)
        {
            string s = tbBCoefs.Text.Trim();
            string[] coefsStr = s.Split();
            double[] coefs = new double[coefsStr.Length];
            for (int i = 0; i < coefs.Length; i++)
            {
                if (double.TryParse(coefsStr[coefs.Length - i - 1], out double n))
                {
                    coefs[i] = n;
                }
                else
                {
                    epBCoefs.SetError(tbBCoefs, "Невозможно привести все значения к целому числу");
                    tbBCoefs.Margin = new Padding(3, 3, 20, 3);
                    tbBPolynomial.Text = "";
                    return;
                }
            }
            epBCoefs.Clear();
            tbBCoefs.Margin = new Padding(3, 3, 3, 3);
            B = new PolynomialWithRoots(coefs);
            tbBPolynomial.Text = B.ToString();
        }

        private void tbAInputX_TextChanged(object sender, EventArgs e)
        {
            string s = tbAInputX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double x))
            {
                epAInputX.SetError(tbAInputX, "Невозможно привести к целому числу");
                tbAInputX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epAInputX.Clear();
                tbAInputX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        private void tbBInputX_TextChanged(object sender, EventArgs e)
        {
            string s = tbBInputX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double x))
            {
                epBInputX.SetError(tbBInputX, "Невозможно привести к целому числу");
                tbBInputX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBInputX.Clear();
                tbBInputX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        private void tbAInputN_TextChanged(object sender, EventArgs e)
        {
            string s = tbAInputN.Text.Trim();
            if (s != "" && !double.TryParse(s, out double x))
            {
                epAInputN.SetError(tbAInputN, "Невозможно привести к целому числу");
                tbAInputN.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epAInputN.Clear();
                tbAInputN.Margin = new Padding(3, 3, 3, 3);
            }
        }

        private void tbBInputN_TextChanged(object sender, EventArgs e)
        {
            string s = tbBInputN.Text.Trim();
            if (s != "" && !double.TryParse(s, out double x))
            {
                epBInputN.SetError(tbBInputN, "Невозможно привести к целому числу");
                tbBInputN.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBInputN.Clear();
                tbBInputN.Margin = new Padding(3, 3, 3, 3);
            }
        }

        private void tbAPow_TextChanged(object sender, EventArgs e)
        {
            string s = tbAPow.Text.Trim();
            if (s != "" && !int.TryParse(s, out int x))
            {
                epAPow.SetError(tbAPow, "Невозможно привести к целому числу");
                tbAPow.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epAPow.Clear();
                tbAPow.Margin = new Padding(3, 3, 3, 3);
            }
        }

        private void tbBPow_TextChanged(object sender, EventArgs e)
        {
            string s = tbBPow.Text.Trim();
            if (s != "" && !int.TryParse(s, out int x))
            {
                epBPow.SetError(tbBPow, "Невозможно привести к целому числу");
                tbBPow.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBPow.Clear();
                tbBPow.Margin = new Padding(3, 3, 3, 3);
            }
        }

        private void tbARoot_TextChanged(object sender, EventArgs e)
        {
            string s = tbARoot.Text.Trim();
            if (s != "" && !double.TryParse(s, out double x))
            {
                epARoot.SetError(tbARoot, "Невозможно привести к целому числу");
                tbARoot.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epARoot.Clear();
                tbARoot.Margin = new Padding(3, 3, 3, 3);
            }
        }

        private void tbBRoot_TextChanged(object sender, EventArgs e)
        {
            string s = tbBRoot.Text.Trim();
            if (s != "" && !double.TryParse(s, out double x))
            {
                epBRoot.SetError(tbBRoot, "Невозможно привести к целому числу");
                tbBRoot.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBRoot.Clear();
                tbBRoot.Margin = new Padding(3, 3, 3, 3);
            }
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string t = tbACoefs.Text;
            tbACoefs.Text = tbBCoefs.Text;
            tbBCoefs.Text = t;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                return;
            }
            R = A + B;
            tbOutput.Text = R.ToString();
            btnInsertA.Enabled = true;
            btnInsertB.Enabled = true;
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                return;
            }
            R = A - B;
            tbOutput.Text = R.ToString();
            btnInsertA.Enabled = true;
            btnInsertB.Enabled = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                return;
            }
            R = A * B;
            tbOutput.Text = R.ToString();
            btnInsertA.Enabled = true;
            btnInsertB.Enabled = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                return;
            }
            R = A / B;
            tbOutput.Text = R.ToString();
            btnInsertA.Enabled = true;
            btnInsertB.Enabled = true;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (tbAPolynomial.Text == "" || tbBPolynomial.Text == "")
            {
                return;
            }
            R = A % B;
            tbOutput.Text = R.ToString();
            btnInsertA.Enabled = true;
            btnInsertB.Enabled = true;
        }

        private void btnAGetValue_Click(object sender, EventArgs e)
        {
            if (tbAPolynomial.Text == "")
            {
                return;
            }
            if (double.TryParse(tbAInputX.Text, out double x))
            {
                double resInPoint = A.P(x);
                tbOutput.Text = resInPoint.ToString();
                btnInsertA.Enabled = false;
                btnInsertB.Enabled = false;
            }
        }

        private void btnBGetValue_Click(object sender, EventArgs e)
        {
            if (tbBPolynomial.Text == "")
            {
                return;
            }
            if (double.TryParse(tbBInputX.Text, out double x))
            {
                double resInPoint = B.P(x);
                tbOutput.Text = resInPoint.ToString();
                btnInsertA.Enabled = false;
                btnInsertB.Enabled = false;
            }
        }

        private void btnAMultiplyByN_Click(object sender, EventArgs e)
        {
            if (tbAPolynomial.Text == "")
            {
                return;
            }
            if (double.TryParse(tbAInputN.Text, out double n))
            {
                R = A * n;
                tbOutput.Text = R.ToString();
                btnInsertA.Enabled = true;
                btnInsertB.Enabled = true;
            }
        }

        private void btnBMultiplyByN_Click(object sender, EventArgs e)
        {
            if (tbBPolynomial.Text == "")
            {
                return;
            }
            if (double.TryParse(tbBInputN.Text, out double n))
            {
                R = B * n;
                tbOutput.Text = R.ToString();
                btnInsertA.Enabled = true;
                btnInsertB.Enabled = true;
            }
        }

        private void btnAPow_Click(object sender, EventArgs e)
        {
            if (tbAPolynomial.Text == "")
            {
                return;
            }
            if (int.TryParse(tbAPow.Text, out int n) && n >= 0)
            {
                R = new PolynomialWithRoots(A.Pow(n).Coefs);
                tbOutput.Text = R.ToString();
                btnInsertA.Enabled = true;
                btnInsertB.Enabled = true;
            }
        }

        private void btnBPow_Click(object sender, EventArgs e)
        {
            if (tbBPolynomial.Text == "")
            {
                return;
            }
            if (int.TryParse(tbBPow.Text, out int n) && n >= 0)
            {
                R = new PolynomialWithRoots(B.Pow(n).Coefs);
                tbOutput.Text = R.ToString();
                btnInsertA.Enabled = true;
                btnInsertB.Enabled = true;
            }
        }

        private void btnAGetDerivative_Click(object sender, EventArgs e)
        {
            if (tbAPolynomial.Text == "")
            {
                return;
            }
            R = new PolynomialWithRoots(A.GetDerivative().Coefs);
            tbOutput.Text = R.ToString();
            btnInsertA.Enabled = true;
            btnInsertB.Enabled = true;
        }

        private void btnBGetDerivative_Click(object sender, EventArgs e)
        {
            if (tbBPolynomial.Text == "")
            {
                return;
            }
            R = new PolynomialWithRoots(B.GetDerivative().Coefs);
            tbOutput.Text = R.ToString();
            btnInsertA.Enabled = true;
            btnInsertB.Enabled = true;
        }

        private void btnAGetPrimitive_Click(object sender, EventArgs e)
        {
            if (tbAPolynomial.Text == "")
            {
                return;
            }
            R = new PolynomialWithRoots(A.GetPrimitive().Coefs);
            tbOutput.Text = R.ToString();
            btnInsertA.Enabled = true;
            btnInsertB.Enabled = true;
        }

        private void btnBGetPrimitive_Click(object sender, EventArgs e)
        {
            if (tbBPolynomial.Text == "")
            {
                return;
            }
            R = new PolynomialWithRoots(B.GetPrimitive().Coefs);
            tbOutput.Text = R.ToString();
            btnInsertA.Enabled = true;
            btnInsertB.Enabled = true;
        }

        private void bntAGetStationaryPoints_Click(object sender, EventArgs e)
        {
            if (A.N <= 1)
            {
                tbOutput.Text = "Точек экстремума нет";
                btnInsertA.Enabled = false;
                btnInsertB.Enabled = false;
                return;
            }
            List<(double, int)> stationaryPoints = A.FindAllStationaryPoints(-100000, 100000);
            string s = "";
            foreach (var item in stationaryPoints)
            {
                s += $"({item.Item1}; {A.P(item.Item1)}) - точка " + (item.Item2 == -1 ? "минимума" : "максимума") + "\n";
            }
            if (s == "")
            {
                s = "Точек экстремума нет";
            }
            tbOutput.Text = s;
            btnInsertA.Enabled = false;
            btnInsertB.Enabled = false;
        }

        private void bntBGetStationaryPoints_Click(object sender, EventArgs e)
        {
            if (B.N <= 1)
            {
                tbOutput.Text = "Точек экстремума нет";
                btnInsertA.Enabled = false;
                btnInsertB.Enabled = false;
                return;
            }
            List<(double, int)> stationaryPoints = B.FindAllStationaryPoints(-100000, 100000);
            string s = "";
            foreach (var item in stationaryPoints)
            {
                s += $"({item.Item1}; {A.P(item.Item1)}) - точка " + (item.Item2 == -1 ? "минимума" : "максимума") + "\n";
            }
            if (s == "")
            {
                s = "Точек экстремума нет";
            }
            tbOutput.Text = s;
            btnInsertA.Enabled = false;
            btnInsertB.Enabled = false;
        }

        private void btnAGetRoots_Click(object sender, EventArgs e)
        {
            if (tbAPolynomial.Text == "")
            {
                btnInsertA.Enabled = false;
                btnInsertB.Enabled = false;
                return;
            }
            if (double.TryParse(tbARoot.Text, out double y))
            {
                List<double> roots = A.FindAllRootsNewton(-100000, 100000, y);
                string s = "";
                foreach (var item in roots)
                {
                    s += Math.Round(item, 5).ToString() + "\n";
                }
                if (s == "")
                {
                    tbOutput.Text = "Корней нет";
                }
                else
                {
                    tbOutput.Text = s;
                }
                btnInsertA.Enabled = false;
                btnInsertB.Enabled = false;
            }
        }

        private void btnBGetRoots_Click(object sender, EventArgs e)
        {
            if (tbBPolynomial.Text == "")
            {
                btnInsertA.Enabled = false;
                btnInsertB.Enabled = false;
                return;
            }
            if (double.TryParse(tbBRoot.Text, out double y))
            {
                List<double> roots = B.FindAllRootsNewton(-100000, 100000, y);
                string s = "";
                foreach (var item in roots)
                {
                    s += Math.Round(item, 5).ToString() + "\n";
                }
                if (s == "")
                {
                    tbOutput.Text = "Корней нет";
                }
                else
                {
                    tbOutput.Text = s;
                }
                btnInsertA.Enabled = false;
                btnInsertB.Enabled = false;
            }
        }

        private void btnInsertA_Click(object sender, EventArgs e)
        {
            double[] coefs = R.Coefs;
            string s = "";
            for (int i = coefs.Length - 1; i >= 0; i--)
            {
                s += coefs[i].ToString() + " ";
            }
            tbACoefs.Text = s;
        }

        private void btnInsertB_Click(object sender, EventArgs e)
        {
            double[] coefs = R.Coefs;
            string s = "";
            for (int i = coefs.Length - 1; i >= 0; i--)
            {
                s += coefs[i].ToString() + " ";
            }
            tbBCoefs.Text = s;
        }

        private void btnAChartOutout_Click(object sender, EventArgs e)
        {
            ChartOutput f = new ChartOutput(A);
            f.Show();
        }

        private void btnBChartOutout_Click(object sender, EventArgs e)
        {
            ChartOutput f = new ChartOutput(B);
            f.Show();
        }

        private void btnInterpolationExtrapolation_Click(object sender, EventArgs e)
        {
            PredictionForm f = new PredictionForm();
            f.Show();
        }
    }
}