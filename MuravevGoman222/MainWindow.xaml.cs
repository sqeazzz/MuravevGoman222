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

namespace MuravevGoman222
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double x, b, xb, function, result;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", Name = "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk) == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonStart(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(InputX.Text, out x) || !double.TryParse(InputB.Text, out b))
            {
                MessageBox.Show("Неправильные значения x или b!");
                return;
            }
            xb = x * b;
            if (Fx.IsChecked == true)
            {
                function = Math.Pow(x, 2);
            }
            else if (Fe.IsChecked == true)
            {
                function = Math.Pow(Math.E, x);
            }
            else if (Fs.IsChecked == true)
            {
                function = Math.Sinh(x);
            }
            else
            {
                MessageBox.Show("Выберите функцию!");
                return;
            }

            if (xb > 1 && xb < 10)
            {
                result = Math.Pow(Math.E, function);
            }
            else if (xb > 12 && xb < 40)
            {
                result = Math.Sqrt(Math.Abs(function + 4 * b));
            }
            else
            {
                result = b * Math.Pow(function, 2);
            }
            OutputResult.Text = result.ToString();
        }

        private void ButtonReset(object sender, RoutedEventArgs e)
        {
            InputX.Text = ""; InputB.Text = ""; OutputResult.Text = "";
            Fx.IsChecked = false; Fe.IsChecked = false; Fs.IsChecked = false;
        }
    }
}
