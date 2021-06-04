using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITToolTest.Models
{
    public class OurCourses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LessonsCount { get; set; }
        public int Level { get; set; }
    }
}
