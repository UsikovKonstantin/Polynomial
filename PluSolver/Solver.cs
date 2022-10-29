using System;
namespace PluSolver
{
    public class Solver
    {
        private double[,] A;
        private double[] B;
        private PluDecomposer pluDecomposer;
        private XFinder xFinder;

        public Solver(double[,] A, double[] B)
        {
            this.A = A;
            this.B = B;

            pluDecomposer = new PluDecomposer(A);
           
        }

        public double[] SolveX()
        {
            (var p, var lu)=pluDecomposer.FindPAndCombinedLU();
            xFinder = new XFinder(lu, p, B);

            return xFinder.Solve();
        }
        
    }
}
