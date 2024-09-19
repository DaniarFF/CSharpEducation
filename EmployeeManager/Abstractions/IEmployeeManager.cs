namespace EmployeeManager.Abstractions
{
  /// <summary>
  /// Интерфейс управления данными сотрудников
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IEmployeeManager<T> where T : Employee
  {
    /// <summary>
    /// Добавить сотрудника
    /// </summary>
    /// <param name="employee">Сотрудник</param>
    void Add(T employee);

    /// <summary>
    /// Получить данные сотрудника
    /// </summary>
    /// <param name="name">Имя сотрудника</param>
    /// <returns></returns>
    T Get(string name);

    /// <summary>
    /// Обновить данные сотрудника
    /// </summary>
    /// <param name="employee">Обьект сотрудника</param>
    void Update(T employee);
  }
}
