using System.Text;
using System.Threading.Tasks;
using Domain.Repository;
using MediatR;

namespace Domain.People.Delete
{
    public class DeletePerson : IAsyncRequest<Unit>
    {
        public int Id { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine().Append(nameof(DeletePerson)).AppendLine("{")
                .AppendFormat("    {0}: {1}", nameof(Id), Id).AppendLine()
                .AppendLine("}");
            return builder.ToString();
        }
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
