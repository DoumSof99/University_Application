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
            FillFormHeaders();
            LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            EditSelectedRecord();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            DeleteSelectedRecord();
        }

        private void ctrlStudentViewList_MouseDoubleClick(object sender, MouseEventArgs e) {
            EditSelectedRecord();
        }

        #endregion

        #region Methods

        private void FillFormHeaders() {
            ctrlStudentViewList.Items.Clear();

            ctrlStudentViewList.View = View.Details;
            ctrlStudentViewList.Columns.Add("Name", 200);
            ctrlStudentViewList.Columns.Add("Last Name", 200);
            ctrlStudentViewList.Columns.Add("Age", 200);
            ctrlStudentViewList.Columns.Add("Registration Number", 200);
            ctrlStudentViewList.Columns.Add("ID", 200);
        }

        private void LoadData() {
            foreach (var item in MyUniversity.Students) {
                string listStudents = String.Format("{0},{1},{2},{3},{4}", item.Name, item.LastName, item.Age, item.RegistrationNumber, item.ID);
                string[] listParse = listStudents.Split(',').ToArray();

                ListViewItem listViewItem = new ListViewItem(listParse);
                ctrlStudentViewList.Items.Add(listViewItem);
            }
        }

        private void RefreshItems() {
            ctrlStudentViewList.Items.Clear();
            LoadData();
            TheJsonController.SerializeToJson(MyUniversity);
        }

        private Guid GetIdList() {
            if (ctrlStudentViewList.SelectedItems.Count == 0) {
                return Guid.Empty;
            }

            int index = ctrlStudentViewList.SelectedIndices[0];
            return MyUniversity.Students[index].ID;
        }

        private void EditSelectedRecord() {
            Guid id = GetIdList();

            if (id == Guid.Empty) {
                MessageBox.Show("Please select a record!");
            }
            else {
                Student student = MyUniversity.Students.Find(x => x.ID == id);
                StudentForm studentForm = new StudentForm();
                studentForm.NewStudent = student;
                studentForm.ShowDialog();
                RefreshItems();
            }
        }

        private void DeleteSelectedRecord() {
            Guid id = GetIdList();
            if (id == Guid.Empty) {
                MessageBox.Show("Please select a record!");
            }
            else {
                MyUniversity.Students.RemoveAll(x => x.ID == id);
                RefreshItems();
            }
        }

        #endregion
    }
}
