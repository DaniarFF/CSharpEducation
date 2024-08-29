using PhoneBook.Models;

namespace PhoneBook.Interfaces
{
  /// <summary>
  /// Интерфейс сервиса телефонной книги
  /// </summary>
  public interface IPhoneBookService
  {
    /// <summary>
    /// Добавляет нового абонента
    /// </summary>
    /// <param name="name">Имя абонента</param>
    /// <param name="number">Номер абонента</param>
    /// <returns>Обьект Contact</returns>
    Task<Contact> AddNewContact(string name, string number);

    /// <summary>
    /// Удаляет абонента
    /// </summary>
    /// <param name="name">Имя абонента</param>
    /// <returns></returns>
    Task DeleteContact(string name);

    /// <summary>
    /// Находит абонента по имени или номеру телефона
    /// </summary>
    /// <param name="searchString">Поисковая строка</param>
    /// <returns>Коллекцию найденых абонентов или null,если абонент не найден</returns>
    IEnumerable<Contact> FindContact(string searchString);

    /// <summary>
    /// Получить список абонентов
    /// </summary>
    /// <returns>Коллекцию всех абонентов</returns>
    IEnumerable<Contact> GetAllContacts();
  }
}