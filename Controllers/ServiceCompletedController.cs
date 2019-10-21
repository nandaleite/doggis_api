using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;

namespace WebApi.Controllers
{
    //rota ideal: /users/:id/services

    [ApiController]
    [Route("[controller]")]
    public class ServiceCompletedController : ControllerBase
    {
        private IServiceCompletedService _serviceCompletedService;

        public ServiceCompletedController(IServiceCompletedService ServiceCompletedService)
        {
            _serviceCompletedService = ServiceCompletedService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _serviceCompletedService.GetAll();
            return Ok(users);
        }

    }
}
