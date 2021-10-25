using Microsoft.EntityFrameworkCore;
using PhonebookApi.Models;

namespace PhonebookApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Phonebook> Phonebooks { get; set; }
        public DbSet<PhonebookEntry> PhonebookEntries { get; set; }
    }
}