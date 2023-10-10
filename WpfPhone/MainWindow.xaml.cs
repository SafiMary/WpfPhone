using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfPhone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string text;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNumeric_Click(object sender, RoutedEventArgs e)
        {
            if (texbBoxInput.Text.Length < 13)// запрет на добавления номера более 11 цифр
            {
                texbBoxInput.Text += ((Button)sender).Content.ToString();
                text = texbBoxInput.Text;//содержимое текстбкса сложили в строку
            }
            else { texbBoxInput.Text += ""; }
               
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)//кнопка очищение окошка ввода
        {
            texbBoxInput.Text = "+7";
        }
        private void btnCall_Click(object sender, RoutedEventArgs e)//кнопка очищение окошка ввода
        {
            MessageBox.Show("Вызов....");
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)//ввод только цифр и удаление
        {
            int val;
            if (!Int32.TryParse(e.Text, out val) && e.Text.Length > 13)// запрет на добавления номера более 11 цифр
            {
                e.Handled = true; // отклоняем ввод
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true; // если пробел, отклоняем ввод
            }
            if (e.Key == Key.Enter)
            {
                MessageBox.Show("Вызов...."); // если Enter, вызов абонента
            }

        }



    }
}
