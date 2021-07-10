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
    public partial class StudentForm : Form {

        public Student NewStudent { get; set; }

        public StudentForm() {
            InitializeComponent();
        }

        #region Events

        private void btnAdd_Click(object sender, EventArgs e) {
            AddStudent();
        }

        #endregion

        #region Methods

        private void AddStudent() {

            string tempName = Convert.ToString(ctrlName.Text);
            string tempLastName = Convert.ToString(ctrlLastName.Text);
            int tempAge = Convert.ToInt32(ctrlAge.Value);
            string tempRegistrationNumber = Convert.ToString(ctrlRegistrationNumber.Text);

            if (string.IsNullOrEmpty(tempName)) {
                MessageBox.Show("Please enter the Name");
                return;
            }

            if (string.IsNullOrEmpty(tempLastName)) {
                MessageBox.Show("Please enter the Last Name");
                return;
            }

            if (string.IsNullOrEmpty(tempRegistrationNumber)) {
                MessageBox.Show("Please enter a Registration Number");
                return;
            }

            NewStudent.Name = tempName;
            NewStudent.LastName = tempLastName;
            NewStudent.Age = tempAge;
            NewStudent.RegistrationNumber = tempRegistrationNumber;

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}
