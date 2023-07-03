using System.ComponentModel.DataAnnotations;
using Mapster;
using TestAPP1.DbContext;

namespace TestAPP1.Student
{

    public interface IStudentOps
    {
        List<StudentDto> GetAllStudent();
        Task<List<StudentDto>> AddStudent(StudentDto st);
        int CalculateAge();
    }
    public class StudentDal
    {

    }

    public class StudentOps2 : IStudentOps
    {
        public List<StudentDto> GetAllStudent()
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentDto>> AddStudent(StudentDto st)
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
        AppDbContext _appContext;
        public StudentOps(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public List<StudentDto> GetAllStudent()
        {
            var list = _appContext.Students.ToList();
           return list.Adapt<List<StudentDto>>();
        }

        public async Task<List<StudentDto>> AddStudent(StudentDto st)
        {
            var student= st.Adapt<Domain.Entities.Student>();
            _appContext.Students.Add(student);
           await _appContext.SaveChangesAsync();
           return GetAllStudent();
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

    public class StudentDto : IAuditEntity, ISoftDelete
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
