using System.Collections.Generic;
using UserList.Domain.Models;
using UserList.Domain.ViewModels.UsersViewModel;

namespace UserList.Domain.Interfaces.Services
{
    public interface IUserService
    {
        User GetByKey(int id);
        ICollection<ListUserModel> GetAll();
        ListUserModelPagination GetAll(int skip, int take);
        void Add(RegisterUserModel userEditor);
        void Update(EditorUserModel userEditor);
        void Delete(int id);
    }
}