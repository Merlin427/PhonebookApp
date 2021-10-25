using System.Collections.Generic;

namespace PhonebookApi.ViewModels
{
    public class PhonebookCreationModel
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        
    }

    public class PhonebookEntriesViewModel
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ContactViewModel> Entries { get; set; }
    }
    
}