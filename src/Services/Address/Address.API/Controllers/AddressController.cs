using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Address.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class AddressController
        : ControllerBase
    {
        [HttpGet("{id}", Name = "GetAddress")]
        [ProducesResponseType(typeof(AddressDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<AddressDto> GetAddress(string id)
        {
            if (id == "NotFound")
            {
                return NotFound();
            }
            return Ok(new AddressDto(id, "Dhaka", "Bangladesh"));
        }
    }

    public class AddressDto
    {
        public AddressDto(string id, string? city, string country)
        {
            Id = id;
            City = city;
            Country = country;
        }

        public string Id { get; set; }
        
        public string? City { get; set; }

        public string Country { get; set; }
    }
}
