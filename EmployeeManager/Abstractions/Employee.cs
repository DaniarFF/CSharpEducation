namespace EmployeeManager.Abstractions
{
  /// <summary>
  /// Абстрактный класс Сотрудник
  /// </summary>
  public abstract class Employee
  {
    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Зарплата
    /// </summary>
    public decimal Salary { get; set; }

    /// <summary>
    /// Расчитать зарплату
    /// </summary>
    /// <returns>Salary</returns>
    public abstract decimal CalculateSalary();
  }
}
