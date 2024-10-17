using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace InteligenciaArtificalGrafica.delos.Mathematics
{
    public class Vector
    {
        public double[] values = null;

        public int nValues
        {
            get
            {
                return values.Length;
            }
        }

        public double this[int i]
        {
            get
            {
                return values[i];
            }
            set
            {
                values[i] = value;
            }
        }
        public Vector(params double[] data)
        {
            values = data;
        }

        public static Vector operator +(Vector A, Vector B)
        {
            double[] data = new double[A.values.Length];
            for (int i = 0; i < A.values.Length; i++)
            {
                data[i] = A.values[i] + B.values[i];
            }
            Vector result = new Vector(data);
            return result;
        }

        public static Vector operator +(double A, Vector B)
        {
            double[] data = new double[B.values.Length];
            for (int i = 0; i < B.values.Length; i++)
            {
                data[i] = A + B.values[i];
            }
            Vector result = new Vector(data);
            return result;
        }

        public static Vector operator -(Vector A, Vector B)
        {
            double[] data = new double[A.values.Length];
            for (int i = 0; i < A.values.Length; i++)
            {
                data[i] = A.values[i] - B.values[i];
            }
            Vector result = new Vector(data);
            return result;
        }

        public static Vector operator -(Vector A, double B)
        {
            double[] data = new double[A.values.Length];
            for (int i = 0; i < A.values.Length; i++)
            {
                data[i] = A.values[i] - B;
            }
            Vector result = new Vector(data);
            return result;
        }
        public static Vector operator *(Vector A, Vector B)
        {
            double[] data = new double[A.values.Length];
            for (int i = 0; i < A.values.Length; i++)
            {
                data[i] = A.values[i] * B.values[i];
            }
            Vector result = new Vector(data);
            return result;
        }

        public static Vector operator *(Vector A, double B)
        {
            double[] data = new double[A.values.Length];
            for (int i = 0; i < A.values.Length; i++)
            {
                data[i] = A.values[i] * B;
            }
            Vector result = new Vector(data);
            return result;
        }

        public static Vector operator *(double A, Vector B)
        {
            double[] data = new double[B.values.Length];
            for (int i = 0; i < B.values.Length; i++)
            {
                data[i] =  A * B.values[i];
            }
            Vector result = new Vector(data);
            return result;
        }




        public static Vector operator /(Vector A, Vector B)
        {
            double[] data = new double[A.values.Length];
            for (int i = 0; i < A.values.Length; i++)
            {
                data[i] = A.values[i] / B.values[i];
            }
            Vector result = new Vector(data);
            return result;
        }

        public static Vector operator /(Vector A, double B)
        {
            double[] data = new double[A.values.Length];
            for (int i = 0; i < A.values.Length; i++)
            {
                data[i] = A.values[i] / B;
            }
            Vector result = new Vector(data);
            return result;
        }


        public static Vector operator ^(Vector A, double B)
        {
            double[] data = new double[A.values.Length];
            for (int i = 0; i < A.values.Length; i++)
            {
                data[i] = System.Math.Pow(A.values[i], B);
            }
            Vector result = new Vector(data);
            return result;
        }

        public double Σ()
        {
            double suma = 0;

            for (int i = 0; i < values.Length; i++)
            {
                suma = suma + values[i];
            }
            return suma;
        }

        public double Mean()
        {
            return this.Σ() / values.Length;
        } 

        public double σ2() 
        {
            return ( (this - Mean() ) ^ 2).Σ() / (values.Length - 1);
        }

        public double σ() 
        {
            return System.Math.Sqrt(σ2());

        }

        public void Show() 
        {
            for (int i = 0; i < values.Length; i++)
            {
                Trace.Write(values[i]+", ");
            }
            Trace.WriteLine("");
        }

    }
}
