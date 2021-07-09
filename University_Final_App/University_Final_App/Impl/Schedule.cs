using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Final_App.Impl {
    public class Schedule : CourseBase {

        public int StudentID { get; set; }
        public int ProfessorId { get; set; }

        public Schedule() : base() {
                
        }

    }
}
