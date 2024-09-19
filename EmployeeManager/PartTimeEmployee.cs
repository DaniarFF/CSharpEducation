using EmployeeManager.Abstractions;

namespace EmployeeManager
{
  /// <summary>
  /// Сотрудник, работающий на сдельную оплату.
  /// </summary>
  public class PartTimeEmployee : Employee
  {
    /// <summary>
    /// Отработанные часы.
    /// </summary>
    public double WorkingHours { get; set; }

    /// <summary>
    /// Часовая оплата.
    /// </summary>
    public decimal HourlyRate { get; set; }

    /// <summary>
    /// Рассчитать зарплату.
    /// </summary>
    /// <returns></returns>
    public override decimal CalculateSalary()
    {
      Salary = decimal.Multiply(HourlyRate, (decimal)WorkingHours);
      return Salary;
    }
  }
}
