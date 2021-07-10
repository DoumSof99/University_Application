using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Final_App.Impl {
    public class Person : Base {

        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person() : base() {

        }

    }
}
