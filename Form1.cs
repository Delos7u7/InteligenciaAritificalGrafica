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
            /*
            Vertice mix = new Vertice("Mixquiahuala");
            Vertice ixmi = new Vertice("Ixmiquilpan");
            Vertice acto = new Vertice("Actopan");
            Vertice pro = new Vertice("Progreso");
            Vertice hoyos = new Vertice("Los hoyos");
            Vertice tezo = new Vertice("Tezontepec");
            Vertice tina = new Vertice("El tinaco");
            Vertice tlahue = new Vertice("Tlahuelilpan");
            Vertice tlax = new Vertice("Tlaxcoapan");
            Vertice teo = new Vertice("Teocalco");
            Vertice tula = new Vertice("Tula");

            Vertice ciudadSahagun = new Vertice("Ciudad Sahagún");
            Vertice tecozautla = new Vertice("Tecozautla");
            Vertice sanAgustin = new Vertice("San Agustín Tlaxiaca");
            Vertice atitalaquia = new Vertice("Atitalaquia");
            Vertice sanSalvador = new Vertice("San Salvador");
            Vertice elArenal = new Vertice("El Arenal");
            Vertice epazoyucan = new Vertice("Epazoyucan");
            Vertice almoloya = new Vertice("Almoloya");
            Vertice tolcayuca = new Vertice("Tolcayuca");
            Vertice tlanalapa = new Vertice("Tlanalapa");
            Vertice chapulhuacan = new Vertice("Chapulhuacán");
            Vertice huautla = new Vertice("Huautla");
            Vertice tenangoDeDoria = new Vertice("Tenango de Doria");
            Vertice tepehuacan = new Vertice("Tepehuacán de Guerrero");
            Vertice acaxochitlan = new Vertice("Acaxochitlán");
            Vertice calnali = new Vertice("Calnali");
            Vertice zacualtipan = new Vertice("Zacualtipán de Ángeles");
            Vertice xochicoatlan = new Vertice("Xochicoatlán");
            Vertice pisaflores = new Vertice("Pisaflores");
            Vertice molangoEscamilla = new Vertice("Molango de Escamilla");
            Vertice huichapan = new Vertice("Huichapan");
            Vertice apaxco = new Vertice("Apaxco");
            Vertice nicolasFlores = new Vertice("Nicolás Flores");
            Vertice metztitlan = new Vertice("Metztitlán");
            Vertice huehuetla = new Vertice("Huehuetla");
            Vertice sanFelipe = new Vertice("San Felipe Orizatlán");
            Vertice atlapexco = new Vertice("Atlapexco");
            Vertice tianguistengo = new Vertice("Tianguistengo");
            Vertice atotonilcoElGrande = new Vertice("Atotonilco El Grande");
            Vertice pachuca = new Vertice("Pachuca");
            Vertice tulancingo = new Vertice("Tulancingo");
            Vertice huejutla = new Vertice("Huejutla de Reyes");
            Vertice tizayuca = new Vertice("Tizayuca");
            Vertice mineral = new Vertice("Mineral de la Reforma");
            Vertice tepeji = new Vertice("Tepeji del Río");
            Vertice apan = new Vertice("Apan");
            Vertice zimapan = new Vertice("Zimapán");
            Vertice tepeapulco = new Vertice("Tepeapulco");
            Vertice atotonilco = new Vertice("Atotonilco de Tula");
            Vertice molango = new Vertice("Molango");
            Vertice cardonal = new Vertice("Cardonal");
            Vertice metztitlán = new Vertice("Metztitlán");
            Vertice actopan = new Vertice("Actopan");
            Vertice tecazoutla = new Vertice("tecazoutla");



            Grafo hidalgo = new Grafo("Hidalgo");
            hidalgo.AgregarVertice(mix);
            hidalgo.AgregarVertice(ixmi);
            hidalgo.AgregarVertice(acto);
            hidalgo.AgregarVertice(pro);
            hidalgo.AgregarVertice(hoyos);
            hidalgo.AgregarVertice(tezo);
            hidalgo.AgregarVertice(tina);
            hidalgo.AgregarVertice(tlahue);
            hidalgo.AgregarVertice(tlax);
            hidalgo.AgregarVertice(teo);
            hidalgo.AgregarVertice(tula);
            hidalgo.AgregarVertice(pachuca);
            hidalgo.AgregarVertice(tecazoutla);
            hidalgo.AgregarVertice(tulancingo);
            hidalgo.AgregarVertice(huejutla);
            hidalgo.AgregarVertice(tizayuca);
            hidalgo.AgregarVertice(mineral);
            hidalgo.AgregarVertice(tepeji);
            hidalgo.AgregarVertice(apan);
            hidalgo.AgregarVertice(zimapan);
            hidalgo.AgregarVertice(tepeapulco);
            hidalgo.AgregarVertice(huichapan);
            hidalgo.AgregarVertice(atotonilco);
            hidalgo.AgregarVertice(molango);
            hidalgo.AgregarVertice(cardonal);
            hidalgo.AgregarVertice(metztitlan);
            hidalgo.AgregarVertice(actopan);
            hidalgo.AgregarVertice(ciudadSahagun);
            hidalgo.AgregarVertice(tecozautla);
            hidalgo.AgregarVertice(sanAgustin);
            hidalgo.AgregarVertice(atitalaquia);
            hidalgo.AgregarVertice(sanSalvador);
            hidalgo.AgregarVertice(elArenal);
            hidalgo.AgregarVertice(epazoyucan);
            hidalgo.AgregarVertice(almoloya);
            hidalgo.AgregarVertice(tolcayuca);
            hidalgo.AgregarVertice(tlanalapa);
            hidalgo.AgregarVertice(chapulhuacan);
            hidalgo.AgregarVertice(huautla);
            hidalgo.AgregarVertice(tenangoDeDoria);
            hidalgo.AgregarVertice(tepehuacan);
            hidalgo.AgregarVertice(acaxochitlan);
            hidalgo.AgregarVertice(calnali);
            hidalgo.AgregarVertice(zacualtipan);
            hidalgo.AgregarVertice(xochicoatlan);
            hidalgo.AgregarVertice(pisaflores);
            hidalgo.AgregarVertice(molangoEscamilla);
            hidalgo.AgregarVertice(apaxco);
            hidalgo.AgregarVertice(nicolasFlores);
            hidalgo.AgregarVertice(huehuetla);
            hidalgo.AgregarVertice(sanFelipe);
            hidalgo.AgregarVertice(atlapexco);
            hidalgo.AgregarVertice(tianguistengo);
            hidalgo.AgregarVertice(atotonilcoElGrande);
            hidalgo.AgregarVertice(mix);
            hidalgo.AgregarVertice(ixmi);
            hidalgo.AgregarVertice(pro);
            hidalgo.AgregarVertice(hoyos);
            hidalgo.AgregarVertice(tezo);
            hidalgo.AgregarVertice(tina);
            hidalgo.AgregarVertice(tlahue);
            hidalgo.AgregarVertice(tlax);
            hidalgo.AgregarVertice(teo);
            hidalgo.AgregarVertice(tula);

            mix.AgregarAdyacente(pro);
            mix.AgregarAdyacente(hoyos);

            hoyos.AgregarAdyacente(mix);
            hoyos.AgregarAdyacente(tezo);
            hoyos.AgregarAdyacente(tina);

            tezo.AgregarAdyacente(hoyos);
            tezo.AgregarAdyacente(tina);

            tina.AgregarAdyacente(tlahue);
            tina.AgregarAdyacente(tezo);
            tina.AgregarAdyacente(hoyos);

            tlahue.AgregarAdyacente(tina);
            tlahue.AgregarAdyacente(tlax);
            tlax.AgregarAdyacente(tlahue);
            tlahue.AgregarAdyacente(teo);

            teo.AgregarAdyacente(tula);
            teo.AgregarAdyacente(tlahue);
            tula.AgregarAdyacente(teo);

            pro.AgregarAdyacente(mix);
            pro.AgregarAdyacente(acto);
            pro.AgregarAdyacente(ixmi);
            ixmi.AgregarAdyacente(pro);
            ixmi.AgregarAdyacente(acto);
            acto.AgregarAdyacente(ixmi);
            acto.AgregarAdyacente(pro);

            // Conexiones de Pachuca
            pachuca.AgregarAdyacente(mineral);
            pachuca.AgregarAdyacente(actopan);
            pachuca.AgregarAdyacente(tizayuca);
            pachuca.AgregarAdyacente(tulancingo);
            pachuca.AgregarAdyacente(epazoyucan);
            pachuca.AgregarAdyacente(sanAgustin);
            pachuca.AgregarAdyacente(apan);

            // Conexiones de Mineral de la Reforma
            mineral.AgregarAdyacente(pachuca);
            mineral.AgregarAdyacente(epazoyucan);

            // Conexiones de Actopan
            actopan.AgregarAdyacente(pachuca);
            actopan.AgregarAdyacente(sanAgustin);
            actopan.AgregarAdyacente(elArenal);
            actopan.AgregarAdyacente(sanSalvador);
            actopan.AgregarAdyacente(mix);

            // Conexiones de San Agustín Tlaxiaca
            sanAgustin.AgregarAdyacente(pachuca);
            sanAgustin.AgregarAdyacente(actopan);
            sanAgustin.AgregarAdyacente(elArenal);

            // Conexiones de El Arenal
            elArenal.AgregarAdyacente(sanAgustin);
            elArenal.AgregarAdyacente(actopan);
            elArenal.AgregarAdyacente(sanSalvador);

            // Conexiones de San Salvador
            sanSalvador.AgregarAdyacente(actopan);
            sanSalvador.AgregarAdyacente(elArenal);
            sanSalvador.AgregarAdyacente(mix);

            // Conexiones de Mixquiahuala
            mix.AgregarAdyacente(pro);
            mix.AgregarAdyacente(hoyos);
            mix.AgregarAdyacente(sanSalvador);
            mix.AgregarAdyacente(actopan);

            // Conexiones de Progreso
            pro.AgregarAdyacente(mix);
            pro.AgregarAdyacente(acto);
            pro.AgregarAdyacente(ixmi);

            // Conexiones de Ixmiquilpan
            ixmi.AgregarAdyacente(pro);
            ixmi.AgregarAdyacente(acto);
            ixmi.AgregarAdyacente(zimapan);
            ixmi.AgregarAdyacente(cardonal);

            // Conexiones de Actopan (acto)
            acto.AgregarAdyacente(ixmi);
            acto.AgregarAdyacente(pro);

            // Conexiones de Los Hoyos
            hoyos.AgregarAdyacente(mix);
            hoyos.AgregarAdyacente(tezo);
            hoyos.AgregarAdyacente(tina);

            // Conexiones de Tezontepec
            tezo.AgregarAdyacente(hoyos);
            tezo.AgregarAdyacente(tina);
            tezo.AgregarAdyacente(tlahue);

            // Conexiones de El Tinaco
            tina.AgregarAdyacente(tlahue);
            tina.AgregarAdyacente(tezo);
            tina.AgregarAdyacente(hoyos);

            // Conexiones de Tlahuelilpan
            tlahue.AgregarAdyacente(tina);
            tlahue.AgregarAdyacente(tlax);
            tlahue.AgregarAdyacente(teo);

            // Conexiones de Tlaxcoapan
            tlax.AgregarAdyacente(tlahue);
            tlax.AgregarAdyacente(teo);

            // Conexiones de Teocalco
            teo.AgregarAdyacente(tula);
            teo.AgregarAdyacente(tlahue);
            teo.AgregarAdyacente(tlax);

            // Conexiones de Tula
            tula.AgregarAdyacente(teo);
            tula.AgregarAdyacente(atitalaquia);
            tula.AgregarAdyacente(tepeji);

            // Conexiones de Atitalaquia
            atitalaquia.AgregarAdyacente(tula);
            atitalaquia.AgregarAdyacente(tepeji);

            // Conexiones de Tepeji del Río
            tepeji.AgregarAdyacente(atitalaquia);
            tepeji.AgregarAdyacente(apaxco);

            // Conexiones de Apaxco
            apaxco.AgregarAdyacente(tepeji);

            // Conexiones de Tulancingo
            tulancingo.AgregarAdyacente(pachuca);
            tulancingo.AgregarAdyacente(acaxochitlan);
            tulancingo.AgregarAdyacente(tenangoDeDoria);
            tulancingo.AgregarAdyacente(tlanalapa);
            tulancingo.AgregarAdyacente(epazoyucan);

            // Conexiones de Epazoyucan
            epazoyucan.AgregarAdyacente(pachuca);
            epazoyucan.AgregarAdyacente(mineral);
            epazoyucan.AgregarAdyacente(tulancingo);

            // Conexiones de Acaxochitlán
            acaxochitlan.AgregarAdyacente(tulancingo);
            acaxochitlan.AgregarAdyacente(tenangoDeDoria);

            // Conexiones de Tenango de Doria
            tenangoDeDoria.AgregarAdyacente(acaxochitlan);
            tenangoDeDoria.AgregarAdyacente(huehuetla);

            // Conexiones de Huehuetla
            huehuetla.AgregarAdyacente(tenangoDeDoria);
            huehuetla.AgregarAdyacente(pisaflores);

            // Conexiones de Pisaflores
            pisaflores.AgregarAdyacente(huehuetla);
            pisaflores.AgregarAdyacente(chapulhuacan);

            // Conexiones de Chapulhuacán
            chapulhuacan.AgregarAdyacente(pisaflores);

            // Conexiones de Huejutla de Reyes
            huejutla.AgregarAdyacente(sanFelipe);
            huejutla.AgregarAdyacente(calnali);
            huejutla.AgregarAdyacente(tepehuacan);

            // Conexiones de San Felipe Orizatlán
            sanFelipe.AgregarAdyacente(huejutla);
            sanFelipe.AgregarAdyacente(atlapexco);

            // Conexiones de Atlapexco
            atlapexco.AgregarAdyacente(sanFelipe);
            atlapexco.AgregarAdyacente(huautla);

            // Conexiones de Huautla
            huautla.AgregarAdyacente(atlapexco);

            // Conexiones de Calnali
            calnali.AgregarAdyacente(huejutla);
            calnali.AgregarAdyacente(zacualtipan);
            calnali.AgregarAdyacente(molango);

            // Conexiones de Zacualtipán de Ángeles
            zacualtipan.AgregarAdyacente(calnali);
            zacualtipan.AgregarAdyacente(molango);

            // Conexiones de Molango de Escamilla
            molango.AgregarAdyacente(zacualtipan);
            molango.AgregarAdyacente(metztitlan);

            // Conexiones de Metztitlán
            metztitlan.AgregarAdyacente(molango);
            metztitlan.AgregarAdyacente(cardonal);

            // Conexiones de Cardonal
            cardonal.AgregarAdyacente(metztitlan);
            cardonal.AgregarAdyacente(ixmi);

            // Conexiones de Zimapán
            zimapan.AgregarAdyacente(ixmi);
            zimapan.AgregarAdyacente(nicolasFlores);
            zimapan.AgregarAdyacente(huichapan);

            // Conexiones de Nicolás Flores
            nicolasFlores.AgregarAdyacente(zimapan);
            nicolasFlores.AgregarAdyacente(huichapan);

            // Conexiones de Huichapan
            huichapan.AgregarAdyacente(nicolasFlores);
            huichapan.AgregarAdyacente(tecazoutla);

            // Conexiones de Tecozautla
            tecozautla.AgregarAdyacente(huichapan);

            // Conexiones de Tizayuca
            tizayuca.AgregarAdyacente(pachuca);
            tizayuca.AgregarAdyacente(tolcayuca);
            tizayuca.AgregarAdyacente(atotonilco);

            // Conexiones de Tolcayuca
            tolcayuca.AgregarAdyacente(tizayuca);
            tolcayuca.AgregarAdyacente(apan);

            // Conexiones de Apan
            apan.AgregarAdyacente(tolcayuca);
            apan.AgregarAdyacente(almoloya);
            apan.AgregarAdyacente(tepeapulco);

            // Conexiones de Almoloya
            almoloya.AgregarAdyacente(apan);
            almoloya.AgregarAdyacente(ciudadSahagun);

            // Conexiones de Tepeapulco
            tepeapulco.AgregarAdyacente(apan);
            tepeapulco.AgregarAdyacente(ciudadSahagun);
            tepeapulco.AgregarAdyacente(tlanalapa);

            // Conexiones de Ciudad Sahagún
            ciudadSahagun.AgregarAdyacente(tepeapulco);
            ciudadSahagun.AgregarAdyacente(almoloya);

            // Conexiones de Tlanalapa
            tlanalapa.AgregarAdyacente(tepeapulco);
            tlanalapa.AgregarAdyacente(tulancingo);

            // Conexiones de Atotonilco de Tula
            atotonilco.AgregarAdyacente(tizayuca);
            atotonilco.AgregarAdyacente(atitalaquia);

            // Conexiones de Atotonilco El Grande
            atotonilcoElGrande.AgregarAdyacente(pachuca);
            atotonilcoElGrande.AgregarAdyacente(metztitlan);

            // Conexiones de Tepehuacán de Guerrero
            tepehuacan.AgregarAdyacente(huejutla);

            // Conexiones de Tianguistengo
            tianguistengo.AgregarAdyacente(zacualtipan);

            // Conexiones de Xochicoatlán
            xochicoatlan.AgregarAdyacente(calnali);
            xochicoatlan.AgregarAdyacente(zacualtipan);

            // Conexiones de Tepeji del Río
            tepeji.AgregarAdyacente(tula);
            tepeji.AgregarAdyacente(atitalaquia);

            //hidalgo.MostrarVertices();
            Vertice origen = hidalgo.Buscar("Progreso");
            Vertice destino = hidalgo.Buscar("Tula");
            Busqueda busqueeda = new Busqueda();
            busqueeda.PrimeroEnAnchura(origen, destino);
            */

            
            Pandas pd = new Pandas();
            pd.read_csv(baseDirectory+ "Colesterol.csv", 1);

            Matrix Y = pd.iloc(1, pd.nCol, pd.nRow, pd.nCol);

            Matrix X = pd.iloc(1, 1, pd.nRow, pd.nCol - 1);

            Y.Show();

            LinearRegresion reg = new LinearRegresion ();

            reg.Fit(X,Y);

            Vector vectorX = new Vector(78, 110, 13.2);
            Matrix x = new Matrix(vectorX).T;
            double vectorY = reg.Predict(x);    
            Trace.WriteLine(vectorY);

            

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
