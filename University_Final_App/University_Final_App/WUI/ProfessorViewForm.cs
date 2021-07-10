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
    public partial class ProfessorViewForm : Form {

        public University MyUniversity { get; set; }
        public JsonController TheJsonController { get; set; }

        public ProfessorViewForm() {
            InitializeComponent();
            TheJsonController = new JsonController();
        }

        #region Events

        private void ProfessorViewForm_Load(object sender, EventArgs e) {
            FillFormHeaders();
            LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            EditSelectedRecord();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            DeleteSelectedRecord();
        }

        private void ctrlProfessorViewList_MouseDoubleClick(object sender, MouseEventArgs e) {
            EditSelectedRecord();
        }

        #endregion

        #region Methods

        private void FillFormHeaders() {
            ctrlProfessorViewList.Items.Clear();

            ctrlProfessorViewList.View = View.Details;
            ctrlProfessorViewList.Columns.Add("Name", 200);
            ctrlProfessorViewList.Columns.Add("Last Name", 200);
            ctrlProfessorViewList.Columns.Add("Age", 200);
            ctrlProfessorViewList.Columns.Add("Rank", 200);
            ctrlProfessorViewList.Columns.Add("ID", 200);
        }

        private void LoadData() {
            foreach (var item in MyUniversity.Professors) {
                string listPrfessors = String.Format("{0},{1},{2},{3},{4}", item.Name, item.LastName, item.Age, item.Rank, item.ID);
                string[] listParse = listPrfessors.Split(',').ToArray();

                ListViewItem listViewItem = new ListViewItem(listParse);
                ctrlProfessorViewList.Items.Add(listViewItem);
            }
        }

        private void RefreshItems() {
            ctrlProfessorViewList.Items.Clear();
            LoadData();
            TheJsonController.SerializeToJson(MyUniversity);
        }

        private Guid GetIdList() {
            if (ctrlProfessorViewList.SelectedItems.Count == 0) {
                return Guid.Empty;
            }

            int index = ctrlProfessorViewList.SelectedIndices[0];
            return MyUniversity.Professors[index].ID;
        }

        private void EditSelectedRecord() {
            Guid id = GetIdList();

            if (id == Guid.Empty) {
                MessageBox.Show("Please select a record!");
            }
            else {
                Professor professor = MyUniversity.Professors.Find(x => x.ID == id);
                ProfessorForm professorForm = new ProfessorForm();
                professorForm.NewProfessor = professor;
                professorForm.ShowDialog();
                RefreshItems();
            }
        }

        private void DeleteSelectedRecord() {
            Guid id = GetIdList();
            if (id == Guid.Empty) {
                MessageBox.Show("Please select a record!");
            }
            else {
                MyUniversity.Professors.RemoveAll(x => x.ID == id);
                RefreshItems();
            }
        }
        #endregion
    }
}
