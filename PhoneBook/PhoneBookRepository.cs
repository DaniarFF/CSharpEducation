using System.Configuration;
using System.Text.Json;

namespace PhoneBook
{
    public class PhoneBookRepository
    {
        readonly string _filePath;

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public PhoneBookRepository(string path)
        {
            _filePath = path;
        }

        public async Task<Abonents> GetAll()
        {
            using FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate);
            Abonents abonents = await JsonSerializer.DeserializeAsync<Abonents>(fs, options);
            return abonents;
        }

        public async Task AddNew(string name, string number)
        {
            Abonents abonents = await GetAll(); 
            
            name = FirstLetterToUpperCase(name);

            Abonent newAbonent = new Abonent()
            {
                Name = name,
                PhoneNumber = number,
            };

            if (await FindWithName(name) == null)
            {    
                abonents.Abonent.Add(newAbonent);
            }
            else
            {
                throw new Exception("Абонент уже существует");
            }

            using FileStream fs = new FileStream(_filePath, FileMode.Create);
            await JsonSerializer.SerializeAsync<Abonents>(fs, abonents, options);
        }

        public async Task Delete(string name)
        {
            try 
            {
                Abonents abonents = await GetAll();

                name = FirstLetterToUpperCase(name);

                var itemToDelete = abonents.Abonent.FirstOrDefault(s => s.Name == name);
                if (itemToDelete != null) 
                {
                    throw new Exception("Ошибка удаления, абонента не существует");
                }
                abonents.Abonent.Remove(itemToDelete);

                using FileStream fs = new FileStream(_filePath, FileMode.Create);
                await JsonSerializer.SerializeAsync<Abonents>(fs, abonents, options);
            }
            catch (Exception ex) 
            {
                throw new Exception("Ошибка удаления");
            }           
        }

        public async Task<Abonent> FindWithName(string name)
        {
            name = FirstLetterToUpperCase(name);

            Abonents abonents = await GetAll();
            return abonents.Abonent.FirstOrDefault(s => s.Name == name);
        }

        public async Task<Abonent> FindWithNumber(string number)
        {
            Abonents abonents = await GetAll();
            return abonents.Abonent.FirstOrDefault(s => s.PhoneNumber == number);
        }

        public string FirstLetterToUpperCase(string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1);
        }
    }
}
