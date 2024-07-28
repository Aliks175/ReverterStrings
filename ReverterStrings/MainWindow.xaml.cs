using System;
using System.Windows;

namespace ReverterStrings
{
    public partial class MainWindow : Window
    {
        string[] word;
        string tempText;

        public MainWindow()
        {
            InitializeComponent();
            OutTextSpliter.ItemsSource = new string[] { "Результат..." };
        }

        private string[] SplitText(string text)
        {
            char[] separators = new char[] { ' ', '.', ',', '?', '!' };
            word = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return word;
        }

        private string Reverse(string text)
        {
            string resultString = null;
            word = SplitText(text);
            for (int i = word.Length; i > 0; i--)
            {
                if (word[i - 1] != null)
                {
                    resultString += word[i - 1] + ' ';
                }
            }
            return resultString;
        }


        private void ClearButtonSplit(object sender, RoutedEventArgs e)
        {
            InputTextSpliter.Text = "Введите Ваш текст";
            OutTextSpliter.ItemsSource = new string[] { "Результат..." };
        }

        private void ClearButtonRevert(object sender, RoutedEventArgs e)
        {
            InputTextRevert.Text = "Введите Ваш текст";
            OutTextRevert.Content = "Результат...";
        }

        private void ButtonRevert(object sender, RoutedEventArgs e)
        {
            tempText = InputTextRevert.Text;
            OutTextRevert.Content = Reverse(tempText);
        }

        private void ButtonSplit(object sender, RoutedEventArgs e)
        {
            tempText = InputTextSpliter.Text;
            string[] strings = SplitText(tempText);
            OutTextSpliter.ItemsSource = strings;
        }
    }
}
