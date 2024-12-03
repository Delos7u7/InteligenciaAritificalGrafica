using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using delos.Mathematics;
using InteligenciaArtificalGrafica.delos.Mathematics;

namespace delos.Data
{
    public class MLP
    {
        private Matrix W0, W1, b0, b1;
        private double learningRate;
        private int epochs;

        public MLP(int nInp, int nHid, int nOut, double α, int epoch)
        {
            learningRate = α;
            epochs = epoch;

            Numcs nc = new Numcs();
            W0 = nc.Random(nInp, nHid);
            b0 = nc.Random(nHid, 1);
            W1 = nc.Random(nHid, nOut);
            b1 = nc.Random(nOut, 1);
        }

        public void Fit(Matrix inputs, Matrix outputs)
        {
            for (int i = 0; i < epochs; i++)
            {
                for (int j = 0; j < inputs.nRows; j++)
                {
                    Matrix X = new Matrix(inputs.GetRow(j));
                    Matrix Y = new Matrix(outputs.GetRow(j));
                    Matrix Z0 = X.dot(W0) + b0.T;
                    Matrix A0 = Sigm(Z0);
                    Matrix Z1 = A0.dot(W1) + b1.T;
                    Matrix A1 = Sigm(Z1);

                    Matrix δ1 = (Y - A1) * A1 * (1.0 - A1);
                    Matrix ΔW1 = learningRate * (δ1.T.dot(A0));
                    Matrix Δb1 = learningRate * δ1;
                    Matrix δ0 = δ1.dot(W1.T) * A0 * (-1) * (A0 - 1);
                    Matrix ΔW0 = learningRate * (δ0.T.dot(X));
                    Matrix Δb0 = learningRate * δ0;

                    W0 = W0 + ΔW0.T;
                    b0 = b0 + Δb0.T;
                    W1 = W1 + ΔW1.T;
                    b1 = b1 + Δb1.T;
                }
            }
        }

        public Matrix Predict(Vector input)
        {
            Matrix X = new Matrix(input);
            Matrix Z0 = X.dot(W0) + b0.T;
            Matrix A0 = Sigm(Z0);
            Matrix Z1 = A0.dot(W1) + b1.T;
            return Sigm(Z1);
        }

        private Matrix Sigm(Matrix matrix)
        {
            Vector data = matrix.GetRow(0);
            Vector sigm = 1 / (1 + ((Math.E) ^ (data * -1.0)));
            Matrix m = new Matrix(sigm);
            return m;
        }
    }
}