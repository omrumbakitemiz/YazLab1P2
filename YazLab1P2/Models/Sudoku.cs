using System.Collections.Generic;

namespace YazLab1P2.Models
{
    public class Sudoku
    {
        public List<Cell> cellList = new List<Cell>();

        public List<int> GetCol(int colNumber)
        {
            List<int> values = new List<int>();

            foreach (var cell in cellList)
            {
                if (cell.coordinate.col == colNumber)
                {
                    values.Add(cell.value);
                }
            }

            return values;
        }

        public List<int> GetRow(int rowNumber)
        {
            List<int> values = new List<int>();

            foreach (var cell in cellList)
            {
                if (cell.coordinate.row == rowNumber)
                {
                    values.Add(cell.value);
                }
            }

            return values;
        }

        public List<int> GetBox(int boxNumber)
        {
            List<int> values = new List<int>();

            foreach (var cell in cellList)
            {
                if (cell.coordinate.box == boxNumber)
                {
                    values.Add(cell.value);
                }
            }

            return values;
        }
    }
}
