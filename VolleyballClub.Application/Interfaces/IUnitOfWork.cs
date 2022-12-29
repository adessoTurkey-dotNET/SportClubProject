namespace VolleyballClubProject.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
