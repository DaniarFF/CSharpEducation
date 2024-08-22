namespace PhoneBook.Settings
{
  /// <summary>
  /// Настройки приложения
  /// </summary>
  public class ApplicationSettings
  {
    /// <summary>
    /// Путь к хранению данных телефонной книги
    /// </summary>
    public string RepositoryPath { get; set; }

    public ApplicationSettings(string repositoryPath)
    {
      RepositoryPath = repositoryPath;
    }
  }
}
