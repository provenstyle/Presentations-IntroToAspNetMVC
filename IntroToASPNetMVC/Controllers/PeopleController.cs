using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.People.Create;
using Domain.People.Get;
using MediatR;

namespace IntroToASPNetMVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IMediator _mediator;

        public PeopleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> Index()
        {
            var people = await _mediator.SendAsync(new GetPeople());
            return View(people);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePerson createPerson)
        {
            var person = await _mediator.SendAsync(createPerson);
            return RedirectToAction("Read", new {Id = person.Id});
        }

        public async Task<ActionResult> Read(GetPerson getPerson)
        {
            var person = await _mediator.SendAsync(getPerson);
            return View(person);
        }
    }
}