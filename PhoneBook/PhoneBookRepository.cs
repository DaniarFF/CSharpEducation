using System.Text.Json;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using PhoneBook.Settings;

namespace PhoneBook
{
    /// <summary>
    /// Репозиторий телефонной книги
    /// </summary>
    public class PhoneBookRepository : IPhoneBookRepository
  {
    #region Поля и свойства

    private readonly string filePath;

    #endregion

    #region Вложенные типы

    JsonSerializerOptions options = new JsonSerializerOptions()
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      WriteIndented = true,
    };

    #endregion

    #region Методы

    public async Task<List<Abonent>> GetAll()
    {
      using FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
      List<Abonent> abonents = await JsonSerializer.DeserializeAsync<List<Abonent>>(fs, options);
      return abonents;
    }

    public async Task Add(string name, string number)
    {
      List<Abonent> abonents = await GetAll();

      name = CapitalizeFirstLetter(name);

      Abonent newAbonent = new Abonent()
      {
        Name = name,
        PhoneNumber = number,
      };

      Abonent abonent = await FindByName(name);
      if (abonent == null)
      {
        abonents.Add(newAbonent);
      }
      else
      {
        throw new InvalidOperationException("Абонент уже существует");
      }

      using FileStream fs = new FileStream(filePath, FileMode.Create);
      await JsonSerializer.SerializeAsync(fs, abonents, options);
    }

    public async Task Delete(string name)
    {
      try
      {
        List<Abonent> abonents = await GetAll();

        name = CapitalizeFirstLetter(name);

        var itemToDelete = abonents.FirstOrDefault(s => s.Name == name);
        if (itemToDelete != null)
        {
          abonents.Remove(itemToDelete);

          using FileStream fs = new FileStream(filePath, FileMode.Create);
          await JsonSerializer.SerializeAsync(fs, abonents, options);
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Ошибка удаления");
      }
    }

    public async Task<Abonent> FindByName(string name)
    {
      name = CapitalizeFirstLetter(name);

      List<Abonent> abonents = await GetAll();
      return abonents.FirstOrDefault(s => s.Name == name);
    }

    public async Task<Abonent> FindByNumber(string number)
    {
      List<Abonent> abonents = await GetAll();
      return abonents.FirstOrDefault(s => s.PhoneNumber == number);
    }

    public string CapitalizeFirstLetter(string str)
    {
      return str.Substring(0, 1).ToUpper() + str.Substring(1);
    }

    #endregion

    #region Конструкторы
    public PhoneBookRepository(ApplicationSettings applicationSettings)
    {
      filePath = applicationSettings.RepositoryPath;
    }
    #endregion
  }
}
