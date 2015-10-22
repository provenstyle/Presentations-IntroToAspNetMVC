using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.People;

namespace Domain.Repository
{
    public class Repository : IRepository
    {
        public static IList<Person> _people = new List<Person>(); 

        public Task<IList<Person>> FindAsync()
        {
            return Task.FromResult(_people);
        }

        public Task<Person> FindAsync(int Id)
        {
            return Task.FromResult(_people.FirstOrDefault(x => x.Id == Id));
        }

        public async Task<Person> CreateAsync(Person person)
        {
            if (await FindAsync(person.Id) != null) throw new Exception("Person already exists");
            var localPerson = new Person
            {
                First = person.First,
                Last = person.Last,
                Id = _people.Count() + 1
            };
            _people.Add(localPerson);
            return localPerson;
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            var localPerson = await FindAsync(person.Id);
            localPerson.First = person.First;
            localPerson.Last = person.Last;
            return localPerson;
        }

        public async Task DeleteAsync(Person person)
        {
            _people.Remove(await FindAsync(person.Id));
        }
    }
}