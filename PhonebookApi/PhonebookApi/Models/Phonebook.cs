using System.Collections.Generic;

namespace PhonebookApi.Models
{
    public class Phonebook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  ICollection<PhonebookEntry> PhonebookEntries { get; set; }
    }
}