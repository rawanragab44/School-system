using System.ComponentModel.DataAnnotations;

namespace Web_API_task1.Models
{
    public class uniqueNameValidationAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ITIentity context = new ITIentity();
           string name = value.ToString();
            var department = context.Departments.FirstOrDefault(s => s.Name == name);
            if (department == null)
            {
                 return ValidationResult.Success;
            }
              return new ValidationResult("Name already exists");
        }
    }

    public class locationInAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string location = value.ToString();
            if (location == "EG" || location == "USA")
            {
                return ValidationResult.Success;
            }
                return new ValidationResult("Location must be in either Egypt or USA");
        }
    }
}
