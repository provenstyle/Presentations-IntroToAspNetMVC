using System.Threading.Tasks;
using MediatR;

namespace Domain.People.Get
{
    public class GetPerson : IAsyncRequest<Person>
    {
        public int Id { get; set; }
    }

    public class GetPersonHandler : IAsyncRequestHandler<GetPerson, Person>
    {
        public Task<Person> Handle(GetPerson message)
        {
            return Task.FromResult(new Person
            {
                First = "Impelement",
                Last = "Me"
            });
        }
    }
}
