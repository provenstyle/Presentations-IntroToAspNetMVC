using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace IntroToASPNetMVC.Filters
{
    public class ValidationExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception as FluentValidation.ValidationException;
            if (exception != null)
            {
                var controller = (Controller) context.Controller;

                exception.Errors.ForEach(e => 
                    controller.ModelState.AddModelError(e.PropertyName, e.ErrorMessage));

                context.Result = new ViewResult
                {
                    ViewName = null,
                    MasterName = null,
                    TempData = context.Controller.TempData,
                    ViewData = context.Controller.ViewData,
                    ViewEngineCollection = controller.ViewEngineCollection
                };
                context.ExceptionHandled = true;
            }
        }
    }
}