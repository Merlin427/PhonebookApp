using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhonebookApi.Data;
using PhonebookApi.Models;
using PhonebookApi.ViewModels;

namespace PhonebookApi.Repositories
{
    public interface IPhonebookRepo : IRepository<Phonebook>
    {
        IQueryable<PhonebookEntriesViewModel> GetPhonebooks();
        PhonebookEntriesViewModel GetSingle(int id);

    }

    public class PhonebookRepo : Repository<Phonebook>, IPhonebookRepo
    {
        public PhonebookRepo(DataContext context) : base(context)
        {
        }

        public IQueryable<PhonebookEntriesViewModel> GetPhonebooks()
        {
            var phonebooks = _context.Phonebooks
                .Include(x => x.PhonebookEntries);
            return phonebooks.Select(x => new PhonebookEntriesViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Entries = x.PhonebookEntries.Select(entries => new ContactViewModel()
                {
                    Id = entries.Id,
                    ContactName = entries.ContactName,
                    PhoneNumber = entries.PhoneNumber,
                    PhonebookId = entries.PhonebookId

                })
            });
        }

        public PhonebookEntriesViewModel GetSingle(int id)
        {
            var phonebook = _context.Phonebooks.Include(x => x.PhonebookEntries).FirstOrDefault(x => x.Id == id);
            var returnModel = new PhonebookEntriesViewModel()
            {
                Id = phonebook.Id,
                Name = phonebook.Name,
                Entries = phonebook.PhonebookEntries.Select(entries => new ContactViewModel()
                {
                    PhonebookId = entries.PhonebookId,
                    ContactName = entries.ContactName,
                    Id = entries.Id
                })
            };
            return returnModel;
        }
    }
}