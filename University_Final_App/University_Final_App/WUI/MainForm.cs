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

            courseForm.ShowDialog();

            university.Courses.Add(course);
            Serialization();
        }

        private void AddStudent() {
            Student student = new Student();
            StudentForm studentForm = new StudentForm();

            studentForm.NewStudent = student;
            studentForm.ShowDialog();

            university.Students.Add(student);
            Serialization();
        }

        private void AddProfessor() {
            Professor professor = new Professor();
            ProfessorForm professorForm = new ProfessorForm();

            professorForm.NewProfessor = professor;
            professorForm.ShowDialog();

            university.Professors.Add(professor);
            Serialization();
        }

        private void AddSchedule() {
            Schedule schedule = new Schedule();
            ScheduleForm scheduleForm = new ScheduleForm();

            scheduleForm.NewSchedule = schedule;
            scheduleForm.MyUniversity = university;
            scheduleForm.ShowDialog();

            university.Schedules.Add(schedule);
            Serialization();
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


        #endregion
    }
}
