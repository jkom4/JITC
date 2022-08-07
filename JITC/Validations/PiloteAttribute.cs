using JITC.Models;
using System.ComponentModel.DataAnnotations;

namespace JITC.Validations
{
    public class PiloteAttribute : ValidationAttribute

    {
        public string GetErrorMessage() => "Ce pilote n'est pas disponible Pour cet horaire";
        protected override  ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            JITCDbContext db = (JITCDbContext)validationContext.GetService(typeof(JITCDbContext));
            var vol = (Vol)validationContext.ObjectInstance;
            var vols = db.Vol.Where(v => v.HeureDepartPrevue <= vol.HeureDepartPrevue || v.HeureArrivePrevue >= vol.HeureArrivePrevue).ToList();
            var piloteId = ((string)value!);
            if (vols.Any())
            {
                foreach (var item in vols)
                {
                    if (item.PiloteId == piloteId) {
                        return new ValidationResult(GetErrorMessage());
                    }
                }
            }
            return base.IsValid(value, validationContext);
        }
    }
}
