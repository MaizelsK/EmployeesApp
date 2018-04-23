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

namespace EmployeesApp
{
    /// <summary>
    /// Логика взаимодействия для Divisions.xaml
    /// </summary>
    public partial class Divisions : Window
    {
        Company Company { get; set; }

        public Divisions(Company company)
        {
            InitializeComponent();
            Company = company;

            using (var context = new CompanyContext())
            {
                DataGrid.ItemsSource = context.Divisions.Where(x => x.Company.Id == Company.Id).ToList();
            }
        }

        private void DivisionButtonClick(object sender, RoutedEventArgs e)
        {
            Division selectedDivision = DataGrid.Items[DataGrid.SelectedIndex] as Division;

            Window employees = new Employees(selectedDivision);
            employees.ShowDialog();
        }
    }
}
