using UserList.Domain.ValueObjects;

namespace UserList.Domain.Models
{
    public class User
    {
        public User(Name name)
        {
            Name = name;
        }

        public int Id { get; private set; }

        public Name Name { get; private set; }

        public void Update(Name name)
        {
            Name = name;
        }
    }
}