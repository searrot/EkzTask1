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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Producer> producers;
        private Consumer consumer; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Random rnd1 = new Random(2015);
            Random rnd2 = new Random(1249);
            Random rnd3 = new Random(2500);
            Storage data = new Storage();
            producers = new List<Producer> { new Producer(0, data, rnd1), new Producer(1, data, rnd2) };
            producers[0].Start();
            producers[1].Start();
            consumer = new Consumer(0, data, rnd3);
            consumer.Start();
            MessageBox.Show("Запущено");
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            producers[0].Stop();
            producers[1].Stop();
            consumer.Stop();
            MessageBox.Show("Остановлено");
        }

        private void ButtonRecords_Click(object sender, RoutedEventArgs e)
        {
            RecordWindow recordWindow = new RecordWindow();
            recordWindow.Show();
            this.Hide();
        }

    }
}
