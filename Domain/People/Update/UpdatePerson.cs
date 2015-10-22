using System.Threading.Tasks;
using Domain.Repository;
using MediatR;

namespace Domain.People.Update
{
    public class UpdatePerson : IAsyncRequest<Person>
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class UpdatePersonHandler : IAsyncRequestHandler<UpdatePerson, Person>
    {
        private readonly IRepository _repository;

        public UpdatePersonHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person> Handle(UpdatePerson update)
        {
            var person = await  _repository.FindAsync(update.Id);
            person.First = update.First;
            person.Last = update.Last;

            return await _repository.UpdateAsync(person);
        }
    }
}
