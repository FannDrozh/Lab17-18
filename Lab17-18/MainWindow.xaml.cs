using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
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
        DispatcherTimer timer = new DispatcherTimer();
        private int start = new int();
        private int CheckPosition = 0;
        private bool ButtonStateCheck = false;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
        }
        private void StartStopBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonStateCheck == false)
            {
                if (CheckPosition == 0)
                {
                    start = Properties.Settings.Default.TimerStart;
                }
                else if (CheckPosition != 0)
                {
                    start = CheckPosition;
                }
                timer.Start();
                StartTheQuiz();
                ButtonStateCheck = true;

            }
            else if (ButtonStateCheck == true)
            {
                CheckPosition = start;
                ButtonStateCheck = false;
                timer.Stop();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (start > 0)
            {
                start--;
                Time.Text = Convert.ToString(start);
            }
            else if (start <= 0)
            {
                timer.Stop();
                CheckPosition = 0;
                ButtonStateCheck = false;
            }
        }
        private void timerTxb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex InputChecker = new System.Text.RegularExpressions.Regex("[^0-59]+");
            e.Handled = InputChecker.IsMatch(e.Text);
        }
        private void SetTimeBtn_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.TimerStart = Int32.Parse(Time.Text);
            this.Close();
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
    }
}
