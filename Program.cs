using System;

/* The user creates a square matrix of size n x n; the user chooses n. Then this program will return the sum of the values in a specified sub-matrix.
The user will declare what the top-right and bottom-left corners of the sub-matrix are. */

namespace MatrixSum
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("This will be a square matrix, nxn. What size will this be?  ");
            int dim = Convert.ToInt16(Console.ReadLine());
            int[,] matrix = MkMatrix(dim);
            Console.WriteLine("This is the matrix that you made:");
            ShMatrix(matrix, dim);
            Console.WriteLine("Now input the top left corner of the sub-matrix: ");
            int row1;
            int row2;
            int col1;
            int col2;
            do
            {
                Console.WriteLine("Row");
                row1 = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Column");
                col1 = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Now input the bottom right corner of the sub-matrix: ");
                Console.WriteLine("Row");
                row2 = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Column");
                col2 = Convert.ToInt16(Console.ReadLine());
            } while (!Check(dim, row1, row2, col1, col2));
            Console.WriteLine("This is the sub-matrix that you want to add up:");
            ShSubMatrix(matrix, row1, col1, row2, col2);
            Console.WriteLine("This is the sum:");
            Console.WriteLine(SumRegion(matrix, row1, col1, row2, col2));
            Console.WriteLine("Want to do again?");
            string rep = Console.ReadLine();
            if (rep == "no")
            {
                break;
            }
            }
        }

        //This will make a matrix of the size that the user specified.
        static int[,] MkMatrix(int dim)
        {
            Console.WriteLine("Now input the elements in each row");
            int[,] matrx = new int[dim, dim];
            for (int j = 0; j < dim; j++)
            {
                for (int i = 0; i < dim; i++)
                {
                    int element = Convert.ToInt16(Console.ReadLine());
                    matrx[j,i] = element;
                }
            }
            return matrx;
        }

        //This method shows cleanly the matrix that the user created.
        static void ShMatrix(int[,] m, int size)
        {
            for (int j=0; j<size; j++)
            {
                Console.Write("[");
                for (int i=0; i<size; i++)
                {
                    Console.Write($"{m[j,i]}, ");
                }
                Console.Write("\b\b]\n");
            }
        }

        //This function sums up the indeces of the sub-matrix.
        static int SumRegion(int[,] m, int row1, int col1, int row2, int col2)
        {
            int sum = 0;
            for (int j=row1; j<row2+1; j++)
            {
                for (int i=col1; i<col2+1; i++)
                {
                    sum = sum+m[j,i];
                }
            }
            return sum;
        }

        //This function shows the sub-matrix that the user chose.
        static void ShSubMatrix(int[,] m, int row1, int col1, int row2, int col2)
        {
            for (int j=row1; j<row2+1; j++)
            {
                Console.Write("[");
                for (int i=col1; i<col2+1; i++)
                {
                    Console.Write($"{m[j,i]}, ");
                }
                Console.Write("\b\b]\n");
            }
        }

        //This is just a check to verify that the user inputs are valid.
        //'Id est' the sub-matrix's corners are not out of bounds of the original matrix.
        static bool Check(int d, int r1, int r2, int c1, int c2)
        {
            if (r2<r1)
            {
                Console.WriteLine("Row2 cannot be less than row1.");
                return false;
            }
            else if (c2<c1)
            {
                Console.WriteLine("Col2 cannot be less than col1.");
                return false;
            }
            else if (r2>=d || c2>=d)
            {
                Console.WriteLine("The rows and columns cannot exceed the dimensions of the matrix.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
