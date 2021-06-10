using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITToolTest.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CoursesData
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public int CoursesId { get; set; }
        
        public virtual Courses Courses1 { get; set; }
    }
}

