using Library_System.Data;
using Library_System.Models.DomainModels;
using Library_System.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly LmDbContext dbContext;

        public UsersController(LmDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllUsers() {
            var users = dbContext.Users.ToList();
             // Map Domain Models to DTOs
            var userDto = new List<UserDto>();
            foreach (var user in users)
            {
                userDto.Add(new UserDto()
                {
                    Id = user.Id,
                    Username = user.Username,
                    IsAdmin =  user.IsAdmin,

                });
            }
            //Return DTOs
            return Ok(userDto);
        }

        [HttpGet]
        [Route("/Profile")]
        public IActionResult GetAllUsersProfile()
        {
            var profiles = dbContext.Profile.ToList();
            // Map Domain Models to DTOs
            var profileDto = new List<UserDto>();
            foreach (var profile in profiles)
            {
                profileDto.Add(new UserDto()
                {
                    Id = profile.Id,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Address = profile.Address,
                    Phone = profile.Phone,
                    NumberofBooksAllocated = profile.NumberofBooksAllocated,
                    Email = profile.Email,
                    RegistrationDate = profile.RegistrationDate,
                    Verified = profile.Verified,
                    RFID = profile.RFID,
                });
            }
            //Return DTOs
            return Ok(profiles);
        }

        [HttpGet] //http url /api/books/{id}
        [Route("{id}")] //adding route 
        public IActionResult GetUserById([FromRoute] string id)
        {
            var user = dbContext.Users.Find(id); //only be used for id
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] AddUserDto user)
        {
            var userModel = new Users
            {
                Name = user.FirstName+ user.LastName,
                Username = user.Username,
                Password = user.Password,
                IsAdmin = false,
                Status = false
            };
            dbContext.Users.Add(userModel);
            dbContext.SaveChanges();
            var profileModel = new Profiles
            {
                User = userModel,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                NumberofBooksAllocated = 0,
                Email = user.Email,
                Phone = user.Phone,
                RegistrationDate = DateTime.Now,
                RFID = user.RFID,
                Role = user.Role,
                Verified = false,
            };

            //Use Domain Model to add the book to Database
            
            dbContext.Profile.Add(profileModel);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetUserById), new { id = userModel.Id }, user);
        }

        [HttpPost]
        [Route ("/Login")]
        public IActionResult VerifyLogin([FromBody] LoginDto User)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Username == User.Username);
            if(user == null)
            {
                return Ok("Username not Found");
            }

            if(user.Status == false)
            {
                return Ok("Username is not active");
            }

            if(user.Password == User.Password)
            {
                return Ok("Login ok");
            }
            return Ok("Can not login, password incorrect");
        }

        [HttpGet]
        [Route("/VerifyUser")]
        public IActionResult VerifyUser([FromRoute] string id)
        {
            var user = dbContext.Users.Find(id); 
            if (user == null)
            {
                return Ok("User not Found");
            }

            if (user.IsAdmin == false)
            {
                user.Status = true;
                return Ok("User is now verified");
            }


            return Ok("done");
        }

    }
}
