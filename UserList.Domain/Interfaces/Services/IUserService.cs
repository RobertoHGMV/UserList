using System.Collections.Generic;
using UserList.Domain.Models;

namespace UserList.Domain.Interfaces.Services
{
    public interface IUserService
    {
        User GetByKey(int id);
        ICollection<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}