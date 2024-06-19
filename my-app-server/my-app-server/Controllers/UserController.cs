using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace my_app_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> userList = new List<User>
        {
            new User
            {
                Code=1,
                Name="Israel Israeli",
                Address="Ben Eliezer",
                mail="Israel@gmail.com",
                Password="1234"
            },
            new User
            {
                Code=2,
                Name="Roni Shachar",
                Address="Ben Gurion",
                mail="Roni@gmail.com",
                Password="5678"
            },
            new User
            {
                Code=3,
                Name="Yael Choen",
                Address="Hapisga",
                mail="Yael@gmail.com",
                Password="5798"
            }
        };

        public static List<User> lecturerList = new List<User>
        {
            new User
            {
                Code=101,
                Name="Lecturer 1",
                Address="Lecture Hall 1",
                mail="lecturer1@gmail.com",
                Password="lecturer123"
            },
            new User
            {
                Code=102,
                Name="Lecturer 2",
                Address="Lecture Hall 2",
                mail="lecturer2@gmail.com",
                Password="lecturer456"
            }
        };

        // GET: api/user
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userList;
        }

        // GET api/user/lecturers
        [HttpGet("lecturers")]
        public IEnumerable<User> GetLecturers()
        {
            return lecturerList;
        }

        // POST api/user/lecturers
        [HttpPost("lecturers")]
        public void PostLecturer([FromBody] User lecturer)
        {
            lecturerList.Add(lecturer);
        }

        // GET api/<user>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<user>
        [HttpPost]
        public void Post([FromBody] List<User> user)
        {
            userList = user;
        }

        // PUT api/<user>/5
        [HttpPut("{id}")]
        public void Put(int code, [FromBody] User user)
        {
            int index = userList.FindIndex(u=> u.Code == code);
            userList[index] = user;
        }
        // DELETE api/<user>/5
        [HttpDelete("{id}")]
        public void Delete(int code)
        {
            int index = userList.FindIndex(u => u.Code== code);
            if (index < 0)
                return;
            userList.Remove(userList[index]);
        }
    }
}
