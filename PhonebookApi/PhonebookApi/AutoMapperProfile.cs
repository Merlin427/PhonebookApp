using AutoMapper;
using PhonebookApi.Models;
using PhonebookApi.ViewModels;

namespace PhonebookApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Phonebook, PhonebookCreationModel>();
            CreateMap<PhonebookCreationModel, Phonebook>();
            CreateMap<PhonebookEntry, ContactCreationModel>();
            CreateMap<ContactCreationModel, PhonebookEntry>();
        }
    }
}