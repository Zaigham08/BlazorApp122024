using System.ComponentModel.DataAnnotations;


namespace BlazorApp122024.Shared
{
    public class Course
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int Marks { get; set; }
    }
}
