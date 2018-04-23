using System;
using System.Collections.Generic;

namespace EmployeesApp
{
    public class Division
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual Company Company { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}