using System;

namespace Classification
{/// <summary> 
 /// Нейрон: 2 входящих веса, выход 2 предыдущих нейронов, собственный вход/выход, собственная дельта, градиенты 2 входящих синапсов, дельты 2 входящих весов, ошибка, альфа, eps, идеальный выход. 
 /// Все для расчета данных параметров 
 /// </summary> 
	class Neuron
	{
		public static int layerinput, layerhidden, layeroutput;
		public Neuron()
		{
			w = new double[layerinput];
			dw = new double[layerinput];
			p = new double[layerinput];
			grad = new double[layerinput];

		}
		/// <summary>
		/// Нейрон выходного слоя.
		/// </summary>
		/// <param name="ideal">Ideal.</param>
		public Neuron(double ideal)
		{
			outideal = ideal;
			w = new double[layerhidden];
			dw = new double[layerhidden];
			p = new double[layerhidden];
			grad = new double[layerhidden];
		}
		public double[] w, dw, grad;
		public double[] p;
		public double
		input, output,
		error, outideal = -1, delta;
		public static double alpha = 0.1234, eps = 0.1;
		private void CalcInput()
		{
			input = 0;
			for (int i = 0; i < w.Length; i++)
			{
				input += w[i] * p[i];
			}
		}
		private void CalcOutput()
		{
			output = 1 / (1 + Math.Exp(-input));
		}
		public void CalcDeltaOut()
		{
			delta = (outideal - output) * (1 - output) * output;
		}
		public void CalcDelta(Neuron[] next, int num)
		{
			delta = 0;
			for (int i = 0; i < layeroutput; i++)
			{
				delta += next[i].w[num] * next[i].delta;
			}
			delta *= (1 - output) * output;
		}
		private void CalcGradient()
		{
			for (int i = 0; i < p.Length; i++)
			{
				grad[i] = p[i] * delta;
			}
		}
		private void CalcDeltaWeight()
		{
			for (int i = 0; i < w.Length; i++)
			{
				dw[i] = eps * grad[i] + alpha * dw[i];
				w[i] += dw[i];
			}
		}
		public void CalcIO()
		{
			CalcInput();
			CalcOutput();
		}

		public void ChangeWeight()
		{
			CalcGradient();
			CalcDeltaWeight();
		}
		public void CalcError()
		{
			error = Math.Pow(outideal - output, 2);
		}
		public void Randomize(Random rnd)
		{
			for (int i = 0; i < layerinput; i++)
			{
				w[i] = rnd.Next(-3, 3) * (rnd.NextDouble() + 1);
			}
		}
	}
}