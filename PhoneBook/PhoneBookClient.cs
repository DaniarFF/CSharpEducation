using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace PhoneBook
{
    public class PhoneBookClient
    {
        PhoneBookRepository phoneBookRepository = new PhoneBookRepository();

        public async Task GetAllAbonents(string path)
        {
            try
            {
                AbonentList list = await phoneBookRepository.GetAllAbonents(path);
                foreach (var item in list.Abonent)
                {
                    Console.WriteLine($"Имя: {item.Name} Телефон: {item.PhoneNumber}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что то пошло не так:( ");
            }
        }

        public async Task CreateNewAbonent(string path, AbonentList abonentList)
        {
            try 
            {
                Console.WriteLine("Напиши имя: ");
                string name = Console.ReadLine();
                Console.WriteLine("Напиши телефон: ");
                int.TryParse(Console.ReadLine(), out int number);
                {
                    if(number < 0 || number > 1000000000000) { Console.WriteLine("Неверное кол - во цифр"); } //лень было обрабатывать формат, надеюсь не нужно было
                }

                await phoneBookRepository.CreateNewAbonent(name, number, path, abonentList);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Что то пошло не так:( ");
            }        
        }

        public async Task DeleteAbonent( string path, AbonentList abonentList)
        {
            try
            {
                Console.WriteLine("Напиши имя: ");
                string name = Console.ReadLine();

                await phoneBookRepository.DeleteAbonent(name, path, abonentList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что то пошло не так:( ");
            }
        }

        public async Task FindAbonent(string path, AbonentList abonentList)
        {
            Console.WriteLine("Напиши имя или телефон");
            string name = Console.ReadLine();

            if (int.TryParse(name, out int number))  // Возможа ли такая обработка? Или это бред
            {
                try 
                {
                    Abonent abonent = await phoneBookRepository.FindAbonent(number, path, abonentList);
                    Console.WriteLine($"Имя: {abonent.Name} Телефон: {abonent.PhoneNumber}");
                }
                
                catch(Exception ex) 
                {
                    Console.WriteLine($"Абонент не найден");
                }         
            }
            else
            {
                try
                {
                    Abonent abonent = await phoneBookRepository.FindAbonent(name, path, abonentList);
                    Console.WriteLine($"Имя: {abonent.Name} Телефон: {abonent.PhoneNumber}");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Абонент не найден");
                }                
            }
        }
    }
}

