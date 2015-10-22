using FluentValidation;

namespace Domain.People.Create
{
    public class CreatePersonValidation : AbstractValidator<CreatePerson>
    {
        public CreatePersonValidation()
        {
            RuleFor(x => x.First).NotEmpty().WithMessage("You must supply a first name.");
            RuleFor(x => x.Last).NotEmpty().WithMessage("You must supply a last name.");
        }
    }
}