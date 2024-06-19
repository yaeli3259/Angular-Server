using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace my_app_server.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public static List<Course> courseList = new List<Course>
        {
          new Course
          {
               Code=1,
               Name="Angular",
               Category=new Category{Code = 1,IconRoute= "Angular.png" ,Name ="web"},
               LessonCount=43,
               StartDate = new DateTime(2024, 1, 1, 0, 0, 0),
               Syllabus = new List<string>
               {
                "input",
                "output",
                "bootstrap",
                "Router"
               },
               LearningMode=0,
               InstructorCode="7894",
               Image="Angular.jpg"
          },
          new Course
          {
               Code=2,
               Name="React",
              Category=new Category{Code = 2,IconRoute= "React.png" ,Name ="web"},
               LessonCount=43,
               StartDate=new DateTime(2024, 1, 1, 0, 0, 0),
               Syllabus = new List<string>
               {
                "observable",
                "material MUI",
                "hooks",
                "MOBX"
               },
               LearningMode=0,
               InstructorCode="7894",
               Image="React.jpg"
          },
           new Course
          {
               Code=3,
               Name="innovation",
               Category=new Category{Code = 3,IconRoute= "Innovation.png" ,Name ="web"},
               LessonCount=43,
               StartDate=new DateTime(2024, 3, 11, 0, 0, 0),
               Syllabus = new List<string>
               {
                "Docker",
                "Git",
                "AWS",
                "Google Cloud"
               },
               LearningMode=0,
               InstructorCode="4586",
               Image="Innovation.jpg"
          }
};
        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return courseList;
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           Course temp =courseList.Find(x=>x.Code == id);
            if (temp == null)
                return NotFound("course not found");
            return Ok(temp);
        }

        // POST api/<CourseController>
        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("Invalid course data");
            }

            try
            {
                courseList.Add(course);
                return Ok("Course added successfully");
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "An error occurred while adding the course");
            }
        }

        // PUT api/<CourseController>/5
        [HttpPut]
        public void Put(int code, [FromBody] Course course)
        {
            Course existingCourse = courseList.FirstOrDefault(c => c.Code == code);
            if (existingCourse != null)
            {
                existingCourse.Name = course.Name;
                existingCourse.Category = course.Category;
                existingCourse.LessonCount = course.LessonCount;
                existingCourse.StartDate = course.StartDate;
                existingCourse.Syllabus = course.Syllabus;
                existingCourse.LearningMode = course.LearningMode;
                existingCourse.InstructorCode = course.InstructorCode;
                existingCourse.Image = course.Image;
            }
            else
            {
                courseList.Add(course);
            }
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int code)
        {
            int index = courseList.FindIndex(c => c.Code == code);
            if (index < 0)
                return;
            courseList.Remove(courseList[index]);
        }
    }
}
