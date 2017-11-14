using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using YazLab1P2.Models;

namespace YazLab1P2.Libs
{
    public class Solver
    {
        public List<int> CalculatePossibility(Sudoku sudoku, int cellIndex)
        {
            List<int> possibilities = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            if (sudoku.cellList[cellIndex].value == 0)
            {
                int col = sudoku.cellList[cellIndex].coordinate.col;
                int row = sudoku.cellList[cellIndex].coordinate.row;
                int box = sudoku.cellList[cellIndex].coordinate.box;

                List<int> colValues = sudoku.GetCol(col);
                List<int> rowValues = sudoku.GetRow(row);
                List<int> boxValues = sudoku.GetBox(box);

                foreach (var value in colValues)
                {
                    possibilities.Remove(value);
                }

                foreach (var value in rowValues)
                {
                    possibilities.Remove(value);
                }

                foreach (var value in boxValues)
                {
                    possibilities.Remove(value);
                }
            }

            return possibilities;
        }

        public Sudoku Solve(Sudoku sudoku)
        {
            Stopwatch watch = Stopwatch.StartNew();

            for (int cellIndex = 0; cellIndex < sudoku.cellList.Count; cellIndex++)
            {
                if (sudoku.cellList[cellIndex].value == 0)
                {
                    List<int> possibilities = CalculatePossibility(sudoku, cellIndex);

                    if (possibilities.Count == 1)
                    {
                        sudoku.cellList[cellIndex].value = possibilities[0];

                        cellIndex = -1;
                    }
                }
            }

            watch.Stop();
            long elapsedMs = watch.ElapsedMilliseconds;
            MessageBox.Show("Çalışma süresi:" + elapsedMs);

            return sudoku;
        }
    }
}
