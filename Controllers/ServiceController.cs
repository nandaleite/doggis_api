using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private IServiceService _ServiceService;

        public ServiceController(IServiceService ServiceService)
        {
            _ServiceService = ServiceService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _ServiceService.GetAll();
            return Ok(users);
        }

    }
}
