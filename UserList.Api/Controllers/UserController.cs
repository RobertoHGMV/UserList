using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserList.Api.ViewModels;
using UserList.Domain.Interfaces.Services;
using UserList.Domain.ViewModels;
using UserList.Domain.ViewModels.UsersViewModel;

namespace UserList.Api.Controllers
{
    public class UserController : Controller
    {
        IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        private Task<IActionResult> GetResult(IActionResult result)
        {
            var taskSource = new TaskCompletionSource<IActionResult>();
            taskSource.SetResult(result);
            return taskSource.Task;
        }

        [HttpGet]
        [Route("v1/users/{id}")]
        public Task<IActionResult> Get(int id)
        {
            IActionResult result;

            try
            {
                var user = _service.GetByKey(id);
                result = Ok(new ResultViewModel { Success = true, Message = "Operação realizada com sucesso", Data = user });
            }
            catch (Exception ex)
            {
                result = BadRequest(new ResultViewModel { Success = false, Message = ex.Message, Data = ex });
            }

            return GetResult(result);
        }

        [HttpGet]
        [Route("v1/users")]
        public Task<IActionResult> GetAll()
        {
            IActionResult result;

            try
            {
                var users = _service.GetAll();
                result = Ok(new ResultViewModel { Success = true, Message = "Operação realizada com sucesso", Data = users });
            }
            catch (Exception ex)
            {
                result = BadRequest(new ResultViewModel { Success = false, Message = ex.Message, Data = ex });
            }

            return GetResult(result);
        }

        [HttpPost]
        [Route("v1/users")]
        public Task<IActionResult> Add([FromBody] RegisterUserModel userModel)
        {
            IActionResult result;

            try
            {
                _service.Add(userModel);
                result = Ok(new ResultViewModel { Success = true, Message = "Usuário cadastrado com sucesso" });
            }
            catch (Exception ex)
            {
                result = BadRequest(new ResultViewModel { Success = false, Message = ex.Message, Data = ex });
            }

            return GetResult(result);
        }

        [HttpPut]
        [Route("v1/users")]
        public Task<IActionResult> Update([FromBody] EditorUserModel userModel)
        {
            IActionResult result;

            try
            {
                _service.Update(userModel);
                result = Ok(new ResultViewModel { Success = true, Message = "Usuário editado com sucesso" });
            }
            catch (Exception ex)
            {
                result = BadRequest(new ResultViewModel { Success = false, Message = ex.Message, Data = ex });
            }

            return GetResult(result);
        }

        [HttpDelete]
        [Route("v1/users")]
        public Task<IActionResult> Delete([FromBody] DeleteModel userModel)
        {
            IActionResult result;

            try
            {
                _service.Delete(userModel.Id);
                result = Ok(new ResultViewModel { Success = true, Message = "Usuário removido com sucesso" });
            }
            catch (Exception ex)
            {
                result = BadRequest(new ResultViewModel { Success = false, Message = ex.Message, Data = ex });
            }

            return GetResult(result);
        }
    }
}