using System.Collections.Generic;
using System.Linq;

namespace UserList.Domain.ViewModels.UsersViewModel
{
    public class RegisterUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<string> Notifications { get; private set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(FirstName))
                Notifications.Add("Primeiro nome não informado");

            if (string.IsNullOrEmpty(LastName))
                Notifications.Add("Sobrenome não informado");
        }

        public bool IsValid() => !Notifications.Any();
    }
}