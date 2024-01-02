using System.ComponentModel.DataAnnotations;


namespace BlazorApp122024.Shared
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Input Name Limit Exceeds", MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        [Range(21, int.MaxValue, ErrorMessage = "Age should be above 20")]
        public int Age { get; set; }

        [Required]
        public int Salary { get; set; }
    }
}
