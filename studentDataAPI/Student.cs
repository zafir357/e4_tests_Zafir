using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentDataAPI
{
    public class Student
    {
        public int Id { get; set; }
        public  string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Course { get; set; }
        public string Email { get; set; }

        public Student(int id,string firstname, string lastname, string course, string email)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Course = course;
            this.Email = email;
        }

        public Student()
        {
        }
    }
}
