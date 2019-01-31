using System.Collections.Generic;
using UserList.Domain.Models;
using UserList.Domain.ViewModels.UsersViewModel;

namespace UserList.Domain.Interfaces.Services
{
    public interface IUserService
    {
        ListUserModel GetByKey(int id);
        ICollection<ListUserModel> GetAll();
        void Add(EditorUserModel user);
        void Update(EditorUserModel user);
        void Delete(int id);
    }
}