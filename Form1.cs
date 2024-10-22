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

            Pandas pd = new Pandas();
            pd.read_csv(baseDirectory+ "Calificaciones.csv", 1);

            Matrix X = pd.iloc(1, 1, pd.nRow, 3);

            Matrix Y = pd.iloc(1, 4, pd.nRow, 4);

            LinearRegresion reg = new LinearRegresion ();

            reg.Fit(X,Y);
            
            //nc = new Numcs();
            // xi = new Vector(6, 1, 4, 4, 6, 1, 3, 8, 7, 1, 4, 7, 1, 1, 7, 8, 2, 1, 6, 8);
            /* yi = new Vector(3796.42, 1301.38, 2923.62, 2822.94, 3648.76,
                                   1481.83, 2238.83, 4784.02, 4418.03, 1043.56,
                                   2684.12, 4389.07, 1489.30, 1400.45, 4390.26, 4860.31, 1571.67,
                                   1260.92, 3736.80, 4887.11);*/
            /*
            xi = new Vector(100,110,120,150,190,200,225,265,280,300);
            yi = new Vector(52,75,62,61,84,98,110,94,100,135);
            Matrix Xi = new Matrix(xi).T;
            Matrix Yi = new Matrix(yi).T;
            LinearRegresion li = new LinearRegresion();
            li.Fit(Xi, Yi);
            xMat = nc.linspace(100, 300, 10);
            yMat = li.Predict(xMat);
            li.FitEvent += Li_FitEvent;
            li.Fit(xi, yi, 0.0000005, 3000);
            
            */
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
            /*
             
            World world = new World(800, 533);
            Actor knight = new Actor(directory + @"\images\\Player\Knight_01__WALK_000.png");
            for (int i = 0; i < 10; i++)
            {
                knight.AddTexture(directory + @"\images\\Player\Knight_01__WALK_00" + i + ".png");
            }
            this.Controls.Add(world);
            world.Visible = true;
            world.player = knight;
            knight.X = 0;
            knight.Y = 408;
            world.Refresh();
            */

            // Vector v1 = new Vector(1, 2, 6, 9);
            //Vector v2 = new Vector(2, 3, 7, 1);
            //Vector v3 = new Vector(-2, 5, 4, 6);
            // Vector suma = v1 + v2;
            //suma.Show(); 
            /*
            Vector resta = v1 - v2;
            resta.Show();

            Vector multiplicacion = v1 * v2;
            multiplicacion.Show();

            Vector mulEscalar = v1 * 5;
            mulEscalar.Show(); 

            Vector division = v1 / v2;
            division.Show();

            Vector divisionEscalar = v1 / 3;
            divisionEscalar.Show();

            Vector potencia = v1 ^ 2;
            potencia.Show();

            Trace.WriteLine(v1.Σ());

            Trace.WriteLine(v1.Mean());

            Trace.WriteLine(v1.σ2());
            */
            /*
            Matrix mat = new Matrix(v1,v2,suma);
            mat.Show();
            mat[2, 3] = -1;
            Trace.WriteLine(mat[2, 1]);
            mat.Show();*/
            /*
            Matrix A = new Matrix(v1, v2, v3);
            A.Show();

            Trace.WriteLine(" ");
            */
            //Vector fila = B.GetCol(0);
            //B.T.Show(); 
            //Matrix AB = A.dot(B);
            //AB.Show();
            //fila.Show();
            /*
            B.Show();
            Trace.WriteLine("\nSuma de la matriz A y B");
            Matrix R = A + B;
            R.Show();
            Trace.WriteLine("\nResta de la matriz A y B");
            Matrix Rres = A - B;
            Rres.Show();
            Trace.WriteLine("\nMultiplicación de la matriz A y B");
            Matrix Rmul = A * B;
            Rmul.Show();
            Trace.WriteLine("\nDivision escalar de la matriz A y B");
            Matrix Rdiv = A / 9;
            Rdiv.Show();
            */
            //Vector f1 = new Vector(5, 3, -4, -2);
            //Vector f2 = new Vector(8, -1, 0, -3);
            //Matrix A = new Matrix(f1,f2);
            /*
            Numcs nc = new Numcs();
            Vector F1B = new Vector(3, 0-1, -0.2);
            Vector F2B = new Vector(0.1, 7, -0.3);
            Vector F3B = new Vector(0.3, -0.2, 10);
            //Vector F4B = new Vector(5, 1, 4);
            Matrix B = new Matrix(F1B,F2B,F3B);

            //B.I.Show();

            Matrix A = nc.Random(4,3);
            A.Show();
            */

        }
    }
}
