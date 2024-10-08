﻿using PhoneBook.Interfaces;
using PhoneBook.Models;
using PhoneBook.Settings;
using System.Text.Json;

namespace PhoneBook
{
  /// <summary>
  /// Репозиторий телефонной книги
  /// </summary>
  public class PhoneBookRepository : IPhoneBookRepository
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

    public IEnumerable<Contact> GetAll()
    {
      using FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
      List<Contact> contacts = JsonSerializer.Deserialize<List<Contact>>(fs, options);
      return contacts;
    }

    public async Task Add(Contact contact)
    {
      try
      {
        List<Contact> contacts = GetAll().ToList();
        contacts.Add(contact);

        using FileStream fs = new FileStream(filePath, FileMode.Create);
        JsonSerializer.Serialize(fs, contacts, options);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task Delete(string number)
    {
      List<Contact> contacts = GetAll().ToList();

      Contact contactToDelete = new Contact();

      foreach (var item in contacts)
      {
        if (item.PhoneNumber == number)
        {
          contactToDelete = item;
        }
      }
      contacts.Remove(contactToDelete);

      using FileStream fs = new FileStream(filePath, FileMode.Create);
      await JsonSerializer.SerializeAsync(fs, contacts, options);
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
