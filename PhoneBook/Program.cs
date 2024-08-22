using PhoneBook.Interfaces;
using PhoneBook.Models;
using PhoneBook.Settings;
using System.ComponentModel.Design;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneBook
{
  internal class Program
  {
    static async Task Main(string[] args)
    {
      IServiceCollection services = new ServiceCollection();

      services.AddSingleton(new ApplicationSettings(ConfigurationManager.AppSettings["path"]));
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

    static async Task GetAllAbonents(IPhoneBookService phoneBookService)
    {
      try
      {
        List<Abonent> list = await phoneBookService.GetAllAbonents();
        foreach (var item in list)
        {
          Console.WriteLine($"Имя: {item.Name} Телефон: {item.PhoneNumber}");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    static async Task AddNew(IPhoneBookService phoneBookService)
    {
      try
      {
        Console.WriteLine("Напиши имя: ");
        string name = Console.ReadLine();
        Console.WriteLine("Напиши телефон: ");
        string number = Console.ReadLine();

        bool isAbonentAdded = await phoneBookService.AddNewAbonent(name, number);
        if (isAbonentAdded)
        {
          Console.WriteLine($"Абонент {name} добавлен");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Ошибка добавления");
      }
    }

    static async Task DeleteAbonent(IPhoneBookService phoneBookService)
    {
      try
      {
        Console.WriteLine("Напиши имя: ");
        string name = Console.ReadLine();

        bool isAbonentDeleted = await phoneBookService.DeleteAbonent(name);
        if (isAbonentDeleted)
        {
          Console.WriteLine($"Абонент {name} удален");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Ошибка удаления");
      }
    }

    static async Task FindAbonent(IPhoneBookService phoneBookService)
    {
      Console.WriteLine("Напиши имя или телефон");
      string name = Console.ReadLine();

      Abonent abonent = await phoneBookService.FindAbonent(name);
      if (abonent != null)
      {
        Console.WriteLine($"Имя: {abonent.Name} Телефон: {abonent.PhoneNumber}");
      }
      else
      {
        Console.WriteLine("Абонент не найден");
      }
    }
  }
}