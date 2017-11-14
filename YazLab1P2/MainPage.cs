using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YazLab1P2.Libs;
using YazLab1P2.Models;

namespace YazLab1P2
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();

            Sudoku sudoku = new Sudoku();

            Bitmap image = new Bitmap(@"C:\Users\immino\Desktop\YazLab1P2ll\YazLab1P2-master\resim1.png");
            pictureBox1.Image = image;

            ReadSudokuFile reader = new ReadSudokuFile();
            sudoku = reader.Read(@"C:\Users\immino\Desktop\YazLab1P2ll\YazLab1P2-master\ornek1\sudoku.txt");
            
            Graphics graphics = Graphics.FromImage(image);
            Font myFont = new Font("Arial", 14);
            
            for (int i = 0, index = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    graphics.DrawString(sudoku.cellList[index].value.ToString(), myFont, Brushes.Black, new Point(12 + j * 60, 14 + i * 60));
                    index++;
                }
            }

            foreach (var item in sudoku.cellList)
            {
                Console.WriteLine(item.value);
            }
        }
    }
}
