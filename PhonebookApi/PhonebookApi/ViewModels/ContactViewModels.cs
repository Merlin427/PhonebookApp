namespace PhonebookApi.ViewModels
{
    public class ContactCreationModel
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public int PhonebookId { get; set; }
    }

    public class ContactViewModel
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public int PhonebookId { get; set; }
    }
}