using UserList.Domain.Repositories;
using UserList.Infra.Contexts;

namespace UserList.Infra.Transactions
{
    public class Uow : IUow
    {
        StoredDataContext _context;

        public Uow(StoredDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            
        }
    }
}