using System;

namespace NeuralMatrix
{
	class Program
	{
		static void Main(string[] args)
		{
			Matrix a1 = new Matrix(3, 3);
			Matrix b1 = new Matrix(3, 1);
			Matrix.PrintMatrix(a1.matrix);
			Console.WriteLine();
			Matrix.PrintMatrix(b1.matrix);
			Console.WriteLine();
			double[,] res;
			res = Matrix.Multiply(a1.matrix, b1.matrix);
			Matrix.PrintMatrix(res);
		}
	}
}
