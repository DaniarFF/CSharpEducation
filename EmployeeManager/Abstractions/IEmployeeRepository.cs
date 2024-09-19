namespace EmployeeManager.Abstractions
{
  /// <summary>
  /// Интерфейс репозитория сотрудников.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IEmployeeRepository<T> where T : EmployeeEntity
  {
    /// <summary>
    /// Добавить сотрудника.
    /// </summary>
    /// <param name="employee">Обьект сотрудника.</param>
    /// <returns></returns>
    Task Add(EmployeeEntity employee);

    /// <summary>
    /// Получить всех сотрудников.
    /// </summary>
    /// <returns>Коллекцию сотрудников</returns>
    IEnumerable<EmployeeEntity> GetAll();

    /// <summary>
    /// Получить сотрудника по имени
    /// </summary>
    /// <param name="name">Имя сотрудника</param>
    /// <returns></returns>
    EmployeeEntity Get(string name);

    /// <summary>
    /// Обновить данные сотрудника
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    Task Update(EmployeeEntity employee);
  }
}