using InteligenciaArtificalGrafica.delos.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delos.Mathematics
{
    public class Matrix
    {
        Vector[] rows = null;
        Numcs nc;

        public double this[int i, int j]
        {
            get
            {
                Vector row = rows[i];
                return row[j];
            }
            set
            {
                rows[i][j] = value;
            }
        }
        public int nRows
        { 
            get 
            {
                return rows.Length;
            }
        }

        public int nCols
        {
            get
            {
                return rows[0].nValues;
            }
        }

        public Matrix I 
        {
            get
            {
                Matrix R = nc.Zeros(nRows, 2 * nCols);
                for (int i = 0; i < R.nRows; i++)
                {
                    for (global::System.Int32 j = 0; j < this.nCols; j++)
                    {
                        if (j < nCols)
                        {
                            R[i, j] = this[i, j];
                        }
                        if (i == j)
                        {
                            R[i, j + this.nCols] = 1;
                        }
                    }
                }
                LinearAlgebra.GaussJordan gauss = new LinearAlgebra.GaussJordan();
                R = gauss.Calculate(R);
                Vector[] columns = new Vector[nCols];
                for (int j = this.nCols; j < R.nCols; j++)
                {
                    columns[j - nCols] = R.GetCol(j);
                }
                Matrix Inverse = new Matrix(columns).T;
                return Inverse;
            }
        }

        public Matrix T
        {
            get
            {
                Matrix R = nc.Zeros(nCols, nRows);
                for (int i = 0; i < nCols; i++)
                {
                    for (global::System.Int32 j = 0; j < nRows; j++)
                    {
                        R[i, j] = this[j, i];
                    }
                }
                return R;
            }
        }
        public Matrix(params Vector[] rows) 
        {
            this.rows = rows;
            nc = new Numcs();
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            Numcs nc = new Numcs();
            Matrix R = nc.Zeros(A.nRows, A.nCols);
            for (int i = 0; i < A.nRows; i++)
            {
                for (global::System.Int32 j = 0; j < A.nCols; j++)
                {
                    R[i,j] = A[i,j] + B [i,j];
                }
            }
            return R;
        }
        public static Matrix operator +(Matrix A, double B)
        {
            Numcs nc = new Numcs();
            Matrix R = nc.Zeros(A.nRows, A.nCols);
            for (int i = 0; i < A.nRows; i++)
            {
                for (global::System.Int32 j = 0; j < A.nCols; j++)
                {
                    R[i, j] = A[i, j] + B;
                }
            }
            return R;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            Numcs nc = new Numcs();
            Matrix R = nc.Zeros(A.nRows, A.nCols);
            for (int i = 0; i < A.nRows; i++)
            {
                for (global::System.Int32 j = 0; j < A.nCols; j++)
                {
                    R[i, j] = A[i, j] - B[i, j];
                }
            }
            return R;
        }
        public static Matrix operator -(Matrix A, double B)
        {
            Numcs nc = new Numcs();
            Matrix R = nc.Zeros(A.nRows, A.nCols);
            for (int i = 0; i < A.nRows; i++)
            {
                for (global::System.Int32 j = 0; j < A.nCols; j++)
                {
                    R[i, j] = A[i, j] - B;
                }
            }
            return R;
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            Numcs nc = new Numcs();
            Matrix R = nc.Zeros(A.nRows, A.nCols);
            for (int i = 0; i < A.nRows; i++)
            {
                for (global::System.Int32 j = 0; j < A.nCols; j++)
                {
                    R[i, j] = A[i, j] * B[i, j];
                }
            }
            return R;
        }

        public static Matrix operator *(Matrix A, double B)
        {
            Numcs nc = new Numcs();
            Matrix R = nc.Zeros(A.nRows, A.nCols);
            for (int i = 0; i < A.nRows; i++)
            {
                for (global::System.Int32 j = 0; j < A.nCols; j++)
                {
                    R[i, j] = A[i, j] * B;
                }
            }
            return R;
        }

        public static Matrix operator /(Matrix A, double B)
        {
            Numcs nc = new Numcs();
            Matrix R = nc.Zeros(A.nRows, A.nCols);
            for (int i = 0; i < A.nRows; i++)
            {
                for (global::System.Int32 j = 0; j < A.nCols; j++)
                {
                    R[i, j] = A[i, j] / B;
                }
            }
            return R;
        }

        public Vector GetRow(int i)
        {
            return rows[i];
        }

        public void SetRow(int i, Vector row)
        {
            rows[i] = row;
        }
        public Vector GetCol(int col)
        {
            double[]values = new double[nRows];
            for (int i = 0; i < nRows; i++)
            {
                for (global::System.Int32 j = 0; j < nCols; j++)
                {
                    if (j==col)
                    {
                        values[i] = this[i, j];
                    }
                }
            }
            Vector column = new Vector(values);
            return column;
        }

        public Matrix dot(Matrix B)
        {
            int rowsA = this.nRows;
            int colsA = this.nCols;
            int rowsB = B.nRows;
            int colsB = B.nCols;
            Matrix R = nc.Zeros(rowsA, colsB);
            if (colsA == rowsB)
            {
                for (global::System.Int32 i = 0; i < rowsA; i++)
                {
                    Vector fila = rows[i];
                    for (global::System.Int32 j = 0; j < colsB; j++)
                    {
                        Vector columna = B.GetCol(j);
                        Vector filaxcolumna = fila * columna;
                        R[i, j] = filaxcolumna.Σ();
                    }
                }
                return R;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("No se puede realizar el producto ya que las filas y " +
                    "las columnas no coinciden");
                return null;
            }
        }

        public void Show()
        {
            for (int i = 0; i < this.rows.Length; i++)
            {
                rows[i].Show();
            }
        }
    }
}
