using System.Collections.Generic;

namespace YazLab1P2.Libs
{
    public class Solver
    {
        public struct Coordinate
        {
            public int col, row, box;
        }

        public class Cell
        {
            public Coordinate coordinate;
            public int value;
        }

        public class Sudoku
        {
            public Sudoku()
            {

            }

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

        public void CalculatePossibility(Sudoku sudoku, int sudokuIndex)
        {
            if (sudoku.cellList[sudokuIndex].value == 0)
            {
                List<int> allPossibilities = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                
                int col = sudoku.cellList[sudokuIndex].coordinate.col;
                int row = sudoku.cellList[sudokuIndex].coordinate.row;
                int box = sudoku.cellList[sudokuIndex].coordinate.box;

                List<int> colValues = sudoku.GetCol(col);
                List<int> rowValues = sudoku.GetRow(row);
                List<int> boxValues = sudoku.GetBox(box);

                foreach (var value in colValues)
                {
                    allPossibilities.Remove(value);
                }

                foreach (var value in rowValues)
                {
                    allPossibilities.Remove(value);
                }

                foreach (var value in boxValues)
                {
                    allPossibilities.Remove(value);
                }
            }
        }

        public void Task(Sudoku sudoku)
        {
            for (int i = 0; i < sudoku.cellList.Count; i++)
            {
                if (sudoku.cellList[i].value == 0)
                {
                    CalculatePossibility(sudoku, i);

                    i = -1;
                }
            }
        }

        public int[,] sudoku = new int[9, 9];
        
        public bool Solve(int[,] sudoku1)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    sudoku[i, j] = sudoku1[i, j];

                    //hucreIhtimalleri = new Dictionary<Koordinat, int[]>();

                    //Koordinat koordinat1 = new Koordinat { row = 1, col = 1, box = 1 };
                    //int[] ihtimal1 = new int[] { 1, 2, 3, 4, 6, };

                    //hucreIhtimalleri.Add(koordinat1, ihtimal1);
                }
            }
           
            return false;
        }
        private bool UsedInRow(int[,] sudoku, int row, int digit)
        {
            bool result = false;

            for (int digitIndex = 0; digitIndex < 9; digitIndex++)
            {
                if (sudoku[row - 1, digitIndex] == digit)
                {
                    result = true;
                }
            }

            return result;
        }
        private bool UsedInCol(int[,] sudoku, int col, int digit)
        {
            bool result = false;

            for (int digitIndex = 0; digitIndex < 9; digitIndex++)
            {
                if (sudoku[digitIndex, col - 1] == digit)
                {
                    result = true;
                }
            }

            return result;
        }
        private bool UsedInBox(int[,] sudoku, int boxIndexX, int boxIndexY, int digit)
        {
            bool sonuc = false;

            for (int i = boxIndexX; i < (boxIndexX + 3); i++)
            {
                for (int j = boxIndexY; j < (boxIndexY + 3); j++)
                {
                    if (sudoku[i, j] == digit)
                    {
                        return true;
                    }
                }
            }

            return sonuc;
        }
    }
}
