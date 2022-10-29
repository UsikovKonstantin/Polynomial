using System;
namespace PluSolver
{
    public class PluDecomposer
    {

        private double[,] A;
        private int[] P;

        private SubMatrixBoundariess LowerTriangleBounds;
        private int numberOfColumns;
        private int numberOfRows;

        


        public PluDecomposer(double[,] A)
        {
            this.A = A;

            numberOfRows = A.GetLength(0);
            numberOfColumns = A.GetLength(1);

            InitializePWithRowNumbers();

            LowerTriangleBounds = new SubMatrixBoundariess()
            {
                StartColumn = 0,
                EndColumn = A.GetLength(1) - 1,
                StartRow = 1,
                EndRow = A.GetLength(0)

            };
        }

        private void InitializePWithRowNumbers()
        {
            P = new int[numberOfRows];
            for (int row = 0; row < numberOfRows; row++)
            {
                P[row] = row;
            }
        }

        public (int[], double[,]) FindPAndCombinedLU()
        {
            ConvertAtoLU();
            return (P, A);
        }

        private void ConvertAtoLU()
        {
            MakeLowerTriangleZeroAndFillWithL();
        }

        private void MakeLowerTriangleZeroAndFillWithL()
        {
            for (int column = LowerTriangleBounds.StartColumn; column < LowerTriangleBounds.EndColumn; column++)
            {
                MakeSureDiagonalElementIsMaximum(column);
                MakeColumnZero(column);
            }
        }

        private void MakeSureDiagonalElementIsMaximum(int focusedColumn)
        {

            var rowOfDiagonal = focusedColumn;
            var rowOfMaxElement = GetRowOfMaxElementUnderDiagonal(focusedColumn);

            if (rowOfMaxElement != rowOfDiagonal)
            {
                SwapRows(rowOfMaxElement, rowOfDiagonal);

            };

        }

        private int GetRowOfMaxElementUnderDiagonal(int focusedColumn)
        {
            var rowOfDiagonal = focusedColumn;
            var columnOfDiagonal = focusedColumn;
            var rowAfterDiagonal = rowOfDiagonal + 1;


            double maxElement = A[rowOfDiagonal, columnOfDiagonal];
            int rowOfMaxElement = rowOfDiagonal;


            for (int row = rowAfterDiagonal; row < numberOfRows; row++)
            {
                if (Math.Abs(A[row, focusedColumn]) > maxElement)
                {
                    maxElement = Math.Abs(A[row, focusedColumn]);
                    rowOfMaxElement = row;
                }
            }
            return rowOfMaxElement;
        }

        private void SwapRows(int row1, int row2)
        {
            for (int column = 0; column < numberOfColumns; column++)
            {
                var tmp = A[row1, column];
                A[row1, column] = A[row2, column];
                A[row2, column] = tmp;
            }
            RecordSwap(row1, row2);
        }

        private void RecordSwap(int row1, int row2)
        {
            var tmp = P[row1];
            P[row1] = P[row2];
            P[row2] = tmp;
        }

        private void MakeColumnZero(int column)
        {
            int rowUnderDiagonalElement = column + 1;
            for (int row = rowUnderDiagonalElement; row < LowerTriangleBounds.EndRow; row++)
            {
                MakeElementZeroAndFillWithLowerMatrixElement(row, column);
            }
        }

        private void MakeElementZeroAndFillWithLowerMatrixElement(int elementRow, int elementColumn)
        {
            var element = A[elementRow, elementColumn];
            var sameColumnDiagonalElement = A[elementColumn, elementColumn];

            var rowMultiplier = -element / sameColumnDiagonalElement;

            for (int col = elementColumn; col < numberOfColumns; col++)
            {
                A[elementRow, col] += rowMultiplier * A[elementColumn, col];
            }

            var lowerMatrixElement = -rowMultiplier;
            A[elementRow, elementColumn] = lowerMatrixElement;
        }


    }
}
