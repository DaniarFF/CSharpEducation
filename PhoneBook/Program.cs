using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PhoneBook
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            PhoneBookService phoneBookService = new PhoneBookService();

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
                        await AddNewAbonent(phoneBookService);
                        break;
                    case "4":
                        await DeleteAbonent(phoneBookService);
                        break;
                    default:
                        break;
                }
            }
        }

        static async Task GetAllAbonents(PhoneBookService phoneBookService) 
        {
            try
            {
                Abonents list = await phoneBookService.GetAllAbonents();
                foreach (var item in list.Abonent)
                {
                    Console.WriteLine($"Имя: {item.Name} Телефон: {item.PhoneNumber}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task AddNewAbonent(PhoneBookService phoneBookService)
        {
            try
            {
                Console.WriteLine("Напиши имя: ");
                string name = Console.ReadLine();
                Console.WriteLine("Напиши телефон: ");
                string number = Console.ReadLine();

                if (await phoneBookService.AddNewAbonent(name, number))
                { 
                    Console.WriteLine($"Абонент {name} добавлен");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task DeleteAbonent(PhoneBookService phoneBookService)
        {
            try
            {
                Console.WriteLine("Напиши имя: ");
                string name = Console.ReadLine();

                if (await phoneBookService.DeleteAbonent(name))
                {
                    Console.WriteLine($"Абонент {name} удален");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task FindAbonent(PhoneBookService phoneBookService)
        {
            Console.WriteLine("Напиши имя или телефон");
            string name = Console.ReadLine();

            Abonent abonent = await phoneBookService.FindAbonent(name);
            if(abonent != null) 
            {
                Console.WriteLine($"Имя: {abonent.Name} Телефон: {abonent.PhoneNumber}");
            }
        }
    }
}