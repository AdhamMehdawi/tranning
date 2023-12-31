﻿using FluentValidation;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestAPP1.Common;
using TestAPP1.Core.Models;
using TestAPP1.Domain.Entities;
using TestAPP1.Student; 

namespace TestAPP1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
//    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class StudentController : ControllerBase
    {
        private IStudentOps _st;
        IValidator<Student.StudentDto> _val;
        ILogger<StudentController> _logger;

        public StudentController(IStudentOps st, IValidator<Student.StudentDto> val, ILogger<StudentController> logger)
        {
            _st = st;
            _val = val;
            _logger = logger;
        }
        // api/student/get/raj
        [AllowAnonymous]
        [HttpGet("{name}")]
        public IActionResult GetStudent(string name)
        {
            _logger.LogInformation($"GetStudent method called with name {name}");
            //var calssName = "StudentOps";

            //typeof(StudentOps).GetMethods();

            if (string.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            var stList = _st.GetAllStudent();
            var stLsiStudents = stList.Where(x => x.StudentName == name).ToList();

            return Ok(stLsiStudents.FirstOrDefault());
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetStudentst()
        {  var student=new Student.StudentDto();
            student.StudentName = "Raj";

            var results =await _st.GetStudentAccountView();
            return Ok(results);
        }

        [HttpGet("search/{name}")]
        public IActionResult GetStudentst(string name)
        {
            ////var calssName = "StudentOps";

            ////typeof(StudentOps).GetMethods();

            //if (string.IsNullOrEmpty(name))
            //{
            //    return NotFound();
            //}
            //var stList = _st.GetAllStudent();
            //var stLsiStudents = stList.Where(x => x.StudentName == name).ToList();

           var results= _st.GetStudentAccountName();
           return Ok(results);
        }


        [HttpGet("search/id/{id}")]
        public IActionResult GetStudent(int id)
        { 
           var studentData= _st.GetStudentById(id);
            return Ok(studentData);
        }

        [HttpGet("searchById")]
        public IActionResult GetStudentById([FromQuery]int id)
        {
            return Ok(id);
        }

        //public IActionResult GetStudent([FromQuery]string  name)
        //{
        //    //var calssName = "StudentOps";

        //    //typeof(StudentOps).GetMethods();

        //    if (string.IsNullOrEmpty(name))
        //    {
        //        var stList2 = _st.GetAllStudent();
        //        return Ok(stList2[0]);
        //        //   return NotFound();
        //    }
        //    var stList = _st.GetAllStudent();
        //    var stLsiStudents = stList.Where(x => x.Name == name).ToList();

        //    return Ok(stLsiStudents[0]);
        //}

        //bool IsStudentExist(string name)
        //{
        //    StudentOps _st = new StudentOps();
        //    var stList = _st.GetAllStudent();
        //    foreach (var x in stList)
        //    {
        //        if (x.Name == name)
        //            return true;
        //    }
        //    return false;

        //}


        [HttpGet("GetAll")]
        public ActionResult<List<Student.StudentDto>> GetAllStudent()
        {
            Hangfire.RecurringJob.AddOrUpdate("testjob", () => _st.GetAllStudent(), Cron.Minutely);
            //RecurringJob.RemoveIfExists("testjob");
            return Ok(_st.GetAllStudent());
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddStudent(Student.StudentDto st, [FromServices] IStudentOps ops)
        {
            var result = _val.Validate(st);
            if (!result.IsValid)
            {
                List<ErrorObj> errors= result.Errors.Select(errorItem => new ErrorObj
                {
                    Message = errorItem.ErrorMessage,
                    code = errorItem.ErrorCode
                }).ToList(); 
                //foreach (var errorItem in result.Errors)
                //{
                //    var error = new ErrorObj();
                //    error.Message = errorItem.ErrorMessage;
                //    error.code = errorItem.ErrorCode;
                //    errors.Add(error); 
                //}
                return BadRequest(errors);
                //return BadRequest(result.Errors);

            }
            //if (st.Age < 18)
            //{
            //    var error = new ErrorObj();
            //    error.Message = "Age should be greater than 18";
            //    error.code = "1001";
            //    return BadRequest(error);
            //}
            await ops.AddStudent(st);
            return Ok(st);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("CreateStudentAccount")]
        public async Task<IActionResult> CreateStudentAccount(AccountDto account )
        {
         //   var a = typeof(AccountDto).GetProperties();
         //var b = typeof(Account).GetProperties();
         //foreach (var item in a)
         //{
         //                   var c = item.Name;
         //     var secPropertyInfo = b.FirstOrDefault(x => x.Name == c);
         //     if (secPropertyInfo != null)
         //     {
         //           var value = item.GetValue(account);
         //           secPropertyInfo.SetValue(account, value);
         //       }
         //}
            //
            
        var joibId=    BackgroundJob.Enqueue(() => _st.CreateStudentAccountAsync(account));
       //  var retsult=  await _st.CreateStudentAccountAsync(account);



            return Ok("Student Will be created soon!! ");
        }
    }

    public class ErrorObj{
        public string Message { get; set; }
        public string code { get; set; }
    }


}
