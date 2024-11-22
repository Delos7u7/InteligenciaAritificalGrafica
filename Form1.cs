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

            Vector F1 = new Vector(0, 0);
            Vector F2 = new Vector(0, 1);
            Vector F3 = new Vector(1, 0);
            Vector F4 = new Vector(1, 1);

            Matrix inputs = new Matrix(F1,F2,F3,F4);
            Matrix outputs = new Matrix(new Vector(0,1,1,0)).T;


            int nInp = 2;
            int nHid = 2;
            int nOut = 1;
            double α = 0.001;
            int epoch = 1000;
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

                }
            }

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
