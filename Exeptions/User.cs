namespace Exceptions
{
  /// <summary>
  /// Пользователь
  /// </summary>
  public class User
  {
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Почта пользователя.
    /// </summary>
    public string Email { get; set; }

    public User(string name, string email)
    {
      this.Name = name;
      this.Email = email;
    }
  }
}
