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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для RecordWindow.xaml
    /// </summary>
    public partial class RecordWindow : Window
    {
        private RecordViewModel recordViewModel = new RecordViewModel();
        public RecordWindow()
        {
            InitializeComponent();
            RecordList.ItemsSource = recordViewModel.Records;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            recordViewModel.LoadUsers();
        }
        
    }
}
