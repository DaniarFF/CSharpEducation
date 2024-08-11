using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class AbonentList
    {
        [JsonPropertyName("abonents")]
        public List<Abonent> Abonent { get; set; }
    }
    public class Abonent
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phoneNumber")]
        public long PhoneNumber { get; set; }
    }
}
