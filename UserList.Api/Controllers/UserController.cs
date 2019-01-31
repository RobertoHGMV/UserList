using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserList.Domain.Interfaces.Services;
using UserList.Domain.ViewModels.UsersViewModel;

namespace UserList.Api.Controllers
{
    public class UserController : BaseController
    {
        IUserService _service;

        [HttpGet]
        [Route("v1/user/{id}")]
        public IActionResult Get(int id)
        {
            var user = _service.GetByKey(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("v1/user")]
        public async Task<IActionResult> Add([FromBody] EditorUserModel userModel)
        {
            _service.Add(userModel);
            return await ResponsePoint("Usuário cadastrado com sucesso", userModel.Notifications);
        }
    }
}