using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Final_App.Impl {
    public class University : Base {

        public List<Category> Categories { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
        public List<Professor> Professors { get; set; }
        public List<Schedule> Schedules { get; set; }

        public University() : base() {
                
        }
    }
}
