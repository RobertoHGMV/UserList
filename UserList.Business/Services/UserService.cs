using System.Collections.Generic;
using UserList.Domain.Interfaces.Services;
using UserList.Domain.Models;
using UserList.Domain.ViewModels.UsersViewModel;

namespace UserList.Business.Services
{
    public class UserService : IUserService
    {
        public ICollection<ListUserModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ListUserModel GetByKey(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(EditorUserModel user)
        {
            throw new System.NotImplementedException();
        }

        public void Update(EditorUserModel user)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }        
    }
}