using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITToolTest.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Courses()
        {
            this.CoursesData1 = new HashSet<CoursesData>();
            this.UsersCourses = new HashSet<UserCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LessonsCount { get; set; }
        public string Level { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoursesData> CoursesData1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCourse> UsersCourses { get; set; }
    }
}
