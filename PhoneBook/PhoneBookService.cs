using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PhoneBook
{
    public class PhoneBookService
    {
        static string _filePath = ConfigurationManager.AppSettings["path"];

        PhoneBookRepository _phoneBookRepository = new PhoneBookRepository(_filePath);
           
        public async Task<Abonents> GetAllAbonents()
        {
            try
            {
                return await _phoneBookRepository.GetAll();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AddNewAbonent(string name, string number)
        {
            Regex regex = new Regex(@"^\+7\d{10}$");
            try
            {
                if (regex.IsMatch(number))
                {
                    await _phoneBookRepository.AddNew(name, number);
                    return true;
                }
                else 
                { 
                    throw new Exception("Неправильный формат телефона, должен быть в формате +79998887766");
                }             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAbonent(string name)
        {
            try
            {
                await _phoneBookRepository.Delete(name);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Abonent> FindAbonent(string searchString)
        {
            Regex regex = new Regex(@"^\+7\d{10}$");
            if (regex.IsMatch(searchString)) 
            {
                try
                {
                    return await _phoneBookRepository.FindWithNumber(searchString);      
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                try
                {
                    return await _phoneBookRepository.FindWithName(searchString);
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}

