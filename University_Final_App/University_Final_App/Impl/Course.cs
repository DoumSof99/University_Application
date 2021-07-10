using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Final_App.Impl {
    public class Course : Base {

        public string Code { get; set; }
        public string Subject { get; set; }
        public string CourseCategory { get; set; }
        public int Hours { get; set; }

        public Course() : base() {

        }

    }
}
