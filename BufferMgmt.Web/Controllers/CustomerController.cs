using AutoMapper;
using BufferMgmt.DAL.Entities;
using BufferMgmt.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BufferMgmt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IRepo<Customer> _repo;
        private readonly IMapper _mapper;
        public CustomerController(IRepo<Customer> repo, IMapper mapper)
        {
            _mapper = mapper;
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
                var model = _mapper.Map<CustomerVM>(customers);
                return Ok(model);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _repo.GetAll();
            var model = _mapper.Map<IEnumerable<CustomerVM>>(customers);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            Customer customer = _repo.Get(Id);

            if (customer == null)
            {
                return BadRequest("branch not found");
            }
            else
            {
                var model = _mapper.Map<IEnumerable<CustomerVM>>(customer);
                return Ok(model);
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
                var model = _mapper.Map<IEnumerable<CustomerVM>>(customer);
                return Ok(model);
            }
        }

    }
}