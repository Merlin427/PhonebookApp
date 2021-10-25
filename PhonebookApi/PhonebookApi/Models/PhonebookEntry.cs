namespace PhonebookApi.Models
{
    public class PhonebookEntry
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        // NAVIGATION
        
        public int PhonebookId { get; set; }
        public Phonebook Phonebook { get; set; }
    }
}