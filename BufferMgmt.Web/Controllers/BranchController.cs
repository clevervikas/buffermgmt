using AutoMapper;
using BufferMgmt.BAL.Models;
using BufferMgmt.DAL.Entities;
using BufferMgmt.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BufferMgmt.Web.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IRepo<Branch> _repo;
        private readonly IMapper _mapper;
        public BranchController(IRepo<Branch> repo, IMapper mapper)
        {
            _mapper = mapper;
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
                var model = _mapper.Map<BranchVM>(branch);
                return Ok(model);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Branches = _repo.GetAll();
            var model = _mapper.Map<IEnumerable<BranchVM>>(Branches);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            Branch branch = _repo.Get(Id);

            if(branch==null)
            {
                return BadRequest("branch not found");
            }
            else
            {
                var model = _mapper.Map<BranchVM>(branch);

                return Ok(model);
            }
        }

        [HttpDelete]
       public IActionResult Delete(Branch branch )
        {
            if(branch== null)
            {
                return BadRequest("the branch is Null");
            }
            else
            {
                _repo.Delete(branch);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult Update(Branch branch)
        {
            if (branch == null)
            {
                return BadRequest("the branch is Null");
            }
            else
            {
                _repo.Update(branch);
                var model = _mapper.Map<BranchVM>(branch);
                return Ok(model);
            }
        }
    }
}