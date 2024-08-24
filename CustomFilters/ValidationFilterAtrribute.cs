using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BookzoneProjNituDaniel.Models.Validators;
using BookzoneProjNituDaniel.Models.Input;

namespace BookzoneProjNituDaniel.CustomFilters
{
    public class ValidatorFilterAttribute<TValidator,TInput>  : ActionFilterAttribute where TValidator : ValidatorBase<TInput> where TInput : InputBase
    {
        public string InputVariableName { get; set; } = null!;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            TValidator modelValidator = (TValidator)Activator.CreateInstance(typeof(TValidator))!;

            var model = (TInput)context.ActionArguments[InputVariableName]!;
            var validationErrors = modelValidator.Validate(model);
            if (!validationErrors.IsValid)
            {
                validationErrors.Errors.ForEach(err =>
                {
                    context.ModelState.Remove(err.PropertyName);
                    context.ModelState.AddModelError(err.PropertyName, err.ErrorMessage);
                });
            }
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}
