using System;
using System.Collections.Generic;
using System.Linq;
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

        public ListUserModelPagination GetAll(int page, int qtdPerPage)
        {
            var skip = (page - 1) * qtdPerPage;
            var take = qtdPerPage;
            var usersModel = _userRepository.GetAll(skip, take);
            var usersTotal = _userRepository.GetTotalUsers();

            var listPagination = new ListUserModelPagination();
            listPagination.UsersModel = usersModel;
            listPagination.Total = usersTotal;
            listPagination.Limit = take;

            var pagesQtd = Math.Ceiling(Convert.ToDecimal(listPagination.Total) / Convert.ToDecimal(take));
            var currentPage = Math.Ceiling(Convert.ToDecimal(skip) / Convert.ToDecimal(take)) + 1;

            listPagination.Pages = Convert.ToInt32(pagesQtd);
            listPagination.Page = Convert.ToInt32(currentPage);

            return listPagination;
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