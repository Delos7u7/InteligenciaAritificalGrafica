using InteligenciaArtificalGrafica.delos.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delos.Mathematics.LinearAlgebra
{
    public class GaussJordan
    {
        private Matrix R = null;
        public GaussJordan() 
        {

        }

        public Matrix Calculate(Matrix A)
        {
            R = A;
            for (int i = 0; i < A.nRows; i++)
            {
                for (global::System.Int32 j = 0; j < A.nCols; j++)
                {
                    if (i == j)
                    {
                        ConvertPivotTo1(i);
                        ConvertBelowTo0(i);
                        ConvertAboveTo0(i);
                    }
                }
            }
            return R;
        }

        private void ConvertPivotTo1(int i)
        {
            Vector row = R.GetRow(i);
            double pivot = R[i, i];
            Vector newRow = row / pivot;
            R.SetRow(i, newRow);
        }

        private void ConvertBelowTo0(int pivot)
        {
            if ((pivot +1) < R.nRows)
            {
                Vector rowPivot = R.GetRow(pivot);
                for (global::System.Int32 i = pivot + 1; i < R.nRows; i++)
                {

                    Vector rowFactor = R.GetRow(i);
                    double factor = -rowFactor[pivot];
                    Vector FactorxrowPivot = rowPivot * factor;
                    Vector NewRowFactor = rowFactor + FactorxrowPivot;
                    R.SetRow(i, NewRowFactor);
                }
            }
        }

        private void ConvertAboveTo0(int pivot) 
        {
            if ((pivot - 1) >= 0)
            {
                Vector rowPivot = R.GetRow(pivot);
                for (global::System.Int32 i = pivot - 1; i >= 0; i--)
                {

                    Vector rowFactor = R.GetRow(i);
                    double factor = -rowFactor[pivot];
                    Vector FactorxrowPivot = rowPivot * factor;
                    Vector NewRowFactor = rowFactor + FactorxrowPivot;
                    R.SetRow(i, NewRowFactor);
                }
            }
        }
    }
}
