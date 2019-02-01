using System.Collections.Generic;
using UserList.Domain.Interfaces.Repositories;
using UserList.Domain.Interfaces.Services;
using UserList.Domain.Models;
using UserList.Domain.Repositories;
using UserList.Domain.ValueObjects;
using UserList.Domain.ViewModels.UsersViewModel;

namespace UserList.Business.Services
{
    public class UserService : IUserService
    {
        IUow _uow;
        IUserRepository _userRepository;

        public UserService(IUow uow, IUserRepository userRepository)
        {
            _uow = uow;
            _userRepository = userRepository;
        }

        public User GetByKey(int id)
        {
            return _userRepository.GetByKey(id);
        }

        public ICollection<ListUserModel> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Add(RegisterUserModel userEditor)
        {
            var name = new Name(userEditor.FirstName, userEditor.LastName);
            var user = new User(name);
            _userRepository.Add(user);
            _uow.Commit();
        }

        public void Update(EditorUserModel userEditor)
        {
            var user = _userRepository.GetByKey(userEditor.Id);
            var name = new Name(userEditor.FirstName, userEditor.LastName);
            user.Update(name);
            _uow.Commit();
        }

        public void Delete(int id)
        {
            var user = _userRepository.GetByKey(id);
            _userRepository.Delete(user);
            _uow.Commit();
        }        
    }
}