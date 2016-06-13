namespace Matrix
{
    using System;

    class Test
    {
        static void Main()
        {
            int row = 4;
            int col = 5;
            var matrix1 = new Matrix<int>(row, col);
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    matrix1[r, c] = r + c+2;
                }
            }

            row = 5;
            col = 3;
            var matrix2 = new Matrix<int>(row, col);
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    matrix2[r, c] = r + c;
                }
            }

            Console.WriteLine(matrix1);
            Console.WriteLine(matrix2);           
            Console.WriteLine(matrix1 * matrix2);

            row = 3;
            col = 3;
            var matrix3 = new Matrix<int>(row, col);
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    matrix3[r, c] = r + c + 2;
                }
            }

            row = 3;
            col = 3;
            var matrix4 = new Matrix<int>(row, col);
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    matrix4[r, c] = r + c;
                }
            }

            Console.WriteLine(matrix3);
            Console.WriteLine(matrix4);
            Console.WriteLine(matrix3 + matrix4);

        }
    }
}
