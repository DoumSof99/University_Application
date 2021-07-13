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
            FillGrid();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            DeleteSelectedRecord();
        }

        #endregion

        #region Methods

        DataTable table = new DataTable() {
            Columns = { { "Callendar" }, { "Course Category" }, { "Student Name" }, { "Professor Name" }, { "ID" } }
        };

        private void FillGrid() {

            foreach (var item in MyUniversity.Schedules) {
                gridSchedule.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                table.Rows.Add(item.Callendar, item.CourseCategory, item.StudentName, item.ProfessorName, item.ID);
                gridSchedule.DataSource = table;
                gridSchedule.Columns["ID"].Visible = false;
            }
        }

        private Guid GetIdList() {

            if (gridSchedule.SelectedRows.Count == 0) {
                return Guid.Empty;
            }

            if (gridSchedule.SelectedRows[0].Cells[4].Value.ToString() == "") {
                return Guid.Empty;
            }

            return Guid.Parse(gridSchedule.SelectedRows[0].Cells[4].Value.ToString());
        }

        private void DeleteSelectedRecord() {
            Guid id = GetIdList();

            if (id == Guid.Empty) {
                MessageBox.Show("Please Select a Record");
            }
            else {
                MyUniversity.Schedules.RemoveAll(x => x.ID == id);
                MessageBox.Show("Succesfully deleted!");
                Close();
            }

        }

        #endregion
    }
}
