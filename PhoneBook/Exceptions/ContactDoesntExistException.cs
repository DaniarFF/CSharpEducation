namespace PhoneBook.Exceptions
{
  public class ContactDoesntExistException : ApplicationException
  {
    public ContactDoesntExistException(string message) : base(message)
    {

    }
    public ContactDoesntExistException(string message, Exception innerException) : base(message, innerException)
    {

    }
    public ContactDoesntExistException()
    {

    }
  }
}
