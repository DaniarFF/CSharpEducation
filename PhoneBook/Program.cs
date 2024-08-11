using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PhoneBook
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string path = "C:\\Users\\Данияр\\source\\repos\\CSharpEducation\\PhoneBook\\PhoneBook.json";

            PhoneBookClient phoneBookClient = new PhoneBookClient();
            PhoneBookRepository phoneBookRep = new PhoneBookRepository();
            AbonentList abonentList = await phoneBookRep.GetAllAbonents(path);

            while (true) 
            {
                Console.WriteLine("\nПолучить весь список: введите 1\n" +
                    "Получить абонента: введите 2\n" +
                    "Добавить абонента: введите 3\n" +
                    "Удалить абонента: введите 4\n");

                switch (Console.ReadLine())
                {
                    case "1": 
                        await phoneBookClient.GetAllAbonents(path); 
                        break;
                    case "2":
                        await phoneBookClient.FindAbonent(path, abonentList);
                        break;
                    case "3": 
                        await phoneBookClient.CreateNewAbonent(path, abonentList);
                        break;
                    case "4":
                        await phoneBookClient.DeleteAbonent(path, abonentList);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}