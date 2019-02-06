using System.Collections.Generic;
using UserList.Domain.Models;
using UserList.Domain.ViewModels.UsersViewModel;

namespace UserList.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetByKey(int id);
        ICollection<ListUserModel> GetAll();
        ICollection<ListUserModel> GetAll(int skip, int take);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}