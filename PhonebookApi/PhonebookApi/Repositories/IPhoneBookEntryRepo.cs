using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhonebookApi.Data;
using PhonebookApi.Models;
using PhonebookApi.ViewModels;

namespace PhonebookApi.Repositories
{
    public interface IPhoneBookEntryRepo: IRepository<PhonebookEntry>
    {
        ContactViewModel GetSingle(int id);

    }
    public class PhoneBookEntryRepo: Repository<PhonebookEntry>, IPhoneBookEntryRepo
    {
        public PhoneBookEntryRepo(DataContext context) : base(context)
        {
        }

        public ContactViewModel GetSingle(int id)
        {
            var contact = _context.PhonebookEntries.FirstOrDefault(x => x.Id == id);
            var returnModel = new ContactViewModel()
            {
                Id = contact.Id,
                PhonebookId = contact.PhonebookId,
                ContactName = contact.ContactName,
                PhoneNumber = contact.PhoneNumber
            };
            return returnModel;
        }
    }
}