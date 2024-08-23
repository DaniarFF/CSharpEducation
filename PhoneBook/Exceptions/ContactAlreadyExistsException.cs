namespace PhoneBook.Exceptions
{
  public class ContactAlreadyExistsException : ApplicationException
  {
    public ContactAlreadyExistsException(string message) : base(message)
    {

    }
    public ContactAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
    {

    }
    public ContactAlreadyExistsException()
    {

    }
  }
}
