using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZeroCaos_BackEnd.Interfaces;
using ZeroCaos_BackEnd.Models;

namespace ZeroCaos_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Crud Methods
        private readonly IUserService _service;
        public UserController(IUserService service) { _service = service; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            return Ok(await _service.CreateAsync(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            var updateUser = await _service.UpdateAsync(id, user);
            if (updateUser == null) return NotFound();
            return Ok(updateUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteUser = await _service.DeleteAsync(id);
            if (!deleteUser) return NotFound();
            return Ok();
        }
        #endregion

        #region Custom Methods
        //Arreglar
        [HttpPost("login")]
        public async Task<IActionResult> Login(string user, string password)
        {
            await _service.LoginAsync(user, password);
            return Ok();
        }
        #endregion
    }
}
