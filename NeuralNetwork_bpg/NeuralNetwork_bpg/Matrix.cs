﻿using System;

namespace NeuralNetwork_bpg
{
	class Matrix
	{
		public double[,] matrix;
		int N, M;
		public Matrix(int n, int m)
		{
			matrix = new double[n, m];
			N = n;
			M = m;
		}
		public Matrix(int n, int m, int i)
		{
			matrix = new double[n, m];
			N = n;
			M = m;
			Randomize();
		}
		public Matrix(int n)
		{
			matrix = new double[n, 1];
			N = n;
			M = 1;
		}
		void Randomize()
		{
			Random rnd = new Random();
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					matrix[i, j] = rnd.Next(5);
				}
			}
		}
		public static double[,] Multiply(double[,] a, double[,] b)
		{
			double[,] res = new double[a.GetLength(0), b.GetLength(1)];
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < b.GetLength(1); j++)
				{
					for (int k = 0; k < a.GetLength(1); k++)
					{
						res[i, j] += a[i, k] * b[k, j];
					}
				}
			}
			return res;
		}
		public static double[,] Transponir(double[,] a)
		{
			double[,] res = new double[a.GetLength(1), a.GetLength(0)];
			for (int i = 0; i < res.GetLength(0); i++)
			{
				for (int j = 0; j < res.GetLength(1); j++)
				{
					res[i, j] = a[j, i];
				}
			}
			return res;
		}
		public static double[,] Add(double [,] a, double [,] b)
		{
			double[,] res = new double[a.GetLength(0), a.GetLength(1)];
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < a.GetLength(1); j++)
				{
					res[i, j] = a[i, j] + b[i, j];
				}
			}
			return res;
		}
		public static void PrintMatrix(Matrix a)
		{
			for (int i = 0; i < a.matrix.GetLength(0); i++)
			{
				for (int j = 0; j < a.matrix.GetLength(1); j++)
				{
					Console.Write("{0:F5}\t", a.matrix[i, j]);
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}
