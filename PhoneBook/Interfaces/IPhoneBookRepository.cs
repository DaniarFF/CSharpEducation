using PhoneBook.Models;

namespace PhoneBook.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория телефонной книги
    /// </summary>
    public interface IPhoneBookRepository
  {
    /// <summary>
    /// Добавляет нового абонента
    /// </summary>
    /// <param name="name">Имя абонента</param>
    /// <param name="number">Телефонный номер абонента в формате +79998887766</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task Add(string name, string number);

    /// <summary>
    /// Удаляет абонента из телефонной книги
    /// </summary>
    /// <param name="name"> Имя абонента </param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task Delete(string name);

    /// <summary>
    /// Ищет абонента по имени
    /// </summary>
    /// <param name="name">Имя абонента</param>
    /// <returns>Абонента, если его не существует, то null</returns>
    Task<Abonent> FindByName(string name);

    /// <summary>
    /// Ищет абонента по номеру
    /// </summary>
    /// <param name="number">Номер абонента</param>
    /// <returns>Абонента, если его не существует, то null</returns>
    Task<Abonent> FindByNumber(string number);

    /// <summary>
    /// Получить всех абонентов с телефонной книги
    /// </summary>
    /// <returns>Лист абонентов</returns>
    Task<List<Abonent>> GetAll();
  }
}