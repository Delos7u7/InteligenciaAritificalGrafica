using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using delos.Mathematics;
using InteligenciaArtificalGrafica.delos.Mathematics;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace delos.Game.IA.Regression
{
    public class LinearRegresion
    {
        Numcs nc;
        public double θ1 = 0;
        public double θ0 = 0;
        Matrix W;
        public LinearRegresion() 
        { 
            nc = new Numcs();
        }
        public void Fit(Vector xi, Vector yi)
        {
             θ1 = (((xi - xi.Mean()) * (yi - yi.Mean())).Σ())
                /
                 ((xi - xi.Mean()) ^ 2).Σ();

             θ0 = (yi.Mean() - (θ1 * xi.Mean()));

            Trace.WriteLine("Este es θo: "+θ0+ " y Este es θ1: " + θ1);
        }

        public void Fit(Matrix x, Matrix Y) 
        {

            List<Vector> xcols = new List<Vector>();

            for (int j = 0; j < x.nCols; j++)
            {
                xcols.Add(x.GetCol(j));
            }

            Vector ones = nc.Ones(x.nRows);

            xcols.Add(ones);

            Matrix X = new Matrix(xcols.ToArray()).T;

            W = ((X.T.dot(X)).I).dot(X.T).dot(Y);

            W.Show();

            θ0 = W[0, 0];
            θ1 = W[1, 0];


        }


        public void Fit4(Matrix x, Matrix Y)
        {
            Vector xi = x.GetCol(0);

            Vector ones = nc.Ones(xi.nValues);

            Matrix X = new Matrix(ones, xi).T;

            Matrix W = ((X.T.dot(X)).I).dot(X.T).dot(Y);

            θ0 = W[0, 0];
            θ1 = W[1, 0];


        }
        public void Fit(Vector x1, Vector yi, double α, double epoch)
        {

            θ1 = 0;
            θ0 = 0;

            double n = x1.nValues;
            for (int i = 0; i < epoch; i++)
            {
                θ1 = θ1 - (α * 1 / n) * ((θ0 + (θ1 * x1) - yi)* x1).Σ();
                θ0 = θ0 - (α * 1 / n) * (θ0 + (θ1 * x1) - yi).Σ();
                OnFitEvent(new FitEventArgs("Fit Event", new double[] { i, θ0, θ1 }));
            }


        }

        public double Predict(double habitaciones)
        {
             double y = θ0 + (θ1 * habitaciones);

             return y;
        }

        public Vector Predict(Vector habitaciones)
        {
            Vector y = θ0 + (θ1 * habitaciones);

            return y;
        }

        public double Predict(Matrix x)
        {
            Vector vectorX = x.GetCol(0);

            Vector vectorW = W.GetCol(0);
            double[] data = new double[vectorW.nValues];
            double[] Ws = new double[vectorW.nValues - 1 ];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = vectorW[i];
                if (i < data.Length - 1)
                {
                    Ws[i] = vectorW[i];
                }
            }

            

            double W0 = data[data.Length - 1];
            Vector w = new Vector(Ws);
            double y = W0 + (vectorX * w).Σ();
            return y; 
        
        }

        public delegate void FitEventHandler(object sender, FitEventArgs e);
        public event FitEventHandler FitEvent;

        protected virtual void OnFitEvent (FitEventArgs e) 
        {
            if (FitEvent != null)
            {
                FitEvent(this, e);
            }

        }

        public class FitEventArgs : EventArgs
        {
            public string Msg { get; set; }

            public double[] Values { get; set; }

            public FitEventArgs(string msg, double[] values)
            {
                Msg = msg;
                Values = values;
            }
        }
    }
}
