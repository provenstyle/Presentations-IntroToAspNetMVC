using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Repository;
using MediatR;

namespace Domain.People.Get
{
    public class GetPeopleHandler : IAsyncRequestHandler<GetPeople, IEnumerable<Person>>
    {
        private readonly IRepository _repository;

        public GetPeopleHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Person>> Handle(GetPeople getPeople)
        {
            return await _repository.FindAsync();
        }
    }
}