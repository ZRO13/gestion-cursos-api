using ApiGestionCursos.Models.Dtos;
using ApiGestionCursos.Repository.IRepository;
using Asp.Versioning;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiEcommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersionNeutral]

    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            var usersDto = users.Adapt<List<UserDto>>();
            return Ok(usersDto);
        }

        [HttpGet("{id}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUser(string id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound($"El usuario con el id {id} no existe");
            }
            var userDto = user.Adapt<UserDto>();
            return Ok(userDto);
        }
        [AllowAnonymous]
        [HttpPost(Name = "RegisterUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDto createUserDto)
        {
            if (createUserDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrWhiteSpace(createUserDto.Username))
            {
                return BadRequest("Username es requerido");
            }
            if (!_userRepository.IsUniqueUser(createUserDto.Username))
            {
                return BadRequest("El usuario ya existe");
            }
            var result = await _userRepository.Register(createUserDto);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al registrar el usuario");
            }
            //return CreatedAtRoute("GetUser", new { id = result.Id }, result);
            return Ok(result);
        }
        [Authorize] // Requiere que el usuario esté autenticado para validar su token anterior
        [HttpGet("check-status")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CheckStatus()
        {
            // 1. Obtener el ID del usuario directamente desde los Claims del Token JWT actual
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value
                              ?? User.FindFirst("id")?.Value; // Ajusta según cómo guardes el ID en tu JWT
            Console.Write(userIdClaim);
            if (string.IsNullOrEmpty(userIdClaim))
            {

                return Unauthorized();
            }

            // 2. Buscar al usuario en la base de datos para asegurarnos de que aún existe/está activo
            var user = _userRepository.GetUser(userIdClaim);
            if (user == null)
            {
                return Unauthorized();
            }

            // 3. Generar un NUEVO token de refresco (tu repositorio debería tener esta lógica al hacer Login)
            // Nota: Adapta "user" y el mapeo al método que uses en tu repositorio para generar tokens.
            var userLoginDto = new UserLoginDto { Username=user.UserName,Password=user.PasswordHash};
            var loginResult = await _userRepository.LoginAfterCheck(user); // O la lógica que uses para re-autenticar

            // 4. Adaptar el resultado al DTO de respuesta (que incluya user, token y message)
            return Ok(loginResult);
        }

        [AllowAnonymous]
        [HttpPost("Login", Name = "LoginUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto userLoginDto)
        {
            if (userLoginDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userRepository.Login(userLoginDto);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }

    }
}
