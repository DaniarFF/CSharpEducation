using System.Text.RegularExpressions;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using PhoneBook.Settings;

namespace PhoneBook
{
    /// <summary>
    /// Сервис для работы с телефонной книгой
    /// </summary>
    public class PhoneBookService : IPhoneBookService
  {
    #region Поля и свойства

    private string filePath;
    private IPhoneBookRepository phoneBookRepository;

    #endregion

    #region Методы
    public async Task<List<Abonent>> GetAllAbonents()
    {
      return await phoneBookRepository.GetAll();
    }

    public async Task<bool> AddNewAbonent(string name, string number)
    {
      Regex regex = new Regex(@"^\+7\d{10}$");

      if (regex.IsMatch(number))
      {
        await phoneBookRepository.Add(name, number);
        return true;
      }
      else
      {
        throw new Exception("Неправильный формат телефона, должен быть в формате +79998887766");
      }
    }

    public async Task<bool> DeleteAbonent(string name)
    {
      await phoneBookRepository.Delete(name);
      return true;
    }

    public async Task<Abonent> FindAbonent(string searchString)
    {
      Regex regex = new Regex(@"^\+7\d{10}$");

      if (regex.IsMatch(searchString))
      {
        return await phoneBookRepository.FindByNumber(searchString);
      }

      if (regex.IsMatch(searchString))
      {
        return await phoneBookRepository.FindByNumber(searchString);
      }
      else
      {
        return await phoneBookRepository.FindByName(searchString);
      }
    }
    #endregion

    #region Констукторы

    public PhoneBookService(ApplicationSettings applicationSettings, IPhoneBookRepository repository)
    {
      phoneBookRepository = repository;
      filePath = applicationSettings.RepositoryPath;
    }

    #endregion
  }
}