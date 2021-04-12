using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MagicSquare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //из «ПРИЕЗЖАЮ ВОСЬМОГО», шифровка «ОИРМЕОСЮ ВТАЬЛГОП»
        List<int> magic_square1 = new List<int> { 16, 3, 2, 13, 5, 10, 11, 8, 9, 6, 7, 12, 4, 15 ,14, 1 };
        List<int> magic_square2 = new List<int> { 1, 15, 14, 4, 12, 6, 7, 9, 8, 10, 11, 5, 13, 3, 2, 16 };
        public MainWindow()
        {
            InitializeComponent();
        }

        private int MagicSquareChoose()
        {
            if ((bool)RB1.IsChecked)
            {
                return 1;
            }

            if ((bool)RB2.IsChecked)
            {
                return 2;
            }
            return 0;
        }

        private void FillGrid(List<char> letters)
        {
            try
            {
                Tb1.Text = letters[0].ToString();
                Tb2.Text = letters[1].ToString();
                Tb3.Text = letters[2].ToString();
                Tb4.Text = letters[3].ToString();
                Tb5.Text = letters[4].ToString();
                Tb6.Text = letters[5].ToString();
                Tb7.Text = letters[6].ToString();
                Tb8.Text = letters[7].ToString();
                Tb9.Text = letters[8].ToString();
                Tb10.Text = letters[9].ToString();
                Tb11.Text = letters[10].ToString();
                Tb12.Text = letters[11].ToString();
                Tb13.Text = letters[12].ToString();
                Tb14.Text = letters[13].ToString();
                Tb15.Text = letters[14].ToString();
                Tb16.Text = letters[15].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        private string encodeText(string sourceText, List<int> square)
        {
            List<char> letters = new List<char>();
            for (int i = 0; i < square.Count; i++)
            {
                sourceText = Regex.Replace(sourceText, @"\s+", "");
                if (sourceText.Count() < 16)
                {
                    while (sourceText.Count() < 16)
                    {
                        sourceText += ' ';
                    }
                }
                try
                {
                    var letter = sourceText[square[i] - 1];
                    letters.Add(letter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            FillGrid(letters);
            return new string(letters.ToArray());
        }

        private string decodeText(string encodedText, List<int> square)
        {
            List<char> letters = new List<char>();
            for (int i = 0; i < square.Count; i++)
            {
                // encodedText = Regex.Replace(encodedText, @"\s+", "");
                try
                {
                    var letter = encodedText[square[i] - 1];
                    letters.Add(letter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return new string(letters.ToArray());
        }

        private void BtnEnc_OnClick(object sender, RoutedEventArgs e)
        {
            if (MagicSquareChoose() == 1)
            {
                TextBoxEnc.Text = encodeText(TextBoxSource.Text, magic_square1);
            }

            else if (MagicSquareChoose() == 2)
            {
                TextBoxEnc.Text = encodeText(TextBoxSource.Text, magic_square2);
            }
            else
            {
                MessageBox.Show("Выберите квадрат");
            }
        }

        private void BtnDec_OnClick(object sender, RoutedEventArgs e)
        {
            if (MagicSquareChoose() == 1)
            {
                TextBoxSource.Text = decodeText(TextBoxEnc.Text, magic_square1);
            }

            else if (MagicSquareChoose() == 2)
            {
                TextBoxSource.Text = decodeText(TextBoxEnc.Text, magic_square2);
            }
            else
            {
                MessageBox.Show("Выберите квадрат");
            }
        }
    }
}
