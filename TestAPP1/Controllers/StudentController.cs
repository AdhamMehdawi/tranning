﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPP1.Student;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestAPP1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentOps _st;
        IValidator<Student.StudentDto> _val;


        public StudentController(IStudentOps st, IValidator<Student.StudentDto> val)
        {
            _st = st;
            _val = val;
        }
        // api/student/get/raj

        [HttpGet("{name}")]
        public IActionResult GetStudent(string name)
        {
            //var calssName = "StudentOps";

            //typeof(StudentOps).GetMethods();

            if (string.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            var stList = _st.GetAllStudent();
            var stLsiStudents = stList.Where(x => x.Name == name).ToList();

            return Ok(stLsiStudents[0]);
        }


        [HttpGet("search/{name}")]
        public IActionResult GetStudentst(string name)
        {
            //var calssName = "StudentOps";

            //typeof(StudentOps).GetMethods();

            if (string.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            var stList = _st.GetAllStudent();
            var stLsiStudents = stList.Where(x => x.Name == name).ToList();

            return Ok(stLsiStudents[0]);
        }


        [HttpGet("search/id/{id}")]
        public IActionResult GetStudent(int id)
        { 
            return Ok(id );
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

    }

    public class ErrorObj{
        public string Message { get; set; }
        public string code { get; set; }
    }


}
