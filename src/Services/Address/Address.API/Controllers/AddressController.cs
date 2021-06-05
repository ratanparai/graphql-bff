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
        public ActionResult<AddressDto> GetAddress(string id)
        {
            return Ok(new AddressDto
            {
                Id = id,
                City = "Dhaka",
                Country = "Bangladesh"
            });
        }
    }

    public class AddressDto
    {
        public string Id { get; set; }
        
        public string City { get; set; }

        public string Country { get; set; }
    }
}
