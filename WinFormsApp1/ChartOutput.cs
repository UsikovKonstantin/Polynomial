using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ClassLibraryPolynomial;

namespace WinFormsAppPolynomial
{
    public partial class ChartOutput : Form
    {
        public ChartOutput(PolynomialWithRoots polynomial)
        {
            InitializeComponent();

            int n = Math.Max(100, 10000 / ((int)Math.Pow(10, polynomial.N / 10)));
            if (polynomial.N > 40)
            {
                n = 10;
            }
            if (polynomial.N > 85)
            {
                n = 0;
            }
            double[] x = new double[2 * n + 1];
            double[] y = new double[2 * n + 1];
            int ind = 0;
            for (int i = -n; i <= n; i++)
            {
                x[ind] = i;
                y[ind] = polynomial.P(i);
                ind++;
            }
            plot.plt.AddScatter(x, y, null, 2, 0);
            plot.Refresh();
        }
    }
}
