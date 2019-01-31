using UserList.Domain.ValueObjects;

namespace UserList.Domain.Models
{
    public class User
    {
        protected User() { }

        public User(Name name)
        {
            FirstName = name.FirstName;
            LastName = name.LastName;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public void Update(Name name)
        {
            FirstName = name.FirstName;
            LastName = name.LastName;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}