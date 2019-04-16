/* Ethan Shipston
 * 184988Scrabble
 * 4/16/2019
 * A program which finds all possible words given a dictionary and a handfull of letters (it helps you cheat at scrabble)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _184988Scrabble
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ScrabbleGame sg = new ScrabbleGame();
            string tiles = sg.drawInitialTiles().ToString();
            MessageBox.Show(sg.drawInitialTiles());

            string dic = "";
            System.IO.StreamReader sr = new System.IO.StreamReader("Dictionary.txt");

            while (!sr.EndOfStream)
            {
                dic += sr.ReadLine();
                
            }
            Console.WriteLine(dic);
        }
    }
}
