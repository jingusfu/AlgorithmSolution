using System.ComponentModel.DataAnnotations;
using StudentRestAPI.Validation;

namespace StudentRestAPI.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Id is required.")]
        public long Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "First Name is required.")]
        public String FirstName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Last Name is required.")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DateBeforeToday(ErrorMessage = "Date of birth must be before today.")]
        public DateOnly? DateOfBirth { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Grade is required.")]
        [GradeValidation(ErrorMessage = "Grade must be 'K' or a number between 1 and 12.")]
        public String Grade { get; set; }

        [RegularExpression(@"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$", ErrorMessage = "Invalid phone number format.")]
        public string? Phone {  get; set; }
        /*
         The regex for phone above will match several valid formats for US phone numbers, including:
            (123) 456-7890
            123-456-7890
            123.456.7890
            123 456 7890
        */

    }
}
