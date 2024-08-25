using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BookzoneProjNituDaniel.Models.Validators;
using BookzoneProjNituDaniel.Models.Input;
using BookzoneProjNituDaniel.Repositories.Validation;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookzoneProjNituDaniel.CustomFilters
{
    public class ValidatorFilterAttribute<TValidator,TInput>  : ActionFilterAttribute where TValidator : ValidatorBase<TInput> where TInput : InputBase
    {
        private readonly IValidationRepository _validationRepository;
        
        public string InputVariableName { get; set; } = null!;

        public ValidatorFilterAttribute(IValidationRepository validationRepository)
        {
            _validationRepository = validationRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }


            TValidator modelValidator;
            var constructorInfo = typeof(TValidator).GetConstructors()
                                        .OrderByDescending(c => c.GetParameters().Length)
                                        .FirstOrDefault();

            if (constructorInfo != null)
            {
                int parameterCount = constructorInfo.GetParameters().Length;
                if (parameterCount == 0)
                {
                    modelValidator = (TValidator)Activator.CreateInstance(typeof(TValidator))!;
                }
                else if (parameterCount == 1)   
                {
                    modelValidator = (TValidator)Activator.CreateInstance(typeof(TValidator),_validationRepository)!;
                }


            }

           
        }

        private void ValidateModel(ActionExecutingContext context, TValidator modelValidator)
        {
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
