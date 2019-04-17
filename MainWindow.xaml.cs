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
        string[,] dic = new string[3, 5];
        //string[,] dic = new string[26, 99999];
        public MainWindow()
        {
            InitializeComponent();
            ScrabbleGame sg = new ScrabbleGame();
            string tiles = sg.drawInitialTiles().ToString();
            MessageBox.Show(sg.drawInitialTiles());

            System.IO.StreamReader sr = new System.IO.StreamReader("dictSimple.txt");


            for (int i = 0; i < 26; i++)
            {
                int ii = 0;
                string dep = "";
                bool endletter = false;

                while (endletter == false)
                {

                    dic[i, ii] = sr.ReadLine();
                    if (dic[i, ii] != null)
                    {
                        dic[i, ii] = dic[i, ii].ToUpper();

                        if (ii == 0)
                        {
                            dep = dic[i, ii];
                        }

                        if (!dic[i, ii].Contains(dep))
                        { 
                            endletter = true;
                        }
                            ii++;
                        }
                        else
                        {
                            endletter = true;
                        }
                    Console.WriteLine(i + "," + ii);
                }
            }
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(txtInput.Text.Substring(0, 1), out int i);
            int.TryParse(txtInput.Text.Substring(3, txtInput.Text.Length - 3), out int ii);

            lblOutput.Content = dic[i, ii];
        }
    }
}
