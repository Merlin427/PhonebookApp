using Microsoft.EntityFrameworkCore;
using PhonebookApi.Data;
using PhonebookApi.Models;

namespace PhonebookApi.Repositories
{
    public interface IPhoneBookEntryRepo: IRepository<PhonebookEntry>
    {
        
    }
    public class PhoneBookEntryRepo: Repository<PhonebookEntry>, IPhoneBookEntryRepo
    {
        public PhoneBookEntryRepo(DataContext context) : base(context)
        {
        }
    }
}