using ClassLibraryPolynomial;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            tbACoefs.Text = "1 2 3";
            tbBCoefs.Text = "4 5 6";
        }

        PolynomialPrediction A = new PolynomialPrediction();
        PolynomialPrediction B = new PolynomialPrediction();
        PolynomialPrediction R = new PolynomialPrediction();
        List<(double, int)> stationaryPoints = new List<(double, int)>();
        List<double> roots = new List<double>();
        double resInPoint;

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
                    epACoefs.SetError(tbACoefs, "Ќевозможно привести все значени€ к целому числу");
                    tbACoefs.Margin = new Padding(3, 3, 20, 3);
                    tbAPolynomial.Text = "";
                    return;
                }
            }
            epACoefs.Clear();
            tbACoefs.Margin = new Padding(3, 3, 3, 3);
            A = new PolynomialPrediction(coefs);
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
                    epBCoefs.SetError(tbBCoefs, "Ќевозможно привести все значени€ к целому числу");
                    tbBCoefs.Margin = new Padding(3, 3, 20, 3);
                    tbBPolynomial.Text = "";
                    return;
                }
            }
            epBCoefs.Clear();
            tbBCoefs.Margin = new Padding(3, 3, 3, 3);
            B = new PolynomialPrediction(coefs);
            tbBPolynomial.Text = B.ToString();
        }

        private void tbAInputX_TextChanged(object sender, EventArgs e)
        {
            string s = tbAInputX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double x))
            {
                epAInputX.SetError(tbAInputX, "Ќевозможно привести к целому числу");
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
                epBInputX.SetError(tbBInputX, "Ќевозможно привести к целому числу");
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
                epAInputN.SetError(tbAInputN, "Ќевозможно привести к целому числу");
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
                epBInputN.SetError(tbBInputN, "Ќевозможно привести к целому числу");
                tbBInputN.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epBInputN.Clear();
                tbBInputN.Margin = new Padding(3, 3, 3, 3);
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
            R = A + B;
            tbOutput.Text = R.ToString();
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            R = A - B;
            tbOutput.Text = R.ToString();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            R = A * B;
            tbOutput.Text = R.ToString();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            R = A / B;
            tbOutput.Text = R.ToString();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            R = A % B;
            tbOutput.Text = R.ToString();
        }

        private void btnAGetValue_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tbAInputX.Text, out double x))
            {
                resInPoint = A.P(x);
                tbOutput.Text = resInPoint.ToString();
            }
        }

        private void btnBGetValue_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tbBInputX.Text, out double x))
            {
                resInPoint = B.P(x);
                tbOutput.Text = resInPoint.ToString();
            }
        }

        private void btnAMultiplyByN_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tbAInputN.Text, out double n))
            {
                R = A * n;
                tbOutput.Text = R.ToString();
            }
        }

        private void btnBMultiplyByN_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tbBInputN.Text, out double n))
            {
                R = B * n;
                tbOutput.Text = R.ToString();
            }
        }

        private void btnAGetDerivative_Click(object sender, EventArgs e)
        {
            R = new PolynomialPrediction(A.GetDerivative().Coefs);
            tbOutput.Text = R.ToString();
        }

        private void btnBGetDerivative_Click(object sender, EventArgs e)
        {
            R = new PolynomialPrediction(B.GetDerivative().Coefs);
            tbOutput.Text = R.ToString();
        }

        private void btnAGetPrimitive_Click(object sender, EventArgs e)
        {
            R = new PolynomialPrediction(A.GetPrimitive().Coefs);
            tbOutput.Text = R.ToString();
        }

        private void btnBGetPrimitive_Click(object sender, EventArgs e)
        {
            R = new PolynomialPrediction(B.GetPrimitive().Coefs);
            tbOutput.Text = R.ToString();
        }

        private void bntAGetStationaryPoints_Click(object sender, EventArgs e)
        {
            stationaryPoints = A.FindAllStationaryPoints(-100000, 100000);
            string s = "";
            foreach (var item in stationaryPoints)
            {
                s += $"({item.Item1}; {A.P(item.Item1)}) - точка " + (item.Item2 == -1 ? "минимума" : "максимума") + "\n";
            }
            tbOutput.Text = s;
        }

        private void bntBGetStationaryPoints_Click(object sender, EventArgs e)
        {
            stationaryPoints = B.FindAllStationaryPoints(-100000, 100000);
            string s = "";
            foreach (var item in stationaryPoints)
            {
                s += $"({item.Item1}; {A.P(item.Item1)}) - точка " + (item.Item2 == -1 ? "минимума" : "максимума") + "\n";
            }
            tbOutput.Text = s;
        }

        private void btnAGetRoots_Click(object sender, EventArgs e)
        {
            roots = A.FindAllRoots(-100000, 100000);
            string s = "";
            foreach (var item in roots)
            {
                s += item.ToString() + "\n";
            }
            if (s == "")
            {
                tbOutput.Text = " орней нет";
            }
            else
            {
                tbOutput.Text = s;
            }
        }

        private void btnBGetRoots_Click(object sender, EventArgs e)
        {
            roots = B.FindAllRoots(-100000, 100000);
            string s = "";
            foreach (var item in roots)
            {
                s += item.ToString() + "\n";
            }
            if (s == "")
            {
                tbOutput.Text = " орней нет";
            }
            else
            {
                tbOutput.Text = s;
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
    }
}