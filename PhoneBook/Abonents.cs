using System.Text.Json.Serialization;

namespace PhoneBook
{
    public class Abonents
    {
        public List<Abonent> Abonent { get; set; }
    }
    public class Abonent
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
