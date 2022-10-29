using ClassLibraryPolynomial;
using ScottPlot;
using ScottPlot.Plottable;
using Point = ClassLibraryPolynomial.Point;

namespace WinFormsAppPolynomial
{
    public partial class PredictionForm : Form
    {
        public PredictionForm()
        {
            InitializeComponent();
        }

        List<Point> points = new List<Point>();
        List<IPlottable> charts = new List<IPlottable>();
        List<IPlottable> redPoints = new List<IPlottable>();
        List<IPlottable> bluePoints = new List<IPlottable>();

        private void tbInputX_TextChanged(object sender, EventArgs e)
        {
            string s = tbInputX.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epInputX.SetError(tbInputX, "Невозможно привести к числу.");
                tbInputX.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epInputX.Clear();
                tbInputX.Margin = new Padding(3, 3, 3, 3);
            }
        }

        private void tbInputY_TextChanged(object sender, EventArgs e)
        {
            string s = tbInputY.Text.Trim();
            if (s != "" && !double.TryParse(s, out double _))
            {
                epInputY.SetError(tbInputY, "Невозможно привести к числу.");
                tbInputY.Margin = new Padding(3, 3, 20, 3);
            }
            else
            {
                epInputY.Clear();
                tbInputY.Margin = new Padding(3, 3, 3, 3);
            }
        }

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

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tbInputX.Text, out double x) && double.TryParse(tbInputY.Text, out double y))
            {
                bluePoints.Add(plot.plt.AddPoint(x, y, Color.Blue, 10));
                plot.Refresh();
                foreach (var item in points)
                {
                    if (item.X == x && item.Y == y)
                    {
                        return;
                    }
                }
                points.Add(new Point(x, y));
                tbInputX.Text = "";
                tbInputY.Text = "";
                tbInputX.Focus();
            }
            else
            {
                tbOutput.Text = "Введенные координаты невозможно привести к числу.";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (charts.Count != 0)
            {
                plot.plt.Remove(charts[charts.Count - 1]);
                charts.Remove(charts[charts.Count - 1]);
                plot.plt.Remove(redPoints[redPoints.Count - 1]);
                redPoints.Remove(redPoints[redPoints.Count - 1]);
                plot.Refresh();
                return;
            }
            if (bluePoints.Count != 0)
            {
                plot.plt.Remove(bluePoints[bluePoints.Count - 1]);
                bluePoints.Remove(bluePoints[bluePoints.Count - 1]);
                points.RemoveAt(points.Count - 1);
                plot.Refresh();
            }
        }

        private void btnLagrange_Click(object sender, EventArgs e)
        {
            if (points.Count == 0)
            {
                tbOutput.Text = "Нет точек.";
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
                        tbOutput.Text = "Не удалось вычислить полином Лагранжа.";
                        return;
                    }
                    Y.Add(y);
                    i += step;
                }

                if (charts.Count != 0)
                {
                    plot.plt.Remove(charts[charts.Count - 1]);
                    charts.Remove(charts[charts.Count - 1]);
                    plot.plt.Remove(redPoints[redPoints.Count - 1]);
                    redPoints.Remove(redPoints[redPoints.Count - 1]);
                    plot.Refresh();
                }

                charts.Add(plot.plt.PlotScatter(X.ToArray(), Y.ToArray(), Color.Black, 2, 0));
                redPoints.Add(plot.plt.AddPoint(x, polynomial.P(x), Color.Red, 10));
                plot.Refresh();
                tbLagrangeY.Text = polynomial.P(x).ToString();
                tbOutput.Text = "Полученный полином:\n" + polynomial.ToString() + "\n";
                tbOutput.Text += "Среднеквадратичное отклонение:\n" + polynomial.GetDelta(points.ToArray()).ToString();
            }
            else
            {
                tbOutput.Text = "Введенные координаты невозможно привести к числу.";
            }
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            if (points.Count == 0)
            {
                tbOutput.Text = "Нет точек.";
                return;
            }
            if (double.TryParse(tbSquareX.Text, out double x) && int.TryParse(tbSquareN.Text, out int N))
            {
                if (points.Count <= N)
                {
                    tbOutput.Text = "Количество точек должно быть больше степени полинома.";
                    return;
                }
                if (N <= 0)
                {
                    tbOutput.Text = "Степень полинома должна быть больше нуля.";
                    return;
                }

                PolynomialPrediction polynomial;
                try
                {
                    polynomial = new PolynomialPrediction(N, points.ToArray());
                }
                catch (Exception)
                {
                    tbOutput.Text = "Не удалось вычислить полином методом наименьших квадратов.";
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
                    Y.Add(polynomial.P(i));
                    i += step;
                }

                if (charts.Count != 0)
                {
                    plot.plt.Remove(charts[charts.Count - 1]);
                    charts.Remove(charts[charts.Count - 1]);
                    plot.plt.Remove(redPoints[redPoints.Count - 1]);
                    redPoints.Remove(redPoints[redPoints.Count - 1]);
                    plot.Refresh();
                }

                charts.Add(plot.plt.PlotScatter(X.ToArray(), Y.ToArray(), Color.Black, 2, 0));
                redPoints.Add(plot.plt.AddPoint(x, polynomial.P(x), Color.Red, 10));
                plot.Refresh();
                tbSquareY.Text = polynomial.P(x).ToString();
                tbOutput.Text = "Полученный полином:\n" + polynomial.ToString() + "\n";
                tbOutput.Text += "Среднеквадратичное отклонение:\n" + polynomial.GetDelta(points.ToArray()).ToString();
            }
            else
            {
                tbOutput.Text = "X или N невозможно привести к числу.";
            }
        }

        private void tbInputX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (tbInputX.Focused)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    tbInputY.Focus();
                }
                else if (tbInputY.Focused)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    tbInputX.Focus();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                btnAddPoint_Click(sender, e);
            }
        }

        private void tbInputY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (tbInputX.Focused)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    tbInputY.Focus();
                }
                else if (tbInputY.Focused)
                {
                    e.Handled = e.SuppressKeyPress = true;
                    tbInputX.Focus();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                btnAddPoint_Click(sender, e);
            }
        }

        private void plot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                (double x, double y) = plot.GetMouseCoordinates();
                bluePoints.Add(plot.plt.AddPoint(x, y, Color.Blue, 10));
                plot.Refresh();
                foreach (var item in points)
                {
                    if (item.X == x && item.Y == y)
                    {
                        return;
                    }
                }
                points.Add(new Point(x, y));
            }
        }
    }
}