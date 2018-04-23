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
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Window
    {
        public Division Division { get; set; }

        public Employees(Division division)
        {
            InitializeComponent();
            Division = division;

            using (var context = new CompanyContext())
            {
                Division findedDivision = context.Divisions.SingleOrDefault(x => x.Id == Division.Id);
                DataGrid.ItemsSource = findedDivision.Employees;
            }
        }
    }
}
