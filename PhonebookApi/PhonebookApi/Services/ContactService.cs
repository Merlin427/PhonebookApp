using System.Collections.Generic;
using AutoMapper;
using PhonebookApi.Models;
using PhonebookApi.Repositories;
using PhonebookApi.ViewModels;

namespace PhonebookApi.Services
{
    public interface IContactService
    {
        PhonebookEntry GetEntry(int id);
        List<PhonebookEntry> GetForPhoneBook(int phonebookId);
        public void Create(ContactCreationModel model);
        public void Update(ContactCreationModel model);
        public void Delete(int id);
    }

    public class ContactService : IContactService
    {
        private readonly IPhoneBookEntryRepo _phoneBookEntryRepo;
        private readonly IMapper _mapper;

        public ContactService(IPhoneBookEntryRepo phoneBookEntryRepo, IMapper mapper)
        {
            _phoneBookEntryRepo = phoneBookEntryRepo;
            _mapper = mapper;
        }

        public PhonebookEntry GetEntry(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<PhonebookEntry> GetForPhoneBook(int phonebookId)
        {
            throw new System.NotImplementedException();
        }

        public void Create(ContactCreationModel model)
        {
            var mappedModel = _mapper.Map<PhonebookEntry>(model);
            _phoneBookEntryRepo.Add(mappedModel);
            _phoneBookEntryRepo.Commit();
        }

        public void Update(ContactCreationModel model)
        {
            var mappedModel = _mapper.Map<PhonebookEntry>(model);
            _phoneBookEntryRepo.Update(mappedModel);
            _phoneBookEntryRepo.Commit();
        }

        public void Delete(int id)
        {
            _phoneBookEntryRepo.Remove(id);
            _phoneBookEntryRepo.Commit();
        }
    }
}