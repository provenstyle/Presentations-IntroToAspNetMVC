using System.Text;
using System.Threading.Tasks;
using Domain.Repository;
using MediatR;

namespace Domain.People.Create
{
    public class CreatePerson : IAsyncRequest<CreatePersonResponse>
    {
        public string First { get; set; }
        public string Last  { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine().Append(nameof(CreatePerson)).AppendLine("{")
                .AppendFormat("    {0}: {1}", nameof(First), First).AppendLine()
                .AppendFormat("    {0}: {1}", nameof(Last), Last).AppendLine()
                .AppendLine("}");
            return builder.ToString();
        }
    }

    public class CreatePersonResponse
    {
        public int Id { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine().Append(nameof(CreatePersonResponse)).AppendLine("{")
                .AppendFormat("    {0}: {1}", nameof(Id), Id).AppendLine()
                .AppendLine("}");
            return builder.ToString();
        }
    }

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
