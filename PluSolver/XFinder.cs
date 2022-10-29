using System;
namespace PluSolver
{
    public class XFinder
    {
        private double[,] lu;
        private double[] b;
        private double[] y;
        private double[] x;
        private readonly int[] p;
         

        private readonly int numberOfRows;
        private readonly int numberOfColumns;

        public XFinder(double[,] lu, int[] p, double[] b)
        {
            this.lu = lu;
            this.p = p;
            this.b = b;

            numberOfRows = lu.GetLength(0);
            numberOfColumns = lu.GetLength(1);

            y = new double[numberOfRows];
            x = new double[numberOfRows];


        }

        private void ReorderB()
        {
            double[] reorderedB = new double[b.Length];

            for (int row = 0; row < numberOfRows; row++)
            {
                reorderedB[row] = b[p[row]];
            }

            for (int row = 0; row < numberOfRows; row++)
            {
                b[row] = reorderedB[row];
            }
        }

        void SolveYfromLYequalB()
        {

            for (int row = 0; row < b.Length; row++)
            {
                double sum = 0;
                var columnOfDiagonal = row;
                for (int column = 0; column < columnOfDiagonal; column++)
                {
                    sum += y[column] * lu[row, column];
                }
                y[row] = b[row] - sum;
            }
        }

        void SolveXfromUXequalY()
        {
            for (int row = y.Length - 1; row > -1; row--)
            {
                double sum = 0;
                var columnOfDiagonal = row;

                for (int column = columnOfDiagonal + 1; column < x.Length; column++)
                {
                    sum += x[column] * lu[row, column];
                }
                x[row] = (y[row] - sum) / lu[row, row];
            }

            
        }

        private void CheckX()
        {
            for (int row = 0; row < x.Length; row++)
            {
                if (double.IsNaN(x[row]))
                {
                    throw new Exception("Error: No solution for this, AX=B, system found.");
                }
            }
        }

        public double[] Solve()
        {
            ReorderB();
            SolveYfromLYequalB();
            SolveXfromUXequalY();
            CheckX();
            return x;
        }


    }
}
