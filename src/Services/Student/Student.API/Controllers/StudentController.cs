using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Student.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class StudentController
        : ControllerBase
    {
        [HttpGet("{id}", Name = "GetStudent")]
        [ProducesResponseType(typeof(StudentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<StudentDto> GetStudent(string id)
        {
            if (id == "Null")
            {
                return NotFound();
            }
            return Ok(new StudentDto(id, "Ratan", 12));
        }
    }

    public class StudentDto
    {
        public StudentDto(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public string Id { get; }

        public string Name { get; }

        public int Age { get; }
    }
}
