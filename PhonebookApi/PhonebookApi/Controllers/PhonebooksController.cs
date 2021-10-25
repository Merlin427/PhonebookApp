using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PhonebookApi.Models;
using PhonebookApi.Services;
using PhonebookApi.ViewModels;

namespace PhonebookApi.Controllers
{
    [Route("api/[controller]")]
    public class PhonebooksController : Controller
    {
        private IPhonebookService _phonebookService;
        
        public PhonebooksController(IPhonebookService phonebookService)
        {
            _phonebookService = phonebookService;
        }

        [HttpGet]
        public IActionResult GetPhonebooks()
        {
            var phonebooks = _phonebookService.GetPhonebooks();
            return Ok(phonebooks);
        }

        [HttpGet("details")]
        public IActionResult GetPhonebookDetails()
        {
            var phonebooks = _phonebookService.GetPhonebooksWithEntries();
            return Ok(phonebooks);
        }

        [HttpGet("{id}")]
        public IActionResult GetPhonebook(int id)
        {
            var phonebook1 = _phonebookService.GetPhonebook(id);
            return Ok(phonebook1);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] PhonebookCreationModel model)
        {
            _phonebookService.CreatePhonebook(model);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] PhonebookCreationModel model)
        {
            _phonebookService.UpdatePhoneBook(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _phonebookService.DeletePhoneBook(id);   
        }
    }
}