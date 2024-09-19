using EmployeeManager.Abstractions;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeManager
{
  /// <summary>
  /// Сотрудник, работающий на ставку
  /// </summary>
  public class FullTimeEmployee : Employee
  {
    public override decimal CalculateSalary()
    {
      return Salary;
    }
  }
}
