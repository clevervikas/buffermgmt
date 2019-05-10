using AutoMapper;
using BufferMgmt.DAL.Entities;
using BufferMgmt.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BufferMgmt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialCodeController : ControllerBase
    {
        private readonly IRepo<MaterialCode> _repo;
        private readonly IMapper _mapper;
        public MaterialCodeController(IRepo<MaterialCode> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Post([FromBody] MaterialCode materialCode)
        {
            if (materialCode == null)
            {
                return BadRequest("employee is null");
            }
            else
            {
                _repo.Add(materialCode);

                var model = _mapper.Map<MaterialCodeVM>(materialCode);
                return Ok(model);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var materialCodes = _repo.GetAll();
            var model = _mapper.Map<IEnumerable<MaterialCodeVM>>(materialCodes);

            return Ok(materialCodes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            MaterialCode MaterialCode = _repo.Get(Id);

            if (MaterialCode == null)
            {
                return BadRequest("branch not found");
            }
            else
            {
                var model = _mapper.Map<MaterialCodeVM>(MaterialCode);
                return Ok(model);
            }
        }

        [HttpDelete]
        public IActionResult Delete(MaterialCode MaterialCode)
        {
            if (MaterialCode == null)
            {
                return BadRequest("the branch is Null");
            }
            else
            {
                _repo.Delete(MaterialCode);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult Update(MaterialCode MaterialCode)
        {
            if (MaterialCode == null)
            {
                return BadRequest("the branch is Null");
            }
            else
            {
                _repo.Update(MaterialCode);
                var model = _mapper.Map<MaterialCodeVM>(MaterialCode);
                return Ok(model);
            }
        }
    }
}