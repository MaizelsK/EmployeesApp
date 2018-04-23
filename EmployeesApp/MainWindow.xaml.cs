using System;
using System.Collections;
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

namespace EmployeesApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillDataBase();

            DataGrid.ItemsSource = GetData();
        }

        private void FillDataBase()
        {
            List<Company> companies = new List<Company>
            {
                new Company
                {
                    Id = Guid.NewGuid(), Name = "Microsoft", Divisions = new List<Division>
                    {
                        new Division {Id = Guid.NewGuid(), Name = "Головной отдел", Employees = new List<Employee>
                        {
                            new Employee {Id = Guid.NewGuid(), FullName="Bob", BirthDate = new DateTime(1970, 12, 31)},
                            new Employee {Id = Guid.NewGuid(), FullName="Alex", BirthDate = new DateTime(1987, 8, 12)},
                        }},
                        new Division {Id = Guid.NewGuid(), Name = "Программисты", Employees = new List<Employee>
                        {
                            new Employee {Id = Guid.NewGuid(), FullName="Tom", BirthDate = new DateTime(1986, 2, 3)},
                            new Employee {Id = Guid.NewGuid(), FullName="Thiem", BirthDate = new DateTime(1988, 7, 1)},
                        }},
                    }
                },
                new Company
                {
                    Id = Guid.NewGuid(), Name = "Google", Divisions = new List<Division>
                    {
                        new Division {Id = Guid.NewGuid(), Name = "Головной отдел", Employees = new List<Employee>
                        {
                            new Employee {Id = Guid.NewGuid(), FullName="Martha", BirthDate = new DateTime(1973, 5, 16)},
                            new Employee {Id = Guid.NewGuid(), FullName="Alex", BirthDate = new DateTime(1989, 9, 11)},
                        }},
                        new Division {Id = Guid.NewGuid(), Name = "Программисты", Employees = new List<Employee>
                        {
                            new Employee {Id = Guid.NewGuid(), FullName="Artem", BirthDate = new DateTime(1992, 4, 4)},
                            new Employee {Id = Guid.NewGuid(), FullName="Thiem", BirthDate = new DateTime(1993, 5, 5)},
                        }},
                    }
                },
                new Company
                {
                    Id = Guid.NewGuid(), Name = "Telegram", Divisions = new List<Division>
                    {
                        new Division {Id = Guid.NewGuid(), Name = "Головной отдел", Employees = new List<Employee>
                        {
                            new Employee {Id = Guid.NewGuid(), FullName="Dmitri", BirthDate = new DateTime(1972, 1, 31)},
                            new Employee {Id = Guid.NewGuid(), FullName="Pavel", BirthDate = new DateTime(1987, 2, 16)},
                        }},
                        new Division {Id = Guid.NewGuid(), Name = "Программисты", Employees = new List<Employee>
                        {
                            new Employee {Id = Guid.NewGuid(), FullName="Michail", BirthDate = new DateTime(1986, 3, 3)},
                            new Employee {Id = Guid.NewGuid(), FullName="Alexey", BirthDate = new DateTime(1988, 6, 25)},
                        }},
                    }
                },
            };

            using (var context = new CompanyContext())
            {
                context.Companies.AddRange(companies);
                context.SaveChanges();
            }
        }

        private List<Company> GetData()
        {
            using (var context = new CompanyContext())
            {
                return context.Companies.ToList();
            }
        }

        private void CompanyButtonClick(object sender, RoutedEventArgs e)
        {
            Company selectedCompany = DataGrid.Items[DataGrid.SelectedIndex] as Company;

            Window divisions = new Divisions(selectedCompany);
            divisions.ShowDialog();
        }
    }
}
