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
    public partial class CourseForm : Form {

        public University MyUniversity { get; set; }

        public Course NewCourse { get; set; }

        public CourseForm() {
            InitializeComponent();
        }

        #region Events

        private void CourseForm_Load(object sender, EventArgs e) {
            AddToComboBox();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            AddCourse();
        }

        #endregion

        #region Methods
        
        private void AddToComboBox() {
            foreach (var item in MyUniversity.Categories) {
                ctrlCourseCategory.Items.Add(item.CategoryCourse);
            }
        }

        private void AddCourse() {

            string tempCode = Convert.ToString(ctrlCode.Text);
            string tempSubject = Convert.ToString(ctrlSubject.Text);
            if (string.IsNullOrEmpty(ctrlCourseCategory.Text)) {
                MessageBox.Show("Please select a category!");
                return;
            }
            string tempCourseCategory = Convert.ToString(ctrlCourseCategory.SelectedItem.ToString());
            int tempHour = Convert.ToInt32(ctrlHours.Value);

            if (string.IsNullOrEmpty(tempCode)) {
                MessageBox.Show("Please enter a code");
                return;
            }

            if (string.IsNullOrEmpty(tempSubject)) {
                MessageBox.Show("Please enter a subject");
                return;
            }

            NewCourse.Code = tempCode;
            NewCourse.Subject = tempSubject;
            NewCourse.CourseCategory = tempCourseCategory;
            NewCourse.Hours = tempHour;

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}
