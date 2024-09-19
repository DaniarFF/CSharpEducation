using EmployeeManager.Abstractions;

namespace EmployeeManager
{
  public class EmployeeManager<T> : IEmployeeManager<Employee>
  {
    IEmployeeRepository<EmployeeEntity> repository;

    #region Методы

    public void Add(Employee employee)
    {
      if (employee is PartTimeEmployee partTimeEmployee)
      {
        EmployeeEntity employeeEntity = new EmployeeEntity()
        {
          Name = partTimeEmployee.Name,
          HourlyRate = partTimeEmployee.HourlyRate,
          WorkingHours = partTimeEmployee.WorkingHours,
          Salary = 0,
        };

        repository.Add(employeeEntity);
      }
      else if (employee is FullTimeEmployee fullTimeEmployee)
      {
        EmployeeEntity employeeEntity = new EmployeeEntity()
        {
          Name = fullTimeEmployee.Name,
          HourlyRate = 0,
          WorkingHours = 0,
          Salary = fullTimeEmployee.Salary,
        };

        repository.Add(employeeEntity);
      }
    }

    public Employee Get(string name)
    {
      var entity = repository.Get(name);

      if (entity.HourlyRate == 0)
      {
        FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
        {
          Name = entity.Name,
          Salary = entity.Salary,
        };

        return fullTimeEmployee;
      }

      PartTimeEmployee employee = new PartTimeEmployee()
      {
        Name = entity.Name,
        Salary = entity.Salary,
        WorkingHours = entity.WorkingHours,
        HourlyRate = entity.HourlyRate,
      };

      return employee;
    }

    public void Update(Employee employee)
    {
      if (employee is FullTimeEmployee fullTimeEmployee)
      {
        EmployeeEntity employeeEntity = new EmployeeEntity()
        {
          Name = fullTimeEmployee.Name,
          Salary = fullTimeEmployee.Salary
        };
        repository.Update(employeeEntity);
      }

      if (employee is PartTimeEmployee partTimeEmployee)
      {
        EmployeeEntity employeeEntity = new EmployeeEntity()
        {
          Name = partTimeEmployee.Name,
          WorkingHours = partTimeEmployee.WorkingHours,
          HourlyRate = partTimeEmployee.HourlyRate
        };
        repository.Update(employeeEntity);
      }
    }

    #endregion

    #region Констукторы

    public EmployeeManager(IEmployeeRepository<EmployeeEntity> repository)
    {
      this.repository = repository;
    } 

    #endregion
  }
}
