using System;
using System.Collections.Generic;

namespace EmployeesApp
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set;}

        public virtual List<Division> Divisions { get; set; }
    }
}