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
    public partial class ProfessorForm : Form {

        public Professor NewProfessor { get; set; }

        public ProfessorForm() {
            InitializeComponent();
        }

        #region Events

        private void btnAdd_Click(object sender, EventArgs e) {
            AddProfessor();
        }

        #endregion

        #region Methods

        private void AddProfessor() {

            string tempName = Convert.ToString(ctrlName.Text);
            string tempLastName = Convert.ToString(ctrlLastName.Text);
            int tempAge = Convert.ToInt32(ctrlAge.Value);
            string tempRank = Convert.ToString(ctrlRank.Text);

            if (string.IsNullOrEmpty(tempName)) {
                MessageBox.Show("Please enter the Name");
                return;
            }

            if (string.IsNullOrEmpty(tempLastName)) {
                MessageBox.Show("Please enter the Last Name");
                return;
            }

            if (string.IsNullOrEmpty(tempRank)) {
                MessageBox.Show("Please enter a Rank");
                return;
            }

            NewProfessor.Name = tempName;
            NewProfessor.LastName = tempLastName;
            NewProfessor.Age = tempAge;
            NewProfessor.Rank = tempRank;

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}
