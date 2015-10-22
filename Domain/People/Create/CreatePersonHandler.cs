using System.Threading.Tasks;
using Domain.Repository;
using MediatR;

namespace Domain.People.Create
{
    public class CreatePersonHandler: IAsyncRequestHandler<CreatePerson, CreatePersonResponse>
    {
        private readonly IRepository _repository;

        public CreatePersonHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreatePersonResponse> Handle(CreatePerson message)
        {
            var response = await _repository.CreateAsync(new Person
            {
                First = message.First,
                Last = message.Last
            });

            return new CreatePersonResponse
            {
                Id = response.Id
            };
        }
    }
}