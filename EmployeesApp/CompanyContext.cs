﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("CompanyDb") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
