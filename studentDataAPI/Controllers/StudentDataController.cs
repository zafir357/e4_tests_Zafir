using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDataController : ControllerBase
    {


        List<Student> Students = new List<Student>()
            {
                    new Student(1,"Mohammad Zafir", "Jeeawody", "Software Engineering", "zafirjeeawody@gmail.com"),
                    new Student(2,"Georgio", "Chellini", "Mastering Central Defence", "georgiochellini@gmail.com"),
                    new Student(3,"Cristiano", "Ronaldo", "Mastering Striker Position", "cr7@gmail.com")

            };

        // GET: api/StudentData
        [HttpGet]

        public ActionResult GetStudent()
        {
            if (Students.Count==0)
                return NotFound();
            return Ok(Students);
        }

        // GET: api/StudentData/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            Student stud = Students.Find(f => f.Id == id);
            if (Students.Count == 0)
                return NotFound();
            return Ok(stud);


            
        }

        // POST: api/StudentData
        [HttpPost]
        public List<Student> Post([FromBody] Student stud)
        {
           
            Students.Add(stud);

            return Students;
        }

        // PUT: api/StudentData/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Student stud)
        {
            Student StudToUpdate = Students.Find(f => f.Id == id);
            int index = Students.IndexOf(StudToUpdate);

            Students[index].Id = stud.Id;
            Students[index].Firstname = stud.Firstname;
            Students[index].Lastname = stud.Lastname;
            Students[index].Course = stud.Course;
            Students[index].Email = stud.Email;
            if (Students.Count == 0)
                return NotFound();
            return Ok(Students);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool FailDeleted = false;
            if (FailDeleted)
                return BadRequest();

            Student stud = Students.Find(f => f.Id == id);
            Students.Remove(stud);
            return Ok(Students);
        }

    }
}
