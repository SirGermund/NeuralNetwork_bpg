using System;

namespace NeuralNetwork_bpg
{
	class MainClass
	{
		static void Main()
		{
			Neuron.layerinput = 2;
			Neuron.layerhidden = 6;
			Neuron.layeroutput = 1;
			Random rnd = new Random();

			Matrix x = new Matrix(Neuron.layerinput);
			Matrix h = new Matrix(Neuron.layerhidden);
			Matrix y = new Matrix(Neuron.layeroutput);
			Matrix wxh = new Matrix(Neuron.layerhidden, Neuron.layerinput,1);
			Matrix why = new Matrix(Neuron.layeroutput, Neuron.layerhidden,1);
			Matrix ideal = new Matrix(Neuron.layeroutput);

			Matrix dh = new Matrix(Neuron.layerhidden);
			Matrix dy = new Matrix(Neuron.layeroutput);
			Matrix dwxh = new Matrix(Neuron.layerhidden, Neuron.layerinput);
			Matrix dwhy = new Matrix(Neuron.layeroutput, Neuron.layerhidden);
			Matrix gxh = new Matrix(Neuron.layerhidden, Neuron.layerinput);
			Matrix ghy = new Matrix(Neuron.layeroutput, Neuron.layerhidden);

			for (int epoha = 0; epoha < 100; epoha++)
			{
				for (int a = 0; a < 2; a++)
				{
					for (int b = 0; b < 2; b++)
					{
						GoForward(ref a, ref b, ref x, ref h, ref y, ref wxh, ref why);
						ideal.matrix[0, 0] = Bool2Int(a, b);
						dy.matrix = Neuron.DeltaOut(ref y.matrix, ref ideal.matrix);
						ghy.matrix = Matrix.Transponir(Matrix.Multiply(h.matrix, y.matrix));
						dwhy.matrix = Neuron.DeltaWeight(ref ghy.matrix, ref dwhy.matrix);
						why.matrix = Matrix.Add(why.matrix, dwhy.matrix);
						Matrix.PrintMatrix(why);

						dh.matrix = Neuron.DeltaHidden(ref h.matrix, ref why.matrix, ref dy.matrix);
						gxh.matrix = Matrix.Multiply(h.matrix, Matrix.Transponir(x.matrix));
						dwxh.matrix = Neuron.DeltaWeight(ref gxh.matrix, ref dwxh.matrix);
						wxh.matrix = Matrix.Add(wxh.matrix, dwxh.matrix);
						Matrix.PrintMatrix(wxh);
					}
				}
			}
			//Neuron[] H = new Neuron[Neuron.layerhidden];
			//for (int i = 0; i < Neuron.layerhidden; i++)
			//{
			//	H[i] = new Neuron();
			//	H[i].Randomize(rnd);
			//}

			//Neuron[] Y = new Neuron[Neuron.layeroutput];
			//for (int i = 0; i < Neuron.layeroutput; i++)
			//{
			//	Y[i] = new Neuron(1);
			//	Y[i].Randomize(rnd);
			//}

			//for (int epoha = 0; epoha < 10000; epoha++)
			//{
			//	for (int a = 0; a < 2; a++)
			//	{
			//		for (int b = 0; b < 2; b++)
			//		{
			//			Y[0].outideal = Bool2Int(a, b);
			//			for (int i = 0; i < Neuron.layerhidden; i++)
			//			{
			//				H[i].p[0] = a;
			//				H[i].p[1] = b;
			//				H[i].CalcIO();
			//			}
			//			for (int i = 0; i < Neuron.layeroutput; i++)
			//			{
			//				Y[i].p[0] = H[i].output;
			//				Y[i].p[1] = H[i].output;
			//				Y[i].p[2] = H[i].output;
			//				Y[i].CalcIO();
			//				Y[i].CalcDeltaOut();
			//				Y[i].ChangeWeight();
			//			}
			//			for (int i = 0; i < Neuron.layerhidden; i++)
			//			{
			//				H[i].CalcDelta(Y, i);
			//				H[i].ChangeWeight();
			//			}
			//		}
			//	}
			//	for (int a = 0; a < 2; a++)
			//	{
			//		for (int b = 0; b < 2; b++)
			//		{
			//			Y[0].outideal = Bool2Int(a, b);
			//			for (int i = 0; i < Neuron.layerhidden; i++)
			//			{
			//				H[i].p[0] = a;
			//				H[i].p[1] = b;
			//				H[i].CalcIO();
			//			}
			//			for (int i = 0; i < Neuron.layeroutput; i++)
			//			{
			//				Y[i].p[0] = H[i].output;
			//				Y[i].p[1] = H[i].output;
			//				Y[i].p[2] = H[i].output;
			//				Y[i].CalcIO();
			//				Y[i].CalcError();
			//			}
			//			Console.WriteLine("a={0}\tb={1}\tideal={4}\tansw={2:F5}\terr={3:F5}", a, b, Y[0].output, Y[0].error, Y[0].outideal);
			//		}
			//	}
			//}
		}
		static void GoForward(ref int a, ref int b, ref Matrix x, ref Matrix h, ref Matrix y, ref Matrix wxh, ref Matrix why)
		{
			x.matrix[0, 0] = a;
			x.matrix[1, 0] = b;
			h.matrix = Matrix.Multiply(wxh.matrix, x.matrix);
			Neuron.Sigmoid(ref h.matrix);
			y.matrix = Matrix.Multiply(why.matrix, h.matrix);
			Neuron.Sigmoid(ref y.matrix);
			Console.Write("{0} & {1} = {2}\t",a,b, Bool2Int(a, b));
			Matrix.PrintMatrix(y);
		}
		static void GoBackward(ref int a, ref int b, ref Matrix x, ref Matrix h, ref Matrix y, ref Matrix wxh, ref Matrix why)
		{

		}
		static int Bool2Int(int a, int b)
		{
			bool abool, bbool, res;
			if (a == 1) abool = true;
			else abool = false;
			if (b == 1) bbool = true;
			else bbool = false;
			res = abool & bbool;
			if (res) return 1;
			else return 0;
		}
	}
}
