using PhoneBook.Exceptions;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using PhoneBook.Settings;
using System.Text.RegularExpressions;

namespace PhoneBook
{
  /// <summary>
  /// Сервис для работы с телефонной книгой
  /// </summary>
  public class PhoneBookService : IPhoneBookService
  {
    #region Поля и свойства

    private IPhoneBookRepository phoneBookRepository;

    #endregion

    #region Методы
    public IEnumerable<Contact> GetAllContacts()
    {
      return phoneBookRepository.GetAll();
    }

    public async Task<Contact> AddNewContact(string name, string number)
    {
      List<Contact> contacts = (phoneBookRepository.GetAll()).ToList();

      foreach (var contact in contacts)
      {
        if (contact.PhoneNumber == number)
        {
          return contact;
        }
      }

      Contact contactToAdd = new Contact()
      {
        Name = name,
        PhoneNumber = number
      };

      Regex regex = new Regex(@"^\+7\d{10}$");

      if (regex.IsMatch(number))
      {
        await phoneBookRepository.Add(contactToAdd);
        return null;
      }
      else
      {
        throw new ValidationException("Неправильный формат телефона, должен быть в формате +79998887766");
      }
    }

    public async Task DeleteContact(string number)
    {
      List<Contact> contacts = (phoneBookRepository.GetAll()).ToList();
      Contact contactToDelete = contacts.FirstOrDefault(p => p.PhoneNumber == number);

      if (contactToDelete == null)
      {
        throw new ValidationException("Контакта с таким номером не существует");
      }

      await phoneBookRepository.Delete(contactToDelete.PhoneNumber);
    }

    public IEnumerable<Contact> FindContact(string searchString)
    {
      Regex regex = new Regex(@"^\+7\d{10}$");

      if (regex.IsMatch(searchString))
      {
        List<Contact> contacts = phoneBookRepository.GetAll().ToList();
        return contacts.FindAll(s => s.PhoneNumber == searchString).ToList();
      }
      else
      {
        List<Contact> contacts = phoneBookRepository.GetAll().ToList();
        return contacts.FindAll(s => s.Name.ToUpper() == searchString.ToUpper());
      }
    }

    #endregion

    #region Констукторы

    public PhoneBookService(ApplicationSettings applicationSettings, IPhoneBookRepository repository)
    {
      phoneBookRepository = repository;
    }

    #endregion
  }
}