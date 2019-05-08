using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BufferMgmt.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BufferMgmt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IRepo<Branch> _repo;
        public BranchController(IRepo<Branch> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Branch branch)
        {
            if(branch==null)
            {
                return BadRequest("employee is null");
            }
            else
            {
                _repo.Add(branch);
                return Ok(branch);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            var Branches = _repo.GetAll();
            return Ok(Branches);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int Id)
        {
            Branch branch = _repo.Get(Id);

            if(branch==null)
            {
                return BadRequest("branch not found");
            }
            else
            {
                return Ok(branch);
            }
        }

    }
}