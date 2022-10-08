using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ClassLibraryPolynomial;

namespace WinFormsAppPolynomial
{
    public partial class ChartOutput : Form
    {
        public ChartOutput(double[] x, double[] y)
        {
            InitializeComponent();

            plot.plt.AddScatter(x, y, null, 2, 0);
            plot.Refresh();
        }
    }
}
