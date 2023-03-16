using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using WpfApp1.Windows;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Teacher> _Data = new ObservableCollection<Teacher>();
       
        public MainWindow()
        {  
            InitializeComponent();   
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Teacher s = ((Teacher)datagrid.SelectedItem);

            datagrid.Items.Remove(s);
        }

        private void openwindow_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            
            window1.Show();
            
            
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files (*.json)|*.json";
            openFileDialog.ShowDialog();
            if (string.IsNullOrEmpty(openFileDialog.FileName))
            {
                return;
            }
            string json = File.ReadAllText(openFileDialog.FileName);

            try
            {
                _Data = JsonSerializer.Deserialize<ObservableCollection<Teacher>>(json);
                foreach (Teacher teacher in _Data)
                {
                    datagrid.Items.Add(teacher);
                }
            }
            catch (System.Text.Json.JsonException)
            {
                MessageBox.Show("Ошибка при попытке открыть выбранный json файл");
            }
            
            
        }
    }
    
}
