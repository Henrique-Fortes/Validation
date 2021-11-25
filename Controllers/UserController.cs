using Microsoft.AspNetCore.Mvc;
using Validation.Models;

namespace Validation.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("/")]
        public IActionResult Post(
            [FromBody] CreateUserModel model) //Converter o corpo que e um JSON para -> CreateUserModel (para um objeto) por meio do modelBinder
        {
            if(!ModelState.IsValid) // usando isso ja consegue ver se esta valido ou nao
                return BadRequest();

            return Ok();
        }
    }
}
