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
using University_Final_App.WUI;

namespace University_Final_App {
    public partial class MainForm : Form {

        private University university = null;
        public JsonController TheJsonController { get; set; }
        
        public MainForm() {
            InitializeComponent();
            TheJsonController = new JsonController();
        }

        #region Events

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        private void MainForm_Load(object sender, EventArgs e) {
            university = TheJsonController.DeserializeFromJson();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e) {
            AddEntity(EntityAddTypes.Course);
        }

        #endregion

        #region Methods

        private void AddEntity(EntityAddTypes type) {
            switch (type) {
                case EntityAddTypes.Course:

                    AddCourse();

                    break;
                case EntityAddTypes.Student:
                    break;
                case EntityAddTypes.Professor:
                    break;
                case EntityAddTypes.Schedule:
                    break;
                default:
                    break;
            }
        }

        private void AddCourse() {
            Course course = new Course();
            CourseForm courseForm = new CourseForm();

            courseForm.NewCourse = course;

            courseForm.ShowDialog();

            university.Courses.Add(course);
            Serialization();
        }

        private void Serialization() {

            TheJsonController.SerializeToJson(university);
        }

        #endregion

       
    }
}
