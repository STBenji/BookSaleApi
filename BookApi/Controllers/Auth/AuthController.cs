using BookApi.Data.Repositories;
using BookApi.Domain;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("byId/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var result = await _userRepository.GetUserById(id);

            if (result == null)
                return NotFound(new { Message = "El usuario no existe" });

            return Ok(result);
        }

        [HttpGet("byEmail/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(String email)
        {
            var result = await _userRepository.GetUserByEmail(email);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            await _userRepository.Register(user);

            var result = new { User = user, Message = "Usuario creado exitosamente." };
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(User user)
        {
            var userResult = await _userRepository.Login(user);

            if (userResult == null)
            {
                return Unauthorized(new { Message = "Credenciales inválidas" });
            }

            return Ok(new { Message = "Inicio de sesión exitoso", User = user });
        }


    }
}
