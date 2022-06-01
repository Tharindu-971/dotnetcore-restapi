using AutoMapper;
using DXDY.REST.API.Models;
using DXDY.REST.API.Models.Dtos;
using DXDY.REST.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXDY.REST.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IMapper mapper,IEmployeeRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var objectList = _repo.GetAll();
            var objectDto = new List<EmployeeDto>();

            foreach (var item in objectList)
            {
                objectDto.Add(_mapper.Map<EmployeeDto>(item));
            }
            return Ok(objectDto);
        }

        [HttpGet("{id:int}",Name = "GetEmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            var obj = _repo.GetEmployeeById(id);
            if(obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<EmployeeDto>(obj);
            return Ok(objDto);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeDto employeeDto)
        {
            if(employeeDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_repo.IsEmployeeExist(employeeDto.Name))
            {
                ModelState.AddModelError("", "Employee Exists!");
                return StatusCode(404,ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _mapper.Map<Employee>(employeeDto);

            if (!_repo.CreateEmployee(employee))
            {
                ModelState.AddModelError("", $"Something went wrong when creating {employeeDto.Name}");
                return StatusCode(500,ModelState);
            }
            return CreatedAtRoute("GetEmployeeById",new {id= employee.Id},employee);
        }

        [HttpPatch("{id:int}",Name = "UpdateEmployee")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto == null || id!=employeeDto.Id)
            {
                return BadRequest(ModelState);
            }
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _mapper.Map<Employee>(employeeDto);

            if (!_repo.UpdateEmployee(employee))
            {
                ModelState.AddModelError("", $"Something went wrong when updating {employeeDto.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }


        [HttpPatch("{id:int}", Name = "DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            if (_repo.IsEmployeeExist(id))
            {
                return NotFound();
            }

            var employee = _repo.GetEmployeeById(id);

            if (!_repo.DeleteEmployee(employee))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting {employee.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
