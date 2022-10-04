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
            if (double.TryParse(tbLagrangeX.Text, out double x))
            {
                PolynomialPrediction polynomial = new PolynomialPrediction(points.ToArray());

                double xMin = double.MaxValue;
                double xMax = double.MinValue;
                foreach (var item in points)
                {
                    if (item.X < xMin)
                    {
                        xMin = item.X;
                    }
                    if (item.X > xMax)
                    {
                        xMax = item.X;
                    }
                }

                int n = Math.Min(10, 10000 / ((int)Math.Pow(10, polynomial.N / 10)));
                if (polynomial.N > 40)
                {
                    n = 10;
                }
                if (polynomial.N > 85)
                {
                    n = 0;
                }
                //double[] X = new double[2 * n + 1];
                //double[] Y = new double[2 * n + 1];
                List<double> X = new List<double>();
                List<double> Y = new List<double>();
                int ind = 0;
                double i = xMin - 10;
                double step = (xMax - xMin + 20) / 1000;
                while (i <= xMax + 10)
                {
                    X.Add(i);
                    Y.Add(polynomial.P(i));
                    i += step;
                }
                //for (int i = -n; i <= n; i++)
                //{
                //    X[ind] = i;
                //    Y[ind] = polynomial.P(i);
                //    ind++;
                //}
                //plot.plt.AddScatter(X, Y, Color.Black, 2, 0);
                //plot.plt.Clear();
                charts.Add(plot.plt.PlotScatter(X.ToArray(), Y.ToArray(), Color.Black, 2, 0));
                redPoints.Add(plot.plt.AddPoint(x, polynomial.P(x), Color.Red, 10));
                plot.Refresh();
                tbLagrangeY.Text = polynomial.P(x).ToString();
            }
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tbSquareX.Text, out double x) && int.TryParse(tbSquareN.Text, out int N))
            {
                PolynomialPrediction polynomial = new PolynomialPrediction(N, points.ToArray());

                double xMin = double.MaxValue;
                double xMax = double.MinValue;
                foreach (var item in points)
                {
                    if (item.X < xMin)
                    {
                        xMin = item.X;
                    }
                    if (item.X > xMax)
                    {
                        xMax = item.X;
                    }
                }

                int n = Math.Min(10, 10000 / ((int)Math.Pow(10, polynomial.N / 10)));
                if (polynomial.N > 40)
                {
                    n = 10;
                }
                if (polynomial.N > 85)
                {
                    n = 0;
                }
                //double[] X = new double[2 * n + 1];
                //double[] Y = new double[2 * n + 1];
                List<double> X = new List<double>();
                List<double> Y = new List<double>();
                int ind = 0;
                double i = xMin - 10;
                double step = (xMax - xMin + 20) / 1000;
                while (i <= xMax + 10)
                {
                    X.Add(i);
                    Y.Add(polynomial.P(i));
                    i += step;
                }
                //for (int i = -n; i <= n; i++)
                //{
                //    X[ind] = i;
                //    Y[ind] = polynomial.P(i);
                //    ind++;
                //}
                //plot.plt.AddScatter(X, Y, Color.Black, 2, 0);
                //plot.plt.Clear();
                charts.Add(plot.plt.PlotScatter(X.ToArray(), Y.ToArray(), Color.Black, 2, 0));
                redPoints.Add(plot.plt.AddPoint(x, polynomial.P(x), Color.Red, 10));
                plot.Refresh();
                tbSquareY.Text = polynomial.P(x).ToString();
            }
        }
 
    }
}
