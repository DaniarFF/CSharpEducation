using EmployeeManager;
using EmployeeManager.Abstractions;
using EmployeeManager.Settings;
using System.Text.Json;

namespace PhoneBook
{
  /// <summary>
  /// Репозиторий работников
  /// </summary>
  public class EmployeeRepository<T> : IEmployeeRepository<EmployeeEntity>
  {
    #region Поля и свойства

    private readonly string filePath;

    private JsonSerializerOptions options = new JsonSerializerOptions()
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      WriteIndented = true,
    };

    #endregion

    #region Методы

    public IEnumerable<EmployeeEntity> GetAll()
    {
      using FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
      List<EmployeeEntity> employees = JsonSerializer.Deserialize<List<EmployeeEntity>>(fs, options);
      return employees;
    }

    public async Task Add(EmployeeEntity employee)
    {
      List<EmployeeEntity> employees = GetAll().ToList();
      employees.Add(employee);

      using FileStream fs = new FileStream(filePath, FileMode.Create);
    }

    public EmployeeEntity Get(string name)
    {
      var employees = GetAll().ToList();
      EmployeeEntity employee = employees.FirstOrDefault(x => x.Name == name);
      return employee;
    }

    public async Task Update(EmployeeEntity employee)
    {
      var employees = GetAll().ToList();

      var emp = employees.FirstOrDefault(e => e.Name == employee.Name);
      if (emp != null)
      {
        employees.Remove(emp);
        employees.Add(employee);

        using FileStream fs = new FileStream(filePath, FileMode.Create);
        JsonSerializer.Serialize(fs, employees, options);
      }
    }

    #endregion

    #region Конструкторы
    public EmployeeRepository(ApplicationSettings applicationSettings)
    {
      filePath = applicationSettings.RepositoryPath;
    }
    #endregion
  }
}
