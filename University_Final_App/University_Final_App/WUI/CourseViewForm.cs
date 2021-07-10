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
    public partial class CourseViewForm : Form {

        public University MyUniversity { get; set; }
        public JsonController TheJsonController { get; set; }

        public CourseViewForm() {
            InitializeComponent();
            TheJsonController = new JsonController();
        }

        #region Events

        private void CourseViewForm_Load(object sender, EventArgs e) {
            FillFormHeaders();
            LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            EditSelectedRecord();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            DeleteSelectedRecord();
        }

        #endregion

        #region Methods

        private void FillFormHeaders() {
            ctrlCourseViewList.Items.Clear();

            ctrlCourseViewList.View = View.Details;
            ctrlCourseViewList.Columns.Add("Code", 200);
            ctrlCourseViewList.Columns.Add("Subject", 200);
            ctrlCourseViewList.Columns.Add("Course Category", 200);
            ctrlCourseViewList.Columns.Add("Hours", 200);
            ctrlCourseViewList.Columns.Add("ID", 200);
        }

        private void LoadData() {
            foreach (var item in MyUniversity.Courses) {
                string listCourses = String.Format("{0},{1},{2},{3},{4}", item.Code, item.Subject, item.CourseCategory, item.Hours, item.ID);
                string[] listParse = listCourses.Split(',').ToArray();

                ListViewItem listViewItem = new ListViewItem(listParse);
                ctrlCourseViewList.Items.Add(listViewItem);
            }
        }

        private void RefreshItems() {
            ctrlCourseViewList.Items.Clear();
            LoadData();
            TheJsonController.SerializeToJson(MyUniversity);
        }

        private Guid GetIdList() {
            if (ctrlCourseViewList.SelectedItems.Count == 0) {
                return Guid.Empty;
            }

            int index = ctrlCourseViewList.SelectedIndices[0];
            return MyUniversity.Courses[index].ID;

        }

        private void EditSelectedRecord() {
            Guid id = GetIdList();

            if (id == Guid.Empty) {
                MessageBox.Show("Please select a record!");
            }
            else {
                Course course = MyUniversity.Courses.Find(x => x.ID == id);
                CourseForm courseForm = new CourseForm();
                courseForm.NewCourse = course;
                courseForm.ShowDialog();
                RefreshItems();
            }
        }

        private void DeleteSelectedRecord() {
            Guid id = GetIdList();
            if (id == Guid.Empty) {
                MessageBox.Show("Please select a record!");
            }
            else {
                MyUniversity.Courses.RemoveAll(x => x.ID == id);
                RefreshItems();
            }
        }


        #endregion


    }
}
