using System.IO;
using System.Diagnostics;
using delos.Mathematics;
using InteligenciaArtificalGrafica.delos.Mathematics;

namespace delos.Data
{
    public class Pandas
    {
        public string[,] Data;
        string[] lines;
        string[] head;
        public int nRow;
        public int nCol;
        int initialRow = 0;
        int n;

        public string[] dataFrame
        {
            get
            {
                string[] formatLines = null;
                if (Data != null)
                {
                    formatLines = new string[nRow];
                    for (int i = 0; i < nRow; i++)
                    {
                        string line = "";
                        for (int j = 0; j < nCol; j++)
                        {
                            line += string.Format(" {0, 6}", Data[i, j]);
                        }
                        formatLines[i] = line;
                    }
                }
                return formatLines;
            }
        }

        public void read_csv(string filepath, int? header = null, char delimiter = ',')
        {
            lines = File.ReadAllLines(filepath);
            if (header != null)
            {
                n = (int)header;
                head = lines[n].Split(',');
                initialRow = 1;
            }
            else
            {
                head = lines[0].Split(',');
                initialRow = 0;
            }
            nRow = lines.Length;
            nCol = head.Length;
            Data = new string[nRow, nCol];
            for (int i = 0; i < nRow; i++)
            {
                string[] line = lines[i].Split(',');
                for (int j = 0; j < nCol; j++)
                {
                    string cell = line[j];
                    Data[i, j] = cell;
                }
            }
        }

        public void Replace(string to_replace, double value)
        {
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    if (Data[i, j] == to_replace)
                    {
                        Data[i, j] = value.ToString();
                    }
                }
            }
        }

        public Matrix iloc(int startRow, int startCol, int endRow, int endCol)
        {
            Vector[] rows = new Vector[endRow - startRow + 1];
            for (int i = 0; i < rows.Length; i++)
            {

                double[] value = new double[endCol - startCol + 1];
                for (int j = 0; j < value.Length; j++)
                {
                    value[j] = double.Parse(Data[i + startRow - 1, j + startCol - 1]);
                }
                rows[i] = new Vector(value);
            }
            Matrix R = new Matrix(rows);
            return R;
        }

        public void print()
        {
            if (Data != null)
            {
                for (int i = 0; i < nRow; i++)
                {
                    for (int j = 0; j < nCol; j++)
                    {
                        string line = string.Format(" {0, 8}", Data[i, j]);
                        Trace.Write(line);
                    }
                    Trace.WriteLine("");
                }
            }
        }

        public void print(string title)
        {
            if (Data != null)
            {
                if (title != "")
                {
                    Trace.WriteLine("\n" + title);
                }
                for (int i = 0; i < nRow; i++)
                {
                    for (int j = 0; j < nCol; j++)
                    {
                        string line = string.Format(" {0, 8}", Data[i, j]);
                        Trace.Write(line);
                    }
                    Trace.WriteLine("");
                }
            }
        }

    }
}