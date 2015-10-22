using System.Threading.Tasks;
using Domain.Repository;
using MediatR;

namespace Domain.People.Get
{
    public class GetPersonHandler : IAsyncRequestHandler<GetPerson, Person>
    {
        private readonly IRepository _repository;

        public GetPersonHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person> Handle(GetPerson getPerson)
        {
            return await _repository.FindAsync(getPerson.Id);
        }
    }
}