using Microsoft.AspNetCore.Mvc;
using PhonebookApi.Services;
using PhonebookApi.ViewModels;

namespace PhonebookApi.Controllers
{
    
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            var contact =_contactService.GetEntry(id);
            return Ok(contact);
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] ContactCreationModel model)
        {
            _contactService.Create(model);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateEntry([FromBody] ContactCreationModel model)
        {
            _contactService.Update(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}