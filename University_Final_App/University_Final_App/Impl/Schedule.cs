using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Final_App.Impl {
    public class Schedule : Base {

        public Guid StudentID { get; set; }
        public string StudentName { get; set; }
        public Guid ProfessorID { get; set; }
        public string ProfessorName { get; set; }
        public DateTime Callendar { get; set; }
        public Guid CourseID { get; set; }
        public string CourseCategory { get; set; }

        public Schedule() : base() {
                
        }

    }
}
