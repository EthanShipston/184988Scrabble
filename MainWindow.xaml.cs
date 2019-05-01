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
            MessageBox.Show(tiles);
            string[] tilesAr = new string[7];
            string[] wordsAr = new string[26];

            for (int i = 0; i < 7; i++)
            {
                tilesAr[i] = tiles.Substring(i, 1);
            }

            System.IO.StreamReader sr = new System.IO.StreamReader("Dictionary.txt");

            string dep = sr.ReadLine();
            int iii = 0;
            for (int i = 0; i < 235882; i++)
            {
                string temp = "Not Null Idiot";
                temp = sr.ReadLine();
                temp = temp.ToUpper();
                wordsAr[iii] = dep + ": ";

                if (temp.Length <= 7)
                {
                    if (temp.Contains(dep))
                    {
                        string testWord = temp;
                        int wildcards = 0;
                        int missingLetters = 0;

                        for (int ii = 0; ii < 7; ii++)
                        {
                            if (tilesAr[ii] == " ")
                            {
                                wildcards++;
                            }
                            if (testWord.Contains(tilesAr[ii]))
                            {
                                testWord = testWord.Remove(testWord.IndexOf(tilesAr[ii]));
                            }
                            else
                            {
                                missingLetters++;
                            }
                        }

                        if (!wordsAr[iii].Contains(temp))
                        {
                            if (wildcards >= missingLetters || missingLetters == 0)
                            {
                                wordsAr[iii] += temp + ", ";
                            }
                        }
                    }
                    else
                    {
                        dep = temp;
                        iii++;
                    }
                }
            }
        }
    }
}
