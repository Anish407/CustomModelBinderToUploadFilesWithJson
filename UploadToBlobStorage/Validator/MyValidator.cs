using FluentValidation;
using UploadToBlobStorage.Models;

namespace UploadToBlobStorage.Validator
{
    public class CustomerValidator : AbstractValidator<Sample>
    {
        public CustomerValidator()
        {
           RuleFor(i=> i.Name).NotEmpty().NotNull();
           RuleFor(i=> i.Age).GreaterThan(10);
        }

      
    }
}
