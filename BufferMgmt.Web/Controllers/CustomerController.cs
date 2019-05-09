using BufferMgmt.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BufferMgmt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IRepo<Customer> _repo;
        public CustomerController(IRepo<Customer> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customers)
        {
            if (customers == null)
            {
                return BadRequest("employee is null");
            }
            else
            {
                _repo.Add(customers);
                return Ok(customers);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _repo.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int Id)
        {
            Customer customer = _repo.Get(Id);

            if (customer == null)
            {
                return BadRequest("branch not found");
            }
            else
            {
                return Ok(customer);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("the branch is Null");
            }
            else
            {
                _repo.Delete(customer);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("the branch is Null");
            }
            else
            {
                _repo.Update(customer);
                return Ok();
            }
        }

    }
}