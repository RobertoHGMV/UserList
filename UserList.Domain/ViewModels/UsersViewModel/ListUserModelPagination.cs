using System.Collections.Generic;

namespace UserList.Domain.ViewModels.UsersViewModel
{
    public class ListUserModelPagination
    {
        public IEnumerable<ListUserModel> UsersModel { get; set; }
        public int Total { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
    }
}