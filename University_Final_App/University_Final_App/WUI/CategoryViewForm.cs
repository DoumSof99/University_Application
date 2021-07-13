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
    public partial class CategoryViewForm : Form {

        public University MyUniversity { get; set; }

        public JsonController TheJsonController { get; set; }

        public CategoryViewForm() {
            InitializeComponent();
            TheJsonController = new JsonController();
        }

        #region Events

        private void CategoryViewForm_Load(object sender, EventArgs e) {
            FillHeader();
            LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            EditSelectedRecord();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            DeleteSelectedRecord();
        }

        private void ctrlCategoryViewList_MouseDoubleClick(object sender, MouseEventArgs e) {
            EditSelectedRecord();
        }

        #endregion

        #region Methods

        private void FillHeader() {
            ctrlCategoryViewList.Items.Clear();

            ctrlCategoryViewList.View = View.Details;
            ctrlCategoryViewList.Columns.Add("Category Course", 900);
            ctrlCategoryViewList.Columns.Add("ID", 200);
        }

        private void LoadData() {
            foreach (var item in MyUniversity.Categories) {
                string listCategory = String.Format("{0},{1}", item.CategoryCourse, item.ID);
                string[] listParse = listCategory.Split(',').ToArray();

                ListViewItem listViewItem = new ListViewItem(listParse);
                ctrlCategoryViewList.Items.Add(listViewItem);
            }
        }

        private void RefreshItems() {
            ctrlCategoryViewList.Items.Clear();
            LoadData();
            TheJsonController.SerializeToJson(MyUniversity);
        }

        private Guid GetIdList() {
            if (ctrlCategoryViewList.SelectedItems.Count == 0) {
                return Guid.Empty;
            }

            int index = ctrlCategoryViewList.SelectedIndices[0];
            return MyUniversity.Categories[index].ID;
        }

        private void EditSelectedRecord() {
            Guid id = GetIdList();

            if (id == Guid.Empty) {
                MessageBox.Show("Please select a record!");
            }
            else {
                Category category = MyUniversity.Categories.Find(x => x.ID == id);
                CategoryForm categoryForm = new CategoryForm();
                categoryForm.NewCategory = category;
                categoryForm.ShowDialog();
                RefreshItems();
            }
        }

        private void DeleteSelectedRecord() {
            Guid id = GetIdList();
            if (id == Guid.Empty) {
                MessageBox.Show("Please select a record!");
            }
            else {
                MyUniversity.Categories.RemoveAll(x => x.ID == id);
                RefreshItems();
            }
        }

        #endregion
    }
}
