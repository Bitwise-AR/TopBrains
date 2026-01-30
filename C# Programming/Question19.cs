using System;
using System.Collections.Generic;
using System.Globalization;

abstract class Employee
{
    public abstract decimal GetPay();
}

class HourlyEmployee : Employee
{
    private decimal rate;
    private decimal hours;

    public HourlyEmployee(decimal rate, decimal hours)
    {
        this.rate = rate;
        this.hours = hours;
    }

    public override decimal GetPay()
    {
        return rate * hours;
    }
}

class SalariedEmployee : Employee
{
    private decimal monthlySalary;

    public SalariedEmployee(decimal monthlySalary)
    {
        this.monthlySalary = monthlySalary;
    }

    public override decimal GetPay()
    {
        return monthlySalary;
    }
}

class CommissionEmployee : Employee
{
    private decimal commission;
    private decimal baseSalary;

    public CommissionEmployee(decimal commission, decimal baseSalary)
    {
        this.commission = commission;
        this.baseSalary = baseSalary;
    }

    public override decimal GetPay()
    {
        return baseSalary + commission;
    }
}

class Program
{
    static void Main()
    {
        string[] employees =
        {
            "H 50 160",
            "S 4000",
            "C 500 3000"
        };

        decimal totalPay = CalculateTotalPayroll(employees);
        Console.WriteLine(totalPay);
    }

    static decimal CalculateTotalPayroll(string[] employees)
    {
        decimal total = 0;

        foreach (string emp in employees)
        {
            Employee employee = ParseEmployee(emp);
            if (employee != null)
            {
                total += employee.GetPay();
            }
