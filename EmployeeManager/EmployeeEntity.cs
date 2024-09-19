using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
  /// <summary>
  /// Модель сотрудника для работы с репозиторием
  /// </summary>
  public class EmployeeEntity
  {
    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Зарплата сотрудника на ставку
    /// </summary>
    public decimal Salary { get; set; }

    /// <summary>
    /// Часы, отработанные сотрудником, получающим сдельную оплату.
    /// </summary>
    public double WorkingHours { get; set; }

    /// <summary>
    /// Почасовая оплата сотрудника, получающего сдельную оплату.
    /// </summary>
    public decimal HourlyRate { get; set; }
  }
}
