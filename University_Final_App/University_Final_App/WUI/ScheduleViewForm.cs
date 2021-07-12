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

        #region Events

        private void ScheduleViewForm_Load(object sender, EventArgs e) {
            FillGridHeaders();
        }

        #endregion

        #region Methods

        DataTable table = new DataTable() {
            Columns = { { "Callendar" }, { "Course Category" }, { "Student ID" }, { "Professor ID" }, { "ID" } }
        };

        private void FillGridHeaders() {

            foreach (var item in MyUniversity.Schedules) {
                gridSchedule.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                table.Rows.Add(item.Callendar, item.CourseCategory, item.StudentID, item.ProfessorID, item.ID);
                gridSchedule.DataSource = table;
            }
        }

        #endregion
    }
}
