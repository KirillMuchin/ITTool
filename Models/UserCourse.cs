using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITToolTest.Models
{
    public class UserCourse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Progress { get; set; }
        public int CoursesId { get; set; }

        public virtual Courses Courses { get; set; }
        public virtual User User { get; set; }
    }
}
