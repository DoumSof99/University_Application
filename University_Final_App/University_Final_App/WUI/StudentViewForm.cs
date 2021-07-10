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
    public partial class StudentViewForm : Form {

        public University MyUniversity { get; set; }
        public JsonController TheJsonController { get; set; }

        public StudentViewForm() {
            InitializeComponent();
            TheJsonController = new JsonController();
        }

        #region Events

        private void StudentViewForm_Load(object sender, EventArgs e) {

        }



        #endregion

        #region Methods



        #endregion
    }
}
