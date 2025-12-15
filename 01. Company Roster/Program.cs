using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }

    public Employee(string name, decimal salary, string department)
    {
        Name = name;
        Salary = salary;
        Department = department;
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = data[0];
            decimal salary = decimal.Parse(data[1]);
            string department = data[2];

            employees.Add(new Employee(name, salary, department));
        }

        var bestDepartment = employees
            .GroupBy(e => e.Department)
            .OrderByDescending(d => d.Average(e => e.Salary))
            .First();

        Console.WriteLine($"Highest Average Salary: {bestDepartment.Key}");

        foreach (var employee in bestDepartment.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
        }
    }
}
