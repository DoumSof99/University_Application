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

        private void addToolStripMenuItem1_Click(object sender, EventArgs e) {
            AddEntity(EntityAddTypes.Student);
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e) {
            AddEntity(EntityAddTypes.Professor);
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e) {
            AddEntity(EntityAddTypes.Schedule);
        }

        private void addToolStripMenuItem4_Click(object sender, EventArgs e) {
            AddEntity(EntityAddTypes.Category);
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e) {
            ViewEntity(EntityAddTypes.Course);
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e) {
            ViewEntity(EntityAddTypes.Student);
        }

        private void viewToolStripMenuItem2_Click(object sender, EventArgs e) {
            ViewEntity(EntityAddTypes.Professor);
        }

        private void viewToolStripMenuItem3_Click(object sender, EventArgs e) {
            ViewEntity(EntityAddTypes.Schedule);
        }

        private void viewToolStripMenuItem4_Click(object sender, EventArgs e) {
            ViewEntity(EntityAddTypes.Category);
        }

        #endregion

        #region Methods

        private void AddEntity(EntityAddTypes type) {
            switch (type) {
                case EntityAddTypes.Course:

                    AddCourse();

                    break;
                case EntityAddTypes.Student:

                    AddStudent();

                    break;
                case EntityAddTypes.Professor:

                    AddProfessor();

                    break;
                case EntityAddTypes.Schedule:

                    AddSchedule();

                    break;
                case EntityAddTypes.Category:

                    AddCategory();

                    break;
                default:
                    break;
            }
        }

        private void Serialization() {
            TheJsonController.SerializeToJson(university);
        }

        private void AddCourse() {
            Course course = new Course();
            CourseForm courseForm = new CourseForm();

            courseForm.NewCourse = course;
            courseForm.MyUniversity = university;
            
            DialogResult result = courseForm.ShowDialog();

            switch (result) {
                case DialogResult.OK:

                    university.Courses.Add(course);
                    Serialization();

                    break;
               
                default:
                    break;
            }
        }

        private void AddStudent() {
            Student student = new Student();
            StudentForm studentForm = new StudentForm();

            studentForm.NewStudent = student;
            DialogResult result = studentForm.ShowDialog();

            switch (result) {
                case DialogResult.OK:

                    university.Students.Add(student);
                    Serialization();

                    break;

                default:
                    break;
            }           
        }

        private void AddProfessor() {
            Professor professor = new Professor();
            ProfessorForm professorForm = new ProfessorForm();

            professorForm.NewProfessor = professor;
            DialogResult result = professorForm.ShowDialog();

            switch (result) {
                case DialogResult.OK:

                    university.Professors.Add(professor);
                    Serialization();

                    break;

                default:
                    break;
            }            
        }

        private void AddSchedule() {
            Schedule schedule = new Schedule();
            ScheduleForm scheduleForm = new ScheduleForm();

            scheduleForm.NewSchedule = schedule;
            scheduleForm.MyUniversity = university;
            DialogResult result = scheduleForm.ShowDialog();

            switch (result) {
                case DialogResult.OK:

                    university.Schedules.Add(schedule);
                    Serialization();

                    break;

                default:
                    break;
            }
        }

        private void AddCategory() {
            Category category = new Category();
            CategoryForm categoryForm = new CategoryForm();

            categoryForm.NewCategory = category;
            categoryForm.MyUniversity = university;
          //  DialogResult = DialogResult.Cancel;
            DialogResult result = categoryForm.ShowDialog();

            switch (result) {
                case DialogResult.OK:

                    university.Categories.Add(category);
                    Serialization();

                    break;

                default:
                    break;
            }
        }

        private void ViewEntity(EntityAddTypes type) {
            switch (type) {
                case EntityAddTypes.Course:

                    ViewCourses();

                    break;
                case EntityAddTypes.Student:

                    ViewStudents();

                    break;
                case EntityAddTypes.Professor:

                    ViewProfessors();

                    break;
                case EntityAddTypes.Schedule:

                    ViewSchedules();

                    break;
                case EntityAddTypes.Category:

                    ViewCategories();

                    break;
                default:
                    break;
            }
        }
        
        private void ViewCourses() {
            CourseViewForm courseViewForm = new CourseViewForm();
            courseViewForm.MyUniversity = university;
            courseViewForm.ShowDialog();
        }

        private void ViewStudents() {
            StudentViewForm studentViewForm = new StudentViewForm();
            studentViewForm.MyUniversity = university;
            studentViewForm.ShowDialog();
        }

        private void ViewProfessors() {
            ProfessorViewForm professorViewForm = new ProfessorViewForm();
            professorViewForm.MyUniversity = university;
            professorViewForm.ShowDialog();
        }

        private void ViewSchedules() {
            ScheduleViewForm scheduleViewForm = new ScheduleViewForm();
            scheduleViewForm.MyUniversity = university;
            scheduleViewForm.ShowDialog();
        }

        private void ViewCategories() {
            CategoryViewForm categoryViewForm = new CategoryViewForm();
            categoryViewForm.MyUniversity = university;
            categoryViewForm.ShowDialog();
        }


        #endregion
    }
}
