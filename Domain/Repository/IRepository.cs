using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.People;

namespace Domain.Repository
{
    public interface IRepository
    {
        Task<IList<Person>> FindAsync();
        Task<Person> FindAsync(int Id);
        Task<Person> CreateAsync(Person person);
        Task<Person> UpdateAsync(Person person);
        Task DeleteAsync(Person person);
    }
}
