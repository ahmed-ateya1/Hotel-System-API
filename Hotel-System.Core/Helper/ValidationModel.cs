using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Core.Helper
{
    public static class ValidationModel
    {
        public static void ValidModel(object? model)
        {
            if(model == null)
                throw new ArgumentNullException(nameof(model));

            var validationContext = new ValidationContext(model);
            var vaidationResults = new List<ValidationResult>();

            bool IsValid = Validator.
                TryValidateObject(model, validationContext, vaidationResults, true);

            if (!IsValid)
                throw new ArgumentException();

        }
    }
}
