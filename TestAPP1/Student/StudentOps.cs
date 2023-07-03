using System.ComponentModel.DataAnnotations;

namespace TestAPP1.Student
{

    public interface IStudentOps
    {
        List<Student> GetAllStudent();
        List<Student> AddStudent(Student st);
        int CalculateAge();
    }
    public class StudentDal
    {

    }

    public class StudentOps2 : IStudentOps
    {
        public List<Student> GetAllStudent()
        {
            throw new NotImplementedException();
        }

        public List<Student> AddStudent(Student st)
        {
            throw new NotImplementedException();
        }

        public int CalculateAge()
        {
            throw new NotImplementedException();
        }
    }
    public class StudentOps : IStudentOps
    {
        List<Student> studntList;
        public StudentOps()
        {
            studntList = new List<Student>();

        }

        public List<Student> GetAllStudent()
        {
            studntList = new List<Student>();
            studntList.Add(new Student { Name = "Raj", Age = 20 });
            studntList.Add(new Student { Name = "Raj2", Age = 25 });
            studntList.Add(new Student { Name = "Raj2", Age = 24 });
            studntList.Add(new Student { Name = "Raj3", Age = 28 });
            studntList.Add(new Student { Name = "Raj4", Age = 27 });
            studntList.Add(new Student { Name = "Raj5", Age = 26 });
            return studntList;
        }

        public List<Student> AddStudent(Student st)
        {
            studntList.Add(st);
            return studntList;
        }

        public int CalculateAge()
        {
            throw new NotImplementedException();
        }
    }

    public interface IAuditEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }

    public class Student : IAuditEntity, ISoftDelete
    {
      //  [EmailAddress]
        //[CreditCard]
        //[Phone]
        //[Url]
        //[Required]
        //[MaxLength(10)]
        //[DataType(DataType.DateTime)]
        public string Email { get; set; }
    //    [RegularExpression("[0,9]*")]
        public string Name { get; set; }

        //[Required]
        //[Range(18, 60,ErrorMessage = "Age must be between 18 and 60.")]
        public int Age { get; set; }
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
    //    [DataType(DataType.DateTime)]

        public string CreatedDate1 { get; set; }
        public DateTime ModifiedDate { get; set; }
       // [Required]
        public bool IsDeleted { get; set; }

       // [Required]
        public bool? IsActive { get; set; }


    }
}
