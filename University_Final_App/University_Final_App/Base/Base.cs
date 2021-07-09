using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Final_App.Impl {
    public class Base {

        public Guid ID { get; set; }
        public Base() {
            ID = Guid.NewGuid();
        }
    }
}
