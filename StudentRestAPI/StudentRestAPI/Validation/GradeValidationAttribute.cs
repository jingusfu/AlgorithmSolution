using System.ComponentModel.DataAnnotations;

namespace StudentRestAPI.Validation
{
    public class GradeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var gradeStr = value.ToString();

            // Allow "K" 
            if (gradeStr.Equals("K", StringComparison.OrdinalIgnoreCase))
                return true;

            // Allow digits 1 through 12
            if (int.TryParse(gradeStr, out int grade))
                return grade >= 1 && grade <= 12;

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} must be 'K' or a number between 1 and 12.";
        }
    }
}
