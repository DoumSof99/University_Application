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
    public partial class CategoryForm : Form {

        public University MyUniversity { get; set; }

        public Category NewCategory { get; set; }

        public CategoryForm() {
            InitializeComponent();
        }

        #region Events

        private void btnAdd_Click(object sender, EventArgs e) {
            AddCategory();
        }

        #endregion

        #region Methods

        private void AddCategory() {

            string tempCategoryName = Convert.ToString(ctrlCategoryName.Text);

            if (string.IsNullOrEmpty(tempCategoryName)) {
                MessageBox.Show("Please enter a category!");
                return;
            }

            NewCategory.CategoryCourse = tempCategoryName;

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}
