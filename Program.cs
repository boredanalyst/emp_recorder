using System;
using System.Collections.Generic;

List<Employee> list_emp = new List<Employee>(); 

ShowMenu();

void ShowMenu()
{
    string[] mainmenu_options = { "Add Employee", "Exit" };

    for (int i = 0; i < mainmenu_options.Length; i++)
    {
        Console.Write((i + 1) + " ");
        Console.WriteLine(mainmenu_options[i]);
    }

    int menu_choice;

    if (int.TryParse(Console.ReadLine(), out menu_choice))
    {
        menu_choice -= 1;
        switch (menu_choice)
        {
            case 0:
                Console.WriteLine("You are adding an employee.");
                addEmployee();
                break;
            case 1:
                Console.WriteLine("You are closing this program.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Please provide a valid input.");
    }
}

void addEmployee()
{
    Console.WriteLine("------ADD EMPLOYEE---------");

    Console.WriteLine("Please provide the employee's FIRST NAME.");
    string first_name;
    first_name = Console.ReadLine();

    Console.WriteLine("Please provide the employee's LAST NAME.");
    string last_name;
    last_name = Console.ReadLine();

    Console.WriteLine("Please provide the employee's age.");
    int emp_age = 0;
    
    while (emp_age == 0)
    {
        if (int.TryParse(Console.ReadLine(), out emp_age))
        {

        }
        else
        {
            Console.WriteLine("Please provide a valid input.");
        }
    }

    Employee emp = new Employee(first_name, last_name, emp_age);
    list_emp.Add(emp);
    foreach (Employee employee in list_emp)
    {
        Console.WriteLine($"{employee.FirstName} {employee.LastName} is {employee.Age}.");
    }
    confirmRetype();
}

void confirmRetype()
{
    string user_input = "";

    Console.WriteLine("-------------------");
    Console.WriteLine("Do you want to add a new employee?");
    user_input = Console.ReadLine();
    user_input = user_input.ToUpper();
        if (user_input == "YES")
        {
            user_input = "";
            addEmployee();
        }
        else if (user_input == "NO")
        {
            user_input = "";
            ShowMenu();
        }
        else
        {
        Console.WriteLine("Please provide a valid input.");
        confirmRetype();
        }
}

public class Employee
{
    string _fname;
    string _lname;
    int _age;

    public Employee(string fname,string lname,int age)
    {
        _fname = fname;
        _lname = lname;
        _age = age;
    }

    public string FirstName
    {
        get => _fname;
        set => _fname = value;
    }

    public string LastName
    {
        get => _lname;
        set => _lname = value;
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value >= 18)
            {
                _age = value;
            } else
            {
                Console.WriteLine("Employee must be or older than 18 years old.");
            }
        }
    }
}
