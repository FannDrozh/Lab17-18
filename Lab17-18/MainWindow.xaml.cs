using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab17_18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void StartTheQuiz()
        {
            Random random = new Random();

            SumNumberOne.Text = random.Next(0, 20).ToString();
            SumNumberTwo.Text = random.Next(0, 20).ToString();

            MinNumberOne.Text = random.Next(0, 20).ToString();
            MinNumberTwo.Text = random.Next(0, 20).ToString();

            MulNumberOne.Text = random.Next(0, 20).ToString();
            MulNumberTwo.Text = random.Next(0, 20).ToString();

            DevNumberOne.Text = random.Next(0, 20).ToString();
            DevNumberTwo.Text = random.Next(0, 20).ToString();
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            StartTheQuiz();

            Timer timer = new Timer();
            timer.Start();

            for(int i = 6000; i >= 0; i--)
            {
                
            }
            timer.Stop();
        }
    }
}
