namespace UserList.Domain.Repositories
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}