using PhoneBook.Models;

namespace PhoneBook.Interfaces
{
    /// <summary>
    /// Интерфейс сериса телефонной книги
    /// </summary>
    public interface IPhoneBookService
  {
    /// <summary>
    /// Добавляет нового абонента
    /// </summary>
    /// <param name="name">Имя абонента</param>
    /// <param name="number">Номер абонента</param>
    /// <returns></returns>
    Task<bool> AddNewAbonent(string name, string number);

    /// <summary>
    /// Удаляет абонента
    /// </summary>
    /// <param name="name">Имя абонента</param>
    /// <returns></returns>
    Task<bool> DeleteAbonent(string name);

    /// <summary>
    /// Находит абонента по имени или номеру телефона
    /// </summary>
    /// <param name="searchString">Поисковая строка</param>
    /// <returns>Абонента или null,если абонент не найден</returns>
    Task<Abonent> FindAbonent(string searchString);

    /// <summary>
    /// Получить список абонентов
    /// </summary>
    /// <returns>Лист абонентов</returns>
    Task<List<Abonent>> GetAllAbonents();
  }
}