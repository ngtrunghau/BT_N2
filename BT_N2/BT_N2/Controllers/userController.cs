using BT_N2.Data;
using BT_N2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BT_N2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {

        private readonly MyDbContext _context;
        public userController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll() {
            var dsuser = _context.Users.ToList();
            return Ok(dsuser); 
        }


        [HttpPost]
        public IActionResult Creat(user_model user_Model)
        {
            try
            {

                var u = new user
                {
                    username = user_Model.username,
                    password = user_Model.password,
                    
                };
                u.password = BCrypt.Net.BCrypt.HashPassword(u.password);
                _context.Add(u);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex) { 
                
            }
            return BadRequest("username da ton tai");
          
        }
        [HttpGet("id")]
        public IActionResult getById(int id)
        {

            try
            {
                var user = _context.Users.SingleOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return NotFound("Khong tim thay doi tuong");
                }
                return Ok(user);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        


        [HttpPut("{id}")]
        public IActionResult Updateuser(int id, user_model userEdit)
        {
            try
            {

                var user = _context.Users.SingleOrDefault(u=>u.Id==id  );
                if (user != null)
                {
                    user.username = userEdit.username;
                    user.password=userEdit.password;
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound("Khong tim thay doi tuong can sua");
                }
            }
            catch (Exception ex) { }
            return Ok("Sua doi tuong thanh cong");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(u=>u.Id==id);
                if (user == null)
                {
                    return NotFound("Khong tim thay doi tuong");
                }
                else
                {
                    _context.Remove(user);
                    _context.SaveChanges();
                    return Ok("Xoa doi tuong thanh cong");
                }
            }
            catch (Exception ex) { }
            return BadRequest("Yeu cau bi loi");

        }
        
        [HttpGet("username")]
        public IActionResult getusername(string UserName)
        {

            try
            {
                var user = _context.Users.SingleOrDefault(u => u.username == UserName);
                if (user == null)
                {
                    return NotFound("Khong tim thay doi tuong");
                }
                return Ok(user);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("Login")]
        public IActionResult Login(string UserName, string pass)
        {
            var user = _context.Users.SingleOrDefault(u => u.username == UserName);
            if (user == null)
            {
                return NotFound("khong tim thay");
            }
            else
            {


                bool isPassword = BCrypt.Net.BCrypt.Verify(pass, user.password);
                if (isPassword)
                {
                    var dsuser = _context.Users.ToList();
                    return Ok(dsuser);

                }
                return BadRequest("sai mat khau");
            }
        }

    }
}
