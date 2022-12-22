using Lab.Model;
using Laba.BusinessLogic.Services;
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

namespace WPFWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeService _employeeService;
        public MainWindow()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            laba2.ItemsSource = _employeeService.Get();
        }
        private void AddNewEmployee_Clicked(object sender, RoutedEventArgs e)
        {
            AddEmployee win = new AddEmployee();
            win.Show();
        }
        private void UpdateGrid()
        {
            laba2.ItemsSource = null;
            laba2.ItemsSource = _employeeService.Get();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

            if (laba2.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < laba2.SelectedItems.Count; i++)
                {
                    Employee employee = laba2.SelectedItems[i] as Employee;
                    if (employee != null)
                    {
                        _employeeService.Deleted(employee);
                    }
                }
            }
            UpdateGrid();

        }
        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            _employeeService.Update(e.Row.Item as Employee);
            UpdateGrid();
        }
    }
}
