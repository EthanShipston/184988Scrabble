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
        string[,] dic = new string[26, 30000];
        //string[,] dic = new string[26, 99999];
        public MainWindow()
        {
            InitializeComponent();
            ScrabbleGame sg = new ScrabbleGame();
            string tiles = sg.drawInitialTiles().ToString();
            MessageBox.Show(sg.drawInitialTiles());

            System.IO.StreamReader sr = new System.IO.StreamReader("Dictionary.txt");

            bool test = false;
            string dep = "";
            for (int i = 0; i < 26; i++)
            {
                int ii = 0;
                bool endletter = false;


                while (endletter == false)
                {
                    if (test == true)
                    {
                        ii++;
                        test = false;
                    }

                    else
                    {
                        dic[i, ii] = sr.ReadLine();

                        if (dic[i, ii] != null)
                        {
                            if (dic[i, ii].Length > 7)
                            {
                                dic[i, ii] = null;
                            }
                            else
                            {
                                dic[i, ii] = dic[i, ii].ToUpper();

                                if (ii == 0)
                                {
                                    dep = dic[i, ii];
                                }

                                if (!dic[i, ii].Contains(dep))
                                {
                                    endletter = true;
                                    dic[i + 1, 0] = dic[i, ii];
                                    dep = dic[i, ii];
                                    dic[i, ii] = null;
                                    test = true;
                                }
                                ii++;
                                Console.WriteLine(i + "," + ii);
                            }
                        }
                        else
                        {
                            endletter = true;
                        }
                    }
                }
            }
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            /*
            string input = txtInput.Text;
            string first = input.Substring(0, input.IndexOf(","));
            string last = input.Substring(input.IndexOf(",") + 1);

            int.TryParse(first, out int i);
            int.TryParse(last, out int ii);

            lblOutput.Content = dic[i, ii];
            */



        }

    }
}
