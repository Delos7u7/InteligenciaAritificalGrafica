using InteligenciaArtificalGrafica.delos.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delos.Mathematics
{
    public class Numcs
    {

        static int seed;
        static Random rnd;

        public Numcs() 
        { 
            seed = (int)System.DateTime.Now.Ticks;
            rnd = new Random(seed);
        }

        public Vector linspace(double start, double end, int div)
        {
            double[] vector = new double[div];
            Vector vectorok = new Vector(vector);
            double interval = (end - start) / (div * 1.0);
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = start + i * interval;
                if (i == vector.Length - 1)
                {
                    vector[i] = end;
                }
            }
            return vectorok;
        }

        public Vector Ones(int n) 
        {
            double[] values = new double[n];
            for (int i = 0; i < n; i++) 
            {
                values[i] = 1.0;
            }

            Vector r = new Vector(values);

            return r;
        }

        public Matrix Zeros(int nRows, int nCols)
        {
            Vector[] rows = new Vector[nRows];
            for (int i = 0; i < nRows; i++)
            {
                double[] values = new double[nCols];
                for (global::System.Int32 j = 0; j < nCols; j++)
                {
                    values[j] = 0;
                }
                Vector row = new Vector(values);
                rows[i] = row;
            }
            Matrix m = new Matrix(rows);
            return m;
        }

        public Matrix Random(int nRows, int nCols)
        {
            Vector[] rows = new Vector[nRows];
            for (int i = 0; i < nRows; i++)
            {
                double[] values = new double[nCols];
                for (global::System.Int32 j = 0; j < nCols; j++)
                {
                    values[j] = rnd.NextDouble() * 2 - 1;
                }
                Vector row = new Vector(values);
                rows[i] = row;
            }
            Matrix m = new Matrix(rows);
            return m;
        }
        public Matrix Identity(int nRows, int nCols)
        {
            Matrix R = Zeros(nRows, nCols);
            for (int i = 0; i < nRows; i++)
            {
                for (global::System.Int32 j = 0; j < nCols; j++)
                {
                    if (i == j)
                    {
                        R[i,i] = 1;
                    }
                }
            }
            return R;
        }

        public Matrix Clone(Matrix A)
        {
            Matrix R = Zeros(A.nRows, A.nCols);
            for (int i = 0; i < A.nRows; i++)
            {
                for (global::System.Int32 j = 0; j < A.nCols; j++)
                {
                        R[i, j] = A[i,j];
                }
            }
            return R;
        }


    }
}
