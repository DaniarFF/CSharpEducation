using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Exceptions;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using PhoneBook.Settings;
using System.Xml.Linq;

namespace PhoneBook
{
  internal class Program
  {
    static async Task Main(string[] args)
    {
      var cfg = new ConfigurationBuilder().AddJsonFile("config.json").Build();
      var settings = cfg.GetSection("App").Get<ApplicationSettings>();

      IServiceCollection services = new ServiceCollection();

      services.AddSingleton(settings);
      services.AddTransient<IPhoneBookRepository, PhoneBookRepository>();
      services.AddTransient<IPhoneBookService, PhoneBookService>();

      var serviceProvider = services.BuildServiceProvider();

      var phoneBookService = serviceProvider.GetRequiredService<IPhoneBookService>();

      while (true)
      {
        Console.WriteLine("\nПолучить весь список: введите 1\n" +
            "Получить абонента: введите 2\n" +
            "Добавить абонента: введите 3\n" +
            "Удалить абонента: введите 4\n");

        switch (Console.ReadLine())
        {
          case "1":
            await GetAllAbonents(phoneBookService);
            break;
          case "2":
            await FindAbonent(phoneBookService);
            break;
          case "3":
            await AddNew(phoneBookService);
            break;
          case "4":
            await DeleteAbonent(phoneBookService);
            break;
          default:
            break;
        }
      }
    }

    private static async Task GetAllAbonents(IPhoneBookService phoneBookService)
    {
      try
      {
        var list = phoneBookService.GetAllContacts().ToList();
        foreach (var item in list)
        {
          Console.WriteLine($"Имя: {item.Name} Телефон: {item.PhoneNumber}");
        }
      }
      catch (Exception)
      {
        Console.WriteLine("Ошибка получения абонентов");
      }
    }

    private static async Task AddNew(IPhoneBookService phoneBookService)
    {
      try
      {
        Console.WriteLine("Напиши имя: ");
        string name = Console.ReadLine();
        Console.WriteLine("Напиши телефон: ");
        string number = Console.ReadLine();

        var existingContact = await phoneBookService.AddNewContact(name, number);

        if (existingContact == null)
        {
          Console.WriteLine($"Абонент {name} добавлен");
        }
        else 
        {
          Console.WriteLine($"Контакт уже существует:\nИмя: {existingContact.Name} Телефон: {existingContact.PhoneNumber}");
        }
      }
      catch (Exception ex)
      {
        if (ex is ContactAlreadyExistsException or InvalidPhoneNumberFormatException)
        {
          Console.WriteLine(ex.Message);
        }
        else 
        {
          Console.WriteLine("Ошибка добавления");
        }         
      }
    }

    private static async Task DeleteAbonent(IPhoneBookService phoneBookService)
    {
      Console.WriteLine("Напиши телефон: ");
      string number = Console.ReadLine();

      try
      {
        await phoneBookService.DeleteContact(number); 
      }
      catch (Exception)
      {
        Console.WriteLine("Ошибка удаления");
        return;
      }

      Console.WriteLine($"Абонент с телефоном {number} удален");
    }

    private static async Task FindAbonent(IPhoneBookService phoneBookService)
    {
      Console.WriteLine("Напиши имя или телефон");
      string name = Console.ReadLine();

      var contacts = phoneBookService.FindContact(name).ToList();
      if(contacts.Count() == 1) 
      {
        Console.WriteLine($"Имя: {contacts[0].Name} Телефон: {contacts[0].PhoneNumber}");
        return;
      }
      if (contacts.Count() > 1)
      {
        Console.WriteLine("Найдены абоненты:");
        foreach(var item in contacts) 
        {
          Console.WriteLine($"Имя: {item.Name} Телефон: {item.PhoneNumber}");
        }
      }
      else
      {
        Console.WriteLine("Абонент не найден");
      }
    }
  }
}