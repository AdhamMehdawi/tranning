using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPP1.DbContext;
using TestAPP1.Domain.Entities;

namespace TestAPP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class SystemAccountController : ControllerBase
    {
        private readonly AppDbContext _db;
        public SystemAccountController(AppDbContext db)
        {
            this._db = db;
        }
        [Authorize(Policy = "MobilePolicy")]
        [HttpGet("Get")]
        public async Task<IActionResult> GetSystemAccount()
        {
           
            var list= await _db.AccountType.ToListAsync();
            //AccountType accounttype = new AccountType();
            //accounttype.AccountTypeName = "System Account";
            //accounttype.Id = 1;
            return Ok(list);
        }

        //[Authorize(Policy = "MobilePolicy1")]
        //[HttpGet("Get")]
        //public async Task<IActionResult> GetSystemAccount3()
        //{

        //    var list = await _db.AccountType.ToListAsync();
        //    //AccountType accounttype = new AccountType();
        //    //accounttype.AccountTypeName = "System Account";
        //    //accounttype.Id = 1;
        //    return Ok(list);
        //}

        //[HttpGet("Get")]
        //public async Task<IActionResult> GetSystemAccount1()
        //{
        //     var list = await _db.AccountType.ToListAsync();
        //    //AccountType accounttype = new AccountType();
        //    //accounttype.AccountTypeName = "System Account";
        //    //accounttype.Id = 1;
        //    return Ok(list);
        //}

    }
}
