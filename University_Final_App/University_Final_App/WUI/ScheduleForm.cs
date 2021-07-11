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
    public partial class ScheduleForm : Form {

        public University MyUniversity { get; set; }

        public Schedule NewSchedule { get; set; }

        public JsonController TheJsonController { get; set; }

        public ScheduleForm() {
            InitializeComponent();
            TheJsonController = new JsonController();
        }

        #region Events

        private void ScheduleForm_Load(object sender, EventArgs e) {
            FillListViewHeader();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            AddSchedule();
        }

        #endregion

        #region Methods

        private void FillListViewHeader() {

            ctrlStudentViewList.Items.Clear();

            ctrlStudentViewList.View = View.Details;
            ctrlStudentViewList.Columns.Add("Name", 200);
            ctrlStudentViewList.Columns.Add("LastName", 200);
            ctrlStudentViewList.Columns.Add("Age", 200);
            ctrlStudentViewList.Columns.Add("RegistrationNumber", 200);
            ctrlStudentViewList.Columns.Add("ID", 200);

            ctrlProfessorViewList.Items.Clear();

            ctrlProfessorViewList.View = View.Details;
            ctrlProfessorViewList.Columns.Add("Name", 200);
            ctrlProfessorViewList.Columns.Add("LastName", 200);
            ctrlProfessorViewList.Columns.Add("Age", 200);
            ctrlProfessorViewList.Columns.Add("RegistrationNumber", 200);
            ctrlProfessorViewList.Columns.Add("ID", 200);

            ctrlCourseViewList.Items.Clear();

            ctrlCourseViewList.View = View.Details;
            ctrlCourseViewList.Columns.Add("Code", 200);
            ctrlCourseViewList.Columns.Add("Subject", 200);
            ctrlCourseViewList.Columns.Add("Course Category", 200);
            ctrlCourseViewList.Columns.Add("Hours", 200);
            ctrlCourseViewList.Columns.Add("ID", 200);

            LoadData();
        }

        private void LoadData() {

            foreach (var item in MyUniversity.Students) {
                string listStudents = String.Format("{0},{1},{2},{3},{4}", item.Name, item.LastName, item.Age, item.RegistrationNumber, item.ID);
                string[] listParse = listStudents.Split(',').ToArray();

                ListViewItem listViewItem = new ListViewItem(listParse);
                ctrlStudentViewList.Items.Add(listViewItem);
            }

            foreach (var item in MyUniversity.Professors) {
                string listProfessors = String.Format("{0},{1},{2},{3},{4}", item.Name, item.LastName, item.Age, item.Rank, item.ID);
                string[] listParse = listProfessors.Split(',').ToArray();

                ListViewItem listViewItem = new ListViewItem(listParse);
                ctrlProfessorViewList.Items.Add(listViewItem);
            }

            foreach (var item in MyUniversity.Courses) {
                string listStudents = String.Format("{0},{1},{2},{3},{4}", item.Code, item.Subject, item.CourseCategory, item.Hours, item.ID);
                string[] listParse = listStudents.Split(',').ToArray();

                ListViewItem listViewItem = new ListViewItem(listParse);
                ctrlCourseViewList.Items.Add(listViewItem);
            }

        }

        private void AddSchedule() {

            if (ctrlStudentViewList.SelectedItems.Count > 0 && ctrlProfessorViewList.SelectedItems.Count > 0 && ctrlCourseViewList.SelectedItems.Count > 0) {
                
            }
            else {
                MessageBox.Show("Please select a record from every field");
            }
        }

        #endregion
    }
}
