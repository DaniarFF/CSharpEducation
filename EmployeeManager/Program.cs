using EmployeeManager.Abstractions;
using EmployeeManager.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook;

namespace EmployeeManager
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var cfg = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
      var settings = cfg.GetSection("App").Get<ApplicationSettings>();
      IServiceCollection services = new ServiceCollection();

      services.AddSingleton(settings);
      services.AddTransient<IEmployeeRepository<EmployeeEntity>, EmployeeRepository<EmployeeEntity>>();
      services.AddTransient<IEmployeeManager<Employee>, EmployeeManager<Employee>>();

      var serviceProvider = services.BuildServiceProvider();

      var employeeService = serviceProvider.GetRequiredService<IEmployeeManager<Employee>>();

      bool running = true;
      while (running)
      {
        Console.WriteLine("\n1.Добавить полного сотрудника\n" +
            "2.Добавить частичного сотрудника\n" +
            "3.Получить информацию о сотруднике\n" +
            "4.Выйти");

        switch (Console.ReadLine())
        {
          case "1":
            AddEmployee(employeeService, 1);
            break;
          case "2":
            AddEmployee(employeeService, 2);
            break;
          case "3":
            GetEmployee(employeeService);
            break;
          case "4":
            running = false;
            break;
          default:
            break;
        }
      }
    }

    internal static void AddEmployee(IEmployeeManager<Employee> employeeService, int employeeType)
    {
      try
      {
        if (employeeType == 1)
        {
          Employee employee = new FullTimeEmployee();
          Console.WriteLine("Введите имя сотрудника:");
          employee.Name = Console.ReadLine();
          Console.WriteLine("Введите зарплату сотрудника:");
          if (decimal.TryParse(Console.ReadLine(), out decimal salary))
          {
            employee.Salary = salary;
          }
          else
          {
            Console.WriteLine("Не правильная зп");
          }
          employeeService.Add(employee);
        }
        if (employeeType == 2)
        {
          PartTimeEmployee employee = new PartTimeEmployee();

          Console.WriteLine("Введите имя сотрудника:");
          employee.Name = Console.ReadLine();

          Console.WriteLine("Введите оплату по часам:");
          if (decimal.TryParse(Console.ReadLine(), out decimal hourlyRate))
          {
            employee.HourlyRate = hourlyRate;
          }

          Console.WriteLine("Введите кол-во отработанных часов:");
          if (double.TryParse(Console.ReadLine(), out double workingHours))
          {
            employee.WorkingHours = workingHours;
          }
          employeeService.Add(employee);
        }
      }
      catch
      {
        Console.WriteLine("Ошибка добавления сотрудника");
      }
    }

    internal static void GetEmployee(IEmployeeManager<Employee> employeeService)
    {
      Console.WriteLine("Введите имя сотрудника");
      string name = Console.ReadLine();

      try
      {
        if (!string.IsNullOrEmpty(name))
        {
          var employee = employeeService.Get(name);

          if (employee is FullTimeEmployee)
            Console.WriteLine($"Имя сотрудника: {employee.Name}\nЗарплата сотрудника (Ставка): {employee.CalculateSalary()}");
          if (employee is PartTimeEmployee)
            Console.WriteLine($"Имя сотрудника: {employee.Name}\nЗарплата сотрудника (Почасовая оплата): {employee.CalculateSalary()}");

          Console.WriteLine("\n1.Изменить данные сотрудника\n" +
              "2.Выйти\n");
          switch (Console.ReadLine())
          {
            case "1":
              UpdateEmployee(employeeService, employee);
              break;
            case "2":
              break;
          }
        }
      }
      catch 
      {
        Console.WriteLine("Ошибка получения сотрудника");
      }
    }

    internal static void UpdateEmployee(IEmployeeManager<Employee> employeeService, Employee employee)
    {
      if (employee is PartTimeEmployee partTimeEmployee)
      {
        Console.WriteLine("Введите новую оплату по часам:");
        if (decimal.TryParse(Console.ReadLine(), out decimal hourlyRate))
        {
          partTimeEmployee.HourlyRate = hourlyRate;
        }
        Console.WriteLine("Введите кол-во отработанных часов:");
        if (double.TryParse(Console.ReadLine(), out double workingHours))
        {
          partTimeEmployee.WorkingHours = workingHours;
        }
        employeeService.Update(partTimeEmployee);
      }
      if (employee is FullTimeEmployee fullTimeEmployee)
      {
        Console.WriteLine("Введите новую зарплату сотрудника:");
        if (decimal.TryParse(Console.ReadLine(), out decimal salary))
        {
          fullTimeEmployee.Salary = salary;
        }
        employeeService.Update(fullTimeEmployee);
      }
    }
  }
}
