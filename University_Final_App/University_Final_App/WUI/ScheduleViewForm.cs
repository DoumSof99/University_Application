using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using University_Final_App.Impl;

namespace University_Final_App.WUI {
    public partial class ScheduleViewForm : Form {

        public University MyUniversity { get; set; }

        public JsonController TheJsonController { get; set; }

        public ScheduleViewForm() {
            InitializeComponent();
            TheJsonController = new JsonController();
        }
    }
}
