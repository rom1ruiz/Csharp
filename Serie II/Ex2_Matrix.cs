using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Matrix
    {
        public static int[][] BuildingMatrix(int[] leftVector, int[] rightVector)
        {

            int[][] matrix =
            {
                leftVector,
                rightVector
            };
            return matrix;

        }

        public static int[][] Addition(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] addition = new int[leftMatrix.Length][];
            for (int i = 0; i < addition.Length; i++)
            {
                addition[i] = new int[leftMatrix[i].Length];

                for (int j = 0; j < addition[i].Length; j++)
                {
                    addition[i][j] = leftMatrix[i][j] + rightMatrix[i][j];
                }
            }
            return addition;

        }

        public static int[][] Substraction(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] soustraction = new int[leftMatrix.Length][];
            for (int i = 0; i < soustraction.Length; i++)
            {
                soustraction[i] = new int[leftMatrix[i].Length];

                for (int j = 0; j < soustraction[i].Length; j++)
                {
                    soustraction[i][j] = leftMatrix[i][j] - rightMatrix[i][j];
                }
            }
            return soustraction;
        }

        public static int[][] Multiplication(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] multiplication = new int[leftMatrix.Length][];
            if (leftMatrix[0].Length == rightMatrix.Length)
            {
                for (int i = 0; i < multiplication.Length; i++)
                {
                    multiplication[i] = new int[leftMatrix[i].Length];

                    for (int j = 0; j < multiplication[i].Length; j++)
                    {
                        for (int k = 0; k < leftMatrix[0].Length; k++)
                        {
                            multiplication[i][j] =+ leftMatrix[i][k] * leftMatrix[i][k];

                        }
                    }
                }

            }
            return multiplication;

        }

        public static void DisplayMatrix(int[][] matrix)
        {
            string s = string.Empty;
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[i].Length; ++j)
                {
                    s += matrix[i][j].ToString().PadLeft(5) + " ";
                }
                s += Environment.NewLine;
            }
            Console.WriteLine(s);
        }
    }
}
