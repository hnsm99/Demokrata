using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TestJelmi.Models;
using TestJelmi.Repositories.Interfaces;

namespace TestJelmi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("Create")]
        public IActionResult Create(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = _userRepository.GetAll();
            var Existuser = users.Where(x => x.PrimerNombre.Equals(user.PrimerNombre) && x.SegundoNombre.Equals(user.SegundoNombre) && x.PrimerApellido.Equals(user.PrimerApellido) && x.SegundoApellido.Equals(user.SegundoApellido) && x.FechaNacimiento.ToString("dd/mm/yyyy").Equals(user.FechaNacimiento.ToString("dd/mm/yyyy"))).FirstOrDefault();
            if (Existuser == null)
            {
                user.FechaCreacion = DateTime.Now;
                user.FechaModificacion = DateTime.Now;

                _userRepository.Add(user);

                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            else
            {
                return Conflict(new {id= Existuser.Id,message="Usuario con esa información, ya se encuentra registrado" });
            }
        }

        [HttpGet("(ObtenerxId/{id})")]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = _userRepository.GetById(user.Id);
            if (existingUser == null)
            {
                return NotFound();
            }

            user.FechaModificacion = DateTime.Now;

            return Ok(_userRepository.Update(user));
        }

        [HttpDelete("(Eliminar/{id})")]
        public IActionResult Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_userRepository.Delete(user));
        }

        [HttpGet("SearchxFsOrLn")]
        public IActionResult Search(string firstName = "", string lastName = "", int page = 1, int pageSize = 10)
        {
            var users = _userRepository.Search(firstName, lastName, page, pageSize);
            return Ok(users);
        }
    }
}
