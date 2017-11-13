using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazLab1P2.Libs;
using static YazLab1P2.Libs.Solver;

namespace YazLab1P2
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            int[,] sudokuValues = new int[9, 9];
            Bitmap img = new Bitmap(@"C:\Users\immino\Desktop\YazLab1P2ll\YazLab1P2-master\resim.jpg");
            pictureBox1.Image = img;

            ReadSudokuFile reader = new ReadSudokuFile();
            sudokuValues = reader.Read(@"C:\Users\immino\Desktop\YazLab1P2ll\YazLab1P2-master\ornek2\sudoku.txt");
            
            int a = 3;
            int temp;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    temp = sudokuValues[j,i];
                    sudokuValues[j, i] = sudokuValues[i, j];
                    sudokuValues[i, j] = temp;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (sudokuValues[j,i] != 0)
                    {
                        Graphics g = Graphics.FromImage(img);
                        using (Font myFont = new Font("Arial", 20))
                        {
                            if (sudokuValues[j,i] != 0)
                            {
                                g.DrawString(sudokuValues[j,i].ToString(), myFont, Brushes.Green, new Point(a + i * 57, a + j * 57));
                            }
                        }
                        pictureBox1.Image = img;
                    }
                }
            }

            //Sudoku sudoku = new Sudoku();

            //#region ReadFile

            //StreamReader streamReader = new StreamReader(path);

            //var digit = streamReader.ReadToEnd().Replace("\r", "").Replace("*", "0");
            

            //#endregion

            Solver solver = new Solver();
            solver.Solve(sudokuValues);



            //solver.Task(sudoku);
        }
    }
}
