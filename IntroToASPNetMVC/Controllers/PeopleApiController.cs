using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Domain.People;
using Domain.People.Delete;
using Domain.People.Get;
using MediatR;

namespace IntroToASPNetMVC.Controllers
{
    public class PeopleApiController : ApiController
    {
        private readonly IMediator _mediator;

        public PeopleApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("Api/People")]
        public async Task<IEnumerable<Person>> AllPeople()
        {
            return await _mediator.SendAsync(new GetPeople());
        }

        [HttpGet, Route("Api/Person/{id}")]
        public async Task<Person> GetPerson([FromUri]GetPerson getPerson)
        {
            return await _mediator.SendAsync(getPerson);
        }

        [HttpDelete, Route("Api/Person/{id}")]
        public async Task<Unit> DeletePerson([FromUri]DeletePerson deletePerson)
        {
            return await _mediator.SendAsync(deletePerson);
        }
    }
}
