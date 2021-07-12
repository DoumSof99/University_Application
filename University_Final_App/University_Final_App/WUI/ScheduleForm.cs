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
    public partial class ScheduleForm : Form {

        public University MyUniversity { get; set; }

        public Schedule NewSchedule { get; set; }

        public JsonController TheJsonController { get; set; }

        public int learnCoursePerDay { get; set; }

        public int teachCoursePerDay { get; set; }

        public int hoursTaught { get; set; }

        public ScheduleForm() {
            InitializeComponent();
            TheJsonController = new JsonController();
        }

        #region Events

        private void ScheduleForm_Load(object sender, EventArgs e) {
            FillListViewHeader();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            AddSchedule();
        }

        #endregion

        #region Methods

        private void FillListViewHeader() {

            ctrlStudentViewList.Items.Clear();

            ctrlStudentViewList.View = View.Details;
            ctrlStudentViewList.Columns.Add("Name", 200);
            ctrlStudentViewList.Columns.Add("LastName", 200);
            ctrlStudentViewList.Columns.Add("Age", 200);
            ctrlStudentViewList.Columns.Add("RegistrationNumber", 200);
            ctrlStudentViewList.Columns.Add("ID", 200);

            ctrlProfessorViewList.Items.Clear();

            ctrlProfessorViewList.View = View.Details;
            ctrlProfessorViewList.Columns.Add("Name", 200);
            ctrlProfessorViewList.Columns.Add("LastName", 200);
            ctrlProfessorViewList.Columns.Add("Age", 200);
            ctrlProfessorViewList.Columns.Add("RegistrationNumber", 200);
            ctrlProfessorViewList.Columns.Add("ID", 200);

            ctrlCourseViewList.Items.Clear();

            ctrlCourseViewList.View = View.Details;
            ctrlCourseViewList.Columns.Add("Code", 200);
            ctrlCourseViewList.Columns.Add("Subject", 200);
            ctrlCourseViewList.Columns.Add("Course Category", 200);
            ctrlCourseViewList.Columns.Add("Hours", 200);
            ctrlCourseViewList.Columns.Add("ID", 200);

            LoadData();
        }

        private void LoadData() {

            foreach (var item in MyUniversity.Students) {
                string listStudents = String.Format("{0},{1},{2},{3},{4}", item.Name, item.LastName, item.Age, item.RegistrationNumber, item.ID);
                string[] listParse = listStudents.Split(',').ToArray();

                ListViewItem listViewItem = new ListViewItem(listParse);
                ctrlStudentViewList.Items.Add(listViewItem);
            }

            foreach (var item in MyUniversity.Professors) {
                string listProfessors = String.Format("{0},{1},{2},{3},{4}", item.Name, item.LastName, item.Age, item.Rank, item.ID);
                string[] listParse = listProfessors.Split(',').ToArray();

                ListViewItem listViewItem = new ListViewItem(listParse);
                ctrlProfessorViewList.Items.Add(listViewItem);
            }

            foreach (var item in MyUniversity.Courses) {
                string listStudents = String.Format("{0},{1},{2},{3},{4}", item.Code, item.Subject, item.CourseCategory, item.Hours, item.ID);
                string[] listParse = listStudents.Split(',').ToArray();

                ListViewItem listViewItem = new ListViewItem(listParse);
                ctrlCourseViewList.Items.Add(listViewItem);
            }

        }

        private void AddSchedule() {

            if (ctrlStudentViewList.SelectedItems.Count > 0 && ctrlProfessorViewList.SelectedItems.Count > 0 && ctrlCourseViewList.SelectedItems.Count > 0) {

                int tempStudent = ctrlStudentViewList.SelectedIndices[0];
                int tempProfessor = ctrlProfessorViewList.SelectedIndices[0];
                DateTime tempCallendar = Convert.ToDateTime(ctrlDate.Value.Date);

                ListViewItem listViewStudent = ctrlStudentViewList.SelectedItems[0];
                ListViewItem listViewProfessor = ctrlProfessorViewList.SelectedItems[0];
                ListViewItem listViewCourse = ctrlCourseViewList.SelectedItems[0];

                Guid studentId = Guid.Parse(listViewStudent.SubItems[4].Text);
                Guid professorId = Guid.Parse(listViewProfessor.SubItems[4].Text);
                string courseCategory = Convert.ToString(listViewCourse.SubItems[2].Text);
                
                foreach (var item in MyUniversity.Schedules) {
                    
                    // Exception for Add Student and Professor in the same Date
                    if (studentId == item.StudentID && professorId == item.ProfessorID && tempCallendar == item.Callendar.Date) {
                        MessageBox.Show("This course has already been scheduled for that day!");
                        return;
                    }
                }

                foreach (var item in MyUniversity.Schedules) {

                    //Exception for each Student have more than 3 courses per Day
                    if (studentId == item.StudentID && tempCallendar == item.Callendar.Date) {
                        learnCoursePerDay += 1;
                        if (learnCoursePerDay > 3) {
                            MessageBox.Show("This student cannot have for more than 3 courses on that date!");
                            return;
                        }
                    }
                }

                foreach (var item in MyUniversity.Schedules) {

                    //Exception for each Professor teach more than 4 courses per Day **if not
                    if (professorId == item.ProfessorID && tempCallendar == item.Callendar.Date) {
                        teachCoursePerDay += 1;
                        if (teachCoursePerDay > 4) {
                            MessageBox.Show("This professor cannot teach for more than 4 courses on that date!");
                            return;
                        }
                    }
                }

                foreach (var item in MyUniversity.Schedules) {

                    //Exception for each Professor teach more than 8 hours per Day **(or 40 courses per week)
                    if (professorId == item.ProfessorID && tempCallendar == item.Callendar.Date) {
                        int courseHours = Convert.ToInt32(listViewCourse.SubItems[3].Text);
                        hoursTaught += courseHours;
                        if (hoursTaught > 8) {
                            MessageBox.Show("This professor cannot teach for more than 8 hours on that date!");
                            return;
                        }
                    }
                }
                

                NewSchedule.Callendar = tempCallendar;
                NewSchedule.ProfessorID = MyUniversity.Professors[tempProfessor].ID;
                NewSchedule.StudentID = MyUniversity.Students[tempStudent].ID;
                NewSchedule.CourseCategory = courseCategory;

                MessageBox.Show("Scheudle Added Succesfully!");

                Close();

            }
            else {
                MessageBox.Show("Please select a record from every field");
            }
        }

        #endregion
    }
}
