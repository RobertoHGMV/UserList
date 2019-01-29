using System;

namespace UserList.Domain.ValueObjects
{
    public class Name
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            Validate();
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(FirstName))
                throw new Exception("Nome inválido");

            if (string.IsNullOrEmpty(LastName))
                throw new Exception("Sobrenome inválido");
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}