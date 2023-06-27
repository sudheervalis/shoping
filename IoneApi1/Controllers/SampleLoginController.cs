using DataAxisLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using QoneModel;
using System.Linq;

namespace IoneApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleLoginController : ControllerBase
    {
        private readonly JwtSettings jwtSettings;
        private readonly RaoneContext _context;
        public SampleLoginController(JwtSettings jwtSettings , RaoneContext context)
        {
            this.jwtSettings = jwtSettings;
            _context = context;
        }


    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<UserDatum>>> logins()
    //    {
    //        var userData = _context.UserData.ToList().
    //            Select (p => new
    //            {
                    
    //                Id  = Guid.NewGuid(),
    //                UserId = p.UserId ,
    //                Password  =p.Password ,
    //                UserName  = p.UserName ,
    //                UserRole  = p.UserRole,
    //                ConfirmPassword  = p.ConfirmPassword ,
    //                EmailId   =p.EmailId
    //}).ToList();

    //     return Ok(userData);

    //    }

    //    private IEnumerable<Users> logins = new List<Users>()
    //    {
    //        //new Users()
    //        //{
    //        //    Id = Guid.NewGuid(),
    //        //    EmailId = "adminakp@gmail.com",
    //        //    UserName ="Admin",
    //        //    Password="Admin",
    //        //},
    //        //new Users()
    //        //{
    //        //    Id = Guid.NewGuid(),
    //        //    EmailId = "adminakp@gmail.com",
    //        //    UserName ="User1",
    //        //    Password="Admin",
    //        //}
    //                    return await _context.UserData.ToListAsync();

    //};

        /// <summary>
        /// Generate an Access token
        /// </summary>
        /// <param name="userLogins"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public IActionResult GetToken(UserLogins userLogins)
        {
            try
            {
                var Token = new UserTokens();
                //var Valid = _context.UserData.Any(x => x.UserName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                var Valid = _context.UserData.Where(x => x.UserName.Equals(userLogins.UserName) && x.Password.Equals(userLogins.Password)).FirstOrDefault();
                if (Valid != null)
                {
                    var user = _context.UserData.Where(x => x.UserName.Equals(userLogins.UserName) && x.Password.Equals(userLogins.Password)).FirstOrDefault();
                    Token = JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        EmailId = user.EmailId,
                        GuidId = Guid.NewGuid(),
                        UserName = user.UserName,
                        Id = Guid.NewGuid(),

                    }, jwtSettings);
                }
                else
                {
                    return BadRequest($"wrong password");
                }
                return Ok(Token);
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Get List of UserAccounts   
        /// </summary>
        /// <returns>List Of UserAccounts</returns>
        //[HttpGet]
        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        //public IActionResult GetList()
        //{
        //    return Ok(logins);
        //}
    }
}