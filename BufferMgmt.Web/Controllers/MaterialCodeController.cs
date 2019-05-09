using BufferMgmt.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BufferMgmt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialCodeController : ControllerBase
    {
        private readonly IRepo<MaterialCode> _repo;
        public MaterialCodeController(IRepo<MaterialCode> repo)
        {
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
                return Ok(materialCode);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var materialCodes = _repo.GetAll();
            return Ok(materialCodes);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int Id)
        {
            MaterialCode MaterialCode = _repo.Get(Id);

            if (MaterialCode == null)
            {
                return BadRequest("branch not found");
            }
            else
            {
                return Ok(MaterialCode);
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
                return Ok();
            }
        }
    }
}