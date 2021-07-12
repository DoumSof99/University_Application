using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Final_App.Impl {
    public class Schedule : Base {

        public Guid StudentID { get; set; }
        public Guid ProfessorID { get; set; }
        public DateTime Callendar { get; set; }
        public string CourseCategory { get; set; }

        public Schedule() : base() {
                
        }

    }
}
