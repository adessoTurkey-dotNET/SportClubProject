using VolleyballClubProject.Core.Common;
using VolleyballClubProject.Core.Entities;

namespace VolleyballClubProject.Application.Interfaces
{
    public interface IPersonRepository : IBaseInterface<Person>
    {
        Task AddProduct(int personId, int productId);
        Task<Person> GetPersonWithProducts(int personId);
    }
}
