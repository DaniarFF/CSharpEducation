using Exceptions.Exceptions;

namespace Exceptions
{
  /// <summary>
  /// 
  /// </summary>
  public class UserManager
  {
    public static List<User> users = new List<User>();

    #region Методы

    /// <summary>
    /// Добавить пользователя.
    /// </summary>
    /// <param name="name">Имя</param>
    /// <param name="email">Почта</param>
    /// <exception cref="UserAlreadyExistsException"></exception>
    public void AddUser(string name, string email)
    {
      var existingUser = users.FirstOrDefault(u => u.Email == email);
      if (existingUser != null)
      {
        throw new UserAlreadyExistsException("Пользователь уже существует");
      }

      var user = new User(name, email)
      {
        Email = email,
        Name = name,
        Id = users.Count
      };

      users.Add(user);
    }

    /// <summary>
    /// Удалить пользователя по имени
    /// </summary>
    /// <param name="name">Имя</param>
    /// <exception cref="UserNotFoundException"></exception>
    public void RemoveUser(string name)
    {
      var userToDelete = users.FirstOrDefault(x => x.Name == name);
      if (userToDelete != null)
      {
        users.Remove(userToDelete);
      }
      else
      {
        throw new UserNotFoundException($"Пользователь {name} не найден");
      }
    }

    /// <summary>
    /// Получить информацию о пользователе по имени.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <returns></returns>
    /// <exception cref="UserNotFoundException"></exception>
    public User GetUser(string name)
    {
      var user = users.FirstOrDefault(x => x.Name == name);
      if (user != null) return user;
      else throw new UserNotFoundException($"Пользователь {name} не найден");
    }

    #endregion

    #region Конструкторы

    public List<User> ListUsers()
    {
      return users;
    } 

    #endregion
  }
}
