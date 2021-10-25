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
        Phonebook GetSingle(int id);

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

        public Phonebook GetSingle(int id)
        {
            var phonebook = _context.Phonebooks.Include(x => x.PhonebookEntries).FirstOrDefault(x => x.Id == id);

            return phonebook;
        }
    }
}