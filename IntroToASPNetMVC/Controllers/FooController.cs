using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace IntroToASPNetMVC.Controllers
{
    public class FooController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            var result = new PersonValidation().Validate(person);
            throw new FluentValidation.ValidationException(result.Errors);


            return View();
        }
    }

    public class Person
    {
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class PersonValidation : AbstractValidator<Person>
    {
        public PersonValidation()
        {
            RuleFor(x => x.First).NotEmpty().WithMessage("You must supply a first name.");
            RuleFor(x => x.Last).NotEmpty().WithMessage("You must supply a last name.");
        }
    }
}