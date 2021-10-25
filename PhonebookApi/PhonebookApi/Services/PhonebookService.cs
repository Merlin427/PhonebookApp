using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PhonebookApi.Models;
using PhonebookApi.Repositories;
using PhonebookApi.ViewModels;

namespace PhonebookApi.Services
{
    public interface IPhonebookService
    {
        PhonebookEntriesViewModel GetPhonebook(int id);
        List<PhonebookEntriesViewModel> GetPhonebooksWithEntries();
        List<Phonebook> GetPhonebooks();
        public void CreatePhonebook(PhonebookCreationModel model);
        public void UpdatePhoneBook(PhonebookCreationModel model);
        public void DeletePhoneBook(int id);

    }

    public class PhoneBookService : IPhonebookService
    {
        private readonly IPhonebookRepo _phonebookRepo;
        private readonly IPhoneBookEntryRepo _phoneBookEntryRepo;
        private readonly IMapper _mapper;

        public PhoneBookService(IPhonebookRepo phonebookRepo, IPhoneBookEntryRepo phoneBookEntryRepo, IMapper mapper)
        {
            _phonebookRepo = phonebookRepo;
            _phoneBookEntryRepo = phoneBookEntryRepo;
            _mapper = mapper;
        }

        public PhonebookEntriesViewModel GetPhonebook(int id)
        {
            var phonebook = _phonebookRepo.GetSingle(id);

            return phonebook;
        }

        public List<PhonebookEntriesViewModel> GetPhonebooksWithEntries()
        {
            var phonebooks = _phonebookRepo.GetPhonebooks().ToList();
            return phonebooks;
        }

        public List<Phonebook> GetPhonebooks()
        {
            var phonebooks = _phonebookRepo.Get().ToList();
            return phonebooks;
        }
        
        public void CreatePhonebook(PhonebookCreationModel model)
        {
            var mappedModel =_mapper.Map<Phonebook>(model);
            _phonebookRepo.Add(mappedModel);
            _phonebookRepo.Commit();
        }

        public void UpdatePhoneBook(PhonebookCreationModel model)
        {
            var mappedModel = _mapper.Map<Phonebook>(model);
            _phonebookRepo.Update(mappedModel);
            _phonebookRepo.Commit();
        }

        public void DeletePhoneBook(int id)
        {
            _phonebookRepo.Remove(id);
            _phonebookRepo.Commit();
        }
    }
}