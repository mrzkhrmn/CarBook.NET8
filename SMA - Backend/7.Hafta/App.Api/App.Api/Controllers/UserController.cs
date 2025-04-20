using App.Api.Data;
using App.Api.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private static readonly List<UserModel> Users = new();

        private AppDbContext Context { get; }

        public UserController(AppDbContext dbContext)
        {
            //    Context = new AppDbContext();
            //    Context.Database.EnsureCreated();

            Context = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = Context.Users.ToList(); // Veritabanındaki SELECT işlemi

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id) 
        {
            //var user = Users.Find(u => u.Id == id);

            //if(user == null)
            //{
            //    return NotFound();
            //}

            //return Ok(user);

            //var user = Context.Users.FirstOrDefault(x => x.Id == id);

            //if(user == null)
            //{
            //    return NotFound();
            //}

            //return Ok(user);

            var user = Context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserEntity user)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}

            //user.Id = Users.Count + 1;

            //Users.Add(user);

            //return Ok(user);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            user.Id = 0;

            Context.Users.Add(user);

            Context.SaveChanges();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserEntity user)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}

            //var userIndex = Users.FindIndex(u => u.Id == id);

            //if(userIndex < 0)
            //{
            //    return NotFound();
            //}

            //user.Id = id;

            //Users[userIndex] = user;

            //return Ok(user);
            // ---------------------------------

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}

            //var dbUser= Context.Users.FirstOrDefault(u => u.Id == id);

            //if(dbUser is null)
            //{
            //    return NotFound();
            //}

            //dbUser.Name = user.Name;
            //dbUser.Email = user.Email;
            //dbUser.Password = user.Password;

            //Context.SaveChanges();

            //return Ok(dbUser);

            //-----------------------------------------
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var dbUser = Context.Users.Find(id);

            if (dbUser is null)
            {
                return NotFound();
            }

            dbUser.Name = user.Name;
            dbUser.Email = user.Email;
            dbUser.Password = user.Password;

            Context.SaveChanges();

            return Ok(dbUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) 
        {
            //var userIndex = Users.FindIndex(u => u.Id == id);

            //if (userIndex < 0)
            //{
            //    return NotFound();
            //}

            //Users.RemoveAt(userIndex);

            //return Ok();

            //var dbUser = Context.Users.FirstOrDefault(u => u.Id == id);

            //if (dbUser is null)
            //{
            //    return NotFound();
            //}

            //Context.Users.Remove(dbUser);

            //Context.SaveChanges();

            //return Ok();

            var dbUser = Context.Users.Find(id);

            if (dbUser is null)
            {
                return NotFound();
            }

            Context.Users.Remove(dbUser);

            Context.SaveChanges();

            return Ok();
        }
    }
}
