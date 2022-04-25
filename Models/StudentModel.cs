using System.ComponentModel.DataAnnotations;

namespace SampleApp.ASPDotNETCore.Models
{
    public class StudentModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
