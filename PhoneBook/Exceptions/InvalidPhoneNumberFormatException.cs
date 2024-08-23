using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Exceptions
{
  public class InvalidPhoneNumberFormatException : ValidationException
  {
    public InvalidPhoneNumberFormatException(string message) : base(message)
    {

    }
    public InvalidPhoneNumberFormatException(string message, Exception innerException) : base(message, innerException)
    {

    }
    public InvalidPhoneNumberFormatException()
    {

    }
  }
}
