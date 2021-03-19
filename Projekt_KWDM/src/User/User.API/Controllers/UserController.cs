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

        [HttpPost]
        [ProducesResponseType(typeof(Entities.User), (int)HttpStatusCode.OK)]
        public ActionResult<Entities.User> GetUser([FromBody] Entities.User user)
        {
            var IsUser = _repository.CheckUser(user);
            if(IsUser)
                return Ok(IsUser);

            return  Ok("Niepoprawne dane logowania");
        }
    }
}
