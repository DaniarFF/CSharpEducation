using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class PhoneBookRepository
    {
        public async Task<AbonentList> GetAllAbonents(string path) 
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
               return await JsonSerializer.DeserializeAsync<AbonentList>(fs);
            }
        }

        public async Task CreateNewAbonent(string name, long number, string path, AbonentList abonentList) 
        {
            Abonent newAbonent = new Abonent() 
            { 
                Name = name,
                PhoneNumber = number,
            };

            if(FindAbonent(name, path, abonentList).Result == null) 
            {
                abonentList.Abonent.Add(newAbonent);
            }
            else 
            {
                Console.WriteLine("Абонент уже существует");
                return;
            }

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {               
                await JsonSerializer.SerializeAsync<AbonentList>(fs, abonentList);
                Console.WriteLine($"Абонент {name} добавлен");
            }
        }

        public async Task DeleteAbonent(string name, string path, AbonentList abonentList)
        {
            var itemToDelete = abonentList.Abonent.FirstOrDefault(s => s.Name == name);
            abonentList.Abonent.Remove(itemToDelete);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                await JsonSerializer.SerializeAsync<AbonentList>(fs, abonentList);
                Console.WriteLine($"Абонент {name} Удален");
            }
        }

        public async Task<Abonent> FindAbonent(string name, string path, AbonentList abonentList)
        {
            return abonentList.Abonent.FirstOrDefault(s => s.Name == name);
        }
        public async Task<Abonent> FindAbonent(long number, string path, AbonentList abonentList)
        {
            return abonentList.Abonent.FirstOrDefault(s => s.PhoneNumber == number);
        }
    }
}
