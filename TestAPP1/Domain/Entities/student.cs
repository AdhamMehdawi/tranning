using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestAPP1.Student;

namespace TestAPP1.Domain.Entities
{
    [Table("Student", Schema = "st")]
    public class Student  
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(50)] 
        public string StudentName { get; set; }

        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; } 
        public bool IsDeleted { get; set; } 
        public bool? IsActive { get; set; }
        [InverseProperty("Student")]
        public List<Account> Account { get; set; }

    }
}
