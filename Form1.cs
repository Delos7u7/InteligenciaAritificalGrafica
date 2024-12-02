using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
//using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using delos.Game.Enviroment;
using delos.Game.Player;
using delos.Mathematics;
using InteligenciaArtificalGrafica.delos.Mathematics;
using delos.Mathematics.LinearAlgebra;
using delos.Game.IA.Regression;
using ScottPlot;
using delos.Data;
using delos.Game.IA.Searches;
using ScottPlot.Drawing.Colormaps;
using System.Security.Cryptography;

namespace InteligenciaArtificalGrafica
{
    public partial class Form1 : Form
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        Vector xi, yi;
        Numcs nc;
        Vector xMat, yMat;



        // string directory = System.Environment.CurrentDirectory;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Li_FitEvent(object sender, LinearRegresion.FitEventArgs e)
        {
            Vector x = nc.linspace(100, 300, 10);
            Vector y = e.Values[1] + x * e.Values[2];
            formsPlot1.BeginInvoke(new MethodInvoker(() =>
            {
                formsPlot1.Plot.Clear();
                formsPlot1.Plot.AddScatterPoints(xi.values, yi.values);
                formsPlot1.Plot.AddScatter(xMat.values, yMat.values);
                formsPlot1.Plot.AddScatter(x.values, y.values);
                formsPlot1.Plot.AddAnnotation(e.Msg +  " " + e.Values[0] + " θ0 =" + e.Values[1] + " θ1 =" + e.Values[2], ScottPlot.Alignment.UpperLeft);
                formsPlot1.Render();
            }));


        }

        private void UpdateGraph()
        {
            formsPlot1.Plot.Clear();

            formsPlot1.Plot.AddScatterPoints(xi.values,yi.values);
            formsPlot1.Plot.AddScatter(xMat.values,yMat.values);
            formsPlot1.Render();
        }

        public Form1()
        {
            InitializeComponent();
            nc = new Numcs();

            //MLP.FIT()

            Vector F1 = new Vector(0, 0);
            Vector F2 = new Vector(0, 1);
            Vector F3 = new Vector(1, 0);
            Vector F4 = new Vector(1, 1);

            Matrix inputs = new Matrix(F1,F2,F3,F4);
            Matrix outputs = new Matrix(new Vector(0,1,1,0)).T;


            int nInp = 2;
            int nHid = 10;
            int nOut = 1;
            double α = 0.3;
            int epoch = 2500;
            Matrix W0 = nc.Random(nInp,nHid);
            Matrix b0 = nc.Random(nHid, 1);
            Matrix W1 = nc.Random(nHid,nOut);
            Matrix b1 = nc.Random(nOut, 1);

            for (int i = 0; i < epoch; i++)
            {
                for (global::System.Int32 j = 0; j < inputs.nRows; j++)
                {
                    
                    Matrix X = new Matrix(inputs.GetRow(j));
                    Matrix Y = new Matrix(outputs.GetRow(j));
                    Matrix Z0 = X.dot(W0) + b0.T;
                    Matrix A0 = Sigm(Z0);
                    Matrix Z1 = A0.dot(W1) + b1.T;
                    Matrix A1 = Sigm(Z1);
                    Matrix δ1 = (Y - A1) * A1 * (1.0 - A1);
                    Matrix ΔW1 = α * (δ1.T.dot(A0));
                    Matrix Δb1 = α * δ1;
                    Matrix δ0 = δ1.dot(W1.T) * A0 * (-1) * (A0 - 1);
                    Matrix ΔW0 = α * (δ0.T.dot(X));
                    Matrix Δb0 = α * δ0;
                    W0 = W0 + ΔW0.T;
                    b0 = b0 + Δb0.T;
                    W1 = W1 + ΔW1.T;
                    b1 = b1 + Δb1.T;


                }
            }

            //codigo para predict
            Trace.WriteLine("Predicción para 0,0 debería de dar 0");
            Matrix X1 = new Matrix(new Vector (0,0));
            Matrix Z01 = X1.dot(W0) + b0.T;
            Matrix A01 = Sigm(Z01);
            Matrix Z11 = A01.dot(W1) + b1.T;
            Matrix A11 = Sigm(Z11);
            Trace.WriteLine("Predicción de la red");
            A11.Show();

            Trace.WriteLine("Predicción para 0,1 debería de dar 1");
             X1 = new Matrix(new Vector(0, 1));
             Z01 = X1.dot(W0) + b0.T;
             A01 = Sigm(Z01);
             Z11 = A01.dot(W1) + b1.T;
             A11 = Sigm(Z11);
            Trace.WriteLine("Predicción de la red");
            A11.Show();

            Trace.WriteLine("Predicción para 1,0 debería de dar 1");
            X1 = new Matrix(new Vector(1, 0));
            Z01 = X1.dot(W0) + b0.T;
            A01 = Sigm(Z01);
            Z11 = A01.dot(W1) + b1.T;
            A11 = Sigm(Z11);
            Trace.WriteLine("Predicción de la red");
            A11.Show();

            Trace.WriteLine("Predicción para 1,1 debería de dar 0");
            X1 = new Matrix(new Vector(1, 1));
            Z01 = X1.dot(W0) + b0.T;
            A01 = Sigm(Z01);
            Z11 = A01.dot(W1) + b1.T;
            A11 = Sigm(Z11);
            Trace.WriteLine("Predicción de la red");
            A11.Show();


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
