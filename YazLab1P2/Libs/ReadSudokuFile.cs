﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static YazLab1P2.Libs.Solver;

namespace YazLab1P2.Libs
{
    public class ReadSudokuFile
    {
        public  int[,] Read(string path)
        {
            Sudoku sudoku2 = new Sudoku();
            int[,] sudoku = new int[9, 9];
            
            StreamReader streamReader = new StreamReader(path);

            var digit = streamReader.ReadToEnd().Replace("\r", "").Replace('*', '0');

            for (int col = 0, row = 0, k = 0; k <=digit.Length - 1; k++)
            {
                int box = 0;
                if (digit[k] == '\n')
                {
                    row++;
                    col = 0;
                }
                else
                {
                    #region dünyanın en kötü kodu

                    if (row >= 0 && row <= 3 && col >= 0 && col <= 3)
                    {
                        // box1
                        box = 1;
                    }
                    else if (row >= 0 && row <= 3 && col >= 3 && col <= 6)
                    {
                        // box2
                        box = 2;
                    }
                    else if (row >=0 && row <=3 && col >=6 && col <=9)
                    {
                        //box3
                        box = 3;
                    }
                    else if (row >=3 && row <=6 && col >=0 && col <=3)
                    {
                        //box4
                        box = 4;
                    }
                    else if (row >=3 && row <=6 && col >=3 && col <=6)
                    {
                        //box5
                        box = 5;
                    }
                    else if (row >=3 && row <=6 && col >=6 && col <=9)
                    {
                        //box6
                        box = 6;
                    }
                    else if (row >=6 && row <=9 && col >=0 && col <=3)
                    {
                        //box7
                        box = 7;
                    }
                    else if (row >=6 && row <=9 && col >=3 && col <=6)
                    {
                        //box8
                        box = 8;
                    }
                    else if (row >=6 && row <=9 && col >=3 && col <=6)
                    {
                        //box9
                        box = 9;
                    }

                    #endregion

                    Cell cell = new Cell
                    {
                        value = Convert.ToInt32(digit[k].ToString()),
                        coordinate = new Coordinate { row = row, col = col, box = box }
                    };

                    sudoku2.cellList.Add(cell);

                    sudoku[row, col] = Convert.ToInt32(digit[k].ToString());
                    col++;
                }
            }

            return sudoku;
        }
    }
}