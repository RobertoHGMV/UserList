

using System.Collections.Generic;
using UserList.Domain.Interfaces.Repositories;
using UserList.Domain.Models;

namespace UserList.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public User GetByKey(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}