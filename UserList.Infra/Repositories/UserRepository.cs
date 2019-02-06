using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserList.Domain.Interfaces.Repositories;
using UserList.Domain.Models;
using UserList.Domain.ViewModels.UsersViewModel;
using UserList.Infra.Contexts;

namespace UserList.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        StoredDataContext _context;

        public UserRepository(StoredDataContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public User GetByKey(int id)
        {
            return _context.Users.Find(id);
        }

        public ICollection<ListUserModel> GetAll()
        {
            return _context.Users.Select(c => new ListUserModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName
            }).AsNoTracking().ToList();
        }

        public ICollection<ListUserModel> GetAll(int skip, int take)
        {
            return _context.Users.Select(c => new ListUserModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName
            }).AsNoTracking().Skip(skip).Take(take).ToList();
        }
    }
}