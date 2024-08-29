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
    Task Add(Contact contact);

    /// <summary>
    /// Удаляет абонента из телефонной книги
    /// </summary>
    /// <param name="name"> Имя абонента </param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task Delete(string number);

    /// <summary>
    /// Получить всех абонентов с телефонной книги
    /// </summary>
    /// <returns>Лист абонентов</returns>
    IEnumerable<Contact> GetAll();
  }
}