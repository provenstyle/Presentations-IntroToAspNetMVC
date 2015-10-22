using System.Threading.Tasks;
using Domain.Repository;
using MediatR;

namespace Domain.People.Delete
{
    public class DeletePerson : IAsyncRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeletePersonHandler : IAsyncRequestHandler<DeletePerson, Unit>
    {
        private readonly IRepository _repository;

        public DeletePersonHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePerson deletePerson)
        {
             await _repository.DeleteAsync(deletePerson.Id);
            return Unit.Value;
        }
    }
}
