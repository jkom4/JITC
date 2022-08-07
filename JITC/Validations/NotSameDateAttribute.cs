using JITC.Models;
using System.ComponentModel.DataAnnotations;

namespace JITC.Validations
{
    public class NotSameDateAttribute : ValidationAttribute
    {
        public NotSameDateAttribute(string date) => DateDepart = date;
        public string DateDepart { get; }
        public string GetErrorMessage() => "La date d'arrivé doit être superieure a celui de départ et la date courante.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var vol = (Vol)validationContext.ObjectInstance;
            var dateArrive = ((DateTime)value!);
            if (vol.HeureDepartPrevue < DateTime.Now || (DateTime)dateArrive <= vol.HeureDepartPrevue)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}
