using System.ComponentModel.DataAnnotations;
using Mapster;
using Microsoft.EntityFrameworkCore;
using TestAPP1.Core.Models;
using TestAPP1.DbContext;
using TestAPP1.Domain.Entities;

namespace TestAPP1.Student
{

    public interface IStudentOps
    {
        List<StudentDto> GetAllStudent();
        Task<List<StudentDto>> AddStudent(StudentDto st);
        int CalculateAge();
        StudentDto GetStudentById(int id);
        Task<AccountDto> CreateStudentAccountAsync(AccountDto account);

        List<StudentAccountName> GetStudentAccountName();
        Task<List<StudentAccountView>> GetStudentAccountView();
    }
    public class StudentDal
    {

    }

    //public class StudentOps2 : IStudentOps
    //{
    //    public List<StudentDto> GetAllStudent()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<List<StudentDto>> AddStudent(StudentDto st)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int CalculateAge()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    public class StudentOps : IStudentOps
    {
        AppDbContext _appContext;
        public StudentOps(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public List<StudentDto> GetAllStudent()
        {
            //_appContext.Database.SqlQueryRaw<StudentDto>("select * from st.Student");

            var list = _appContext.Students.ToList();
            return list.Adapt<List<StudentDto>>();
        }


        public StudentDto GetStudentById(int id)
        {
            var aa = "select * from st.Student where id = 1";
            var list = _appContext.Students.Where(c => c.Id == id);
            var studnet = _appContext.Students.Find(id);
            var studnet1 = _appContext.Students.FirstOrDefault(c => c.Id == id);


            var studnet2 = _appContext.Students.SingleOrDefault(c => c.Id == id);

            //if (id == 1)
            //{
            //    //
            //    aa += " and name = 'aa'";
            //    list = list.Where(c => c.StudentName.Contains("aa"));
            //}

            //if (id == 2)
            //{
            //    aa += " and name = 'bb'";
            //    list = list.Where(c => c.StudentName.Contains("bb"));

            //}
            var sql = list.ToQueryString();
            //Thread.Sleep(1000);
            var restult = list.FirstOrDefault() ?? new Domain.Entities.Student();
            return restult.Adapt<StudentDto>();
        }


        public async Task<AccountDto> CreateStudentAccountAsync(AccountDto account)
        {
            var accountEntity = account.Adapt<Domain.Entities.Account>();
            _appContext.Accounts.Add(accountEntity);
            // List<Task> tasks = new List<Task>();
            // tasks.Add(_appContext.SaveChangesAsync());
            // tasks.Add(_appContext.SaveChangesAsync());
            // tasks.Add(_appContext.SaveChangesAsync());
            // tasks.Add(_appContext.SaveChangesAsync());
            // tasks.Add(_appContext.SaveChangesAsync());
            //var resut =  Task.WaitAny(tasks.ToArray());
            // var res = Task.WhenAll(tasks.ToArray());
            //    res.GetAwaiter().GetResult();

            await _appContext.SaveChangesAsync();

            return accountEntity.Adapt<AccountDto>();
        }

        public List<StudentAccountName> GetStudentAccountName()
        {
            //select * from st.Student s left join account a on s.id = a.studentid
            //where a.accountnumber like '%123%' and s.studentname like '%ali%'

            var list = _appContext.Accounts
                .Include(c => c.Student)
                .Select(c => new StudentAccountName
                {
                    StudentName = c.AccoutName,
                    AccountName = c.Student.StudentName
                });
            var sql = list.ToQueryString();
            return list.Adapt<List<StudentAccountName>>();
        }

        public async Task<List<StudentAccountView>> GetStudentAccountView()
        {
          return  await _appContext.StudentAccountView.ToListAsync();
        }

        public async Task<List<StudentDto>> AddStudent(StudentDto st)
        {
            var student = st.Adapt<Domain.Entities.Student>();
            student.Account = st.Accounts.Adapt<List<Domain.Entities.Account>>();
            _appContext.Students.Add(student);
            _appContext.Students.Add(student);
            _appContext.Students.Add(student);
            _appContext.Students.Add(student);
            _appContext.Students.Add(student);
            _appContext.Students.Add(student);
            _appContext.Students.Add(student);
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

    public class StudentAccountName
    {
        public string StudentName { get; set; }
        public string AccountName { get; set; }
    }
    public class StudentDto : IAuditEntity, ISoftDelete
    {
        public StudentDto()
        {
            Accounts = new List<AccountDto>();
        }
        //  [EmailAddress]
        //[CreditCard]
        //[Phone]
        //[Url]
        //[Required]
        //[MaxLength(10)]
        //[DataType(DataType.DateTime)]
        public string Email { get; set; }
        //    [RegularExpression("[0,9]*")]
        public string StudentName { get; set; }

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

        public List<AccountDto> Accounts { get; set; }

    }
}
