using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using User.API.Repository;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;

        public UserController(IUserRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("{userLogin}")]
        [ProducesResponseType(typeof(Entities.User), (int)HttpStatusCode.OK)]
        public ActionResult<Entities.User> GetUser(string userLogin)
        {
            var user = _repository.GetUserByName(userLogin);
            return Ok(user);
        }
    }
}
