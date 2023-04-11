using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _8___WPF_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private dat154Entities dx = new dat154Entities();

        private DbSet<course> course;
        private DbSet<student> student;
        private DbSet<grade> grade;

        private List<student> allStudents;
        private List<grade> allGrades;
        private List<course> allCourses;

        public MainWindow()
        {
            InitializeComponent();

            course = dx.Set<course>();
            student = dx.student;
            grade = dx.grade;

            
            List<course> courses = course.ToList();
            allCourses = courses;
            courseList.ItemsSource = courses;
            courseList.DisplayMemberPath = "coursename";

            student.Load();

            grade.Load();
            allGrades = grade.Local.ToList();
            gradeList.ItemsSource = allGrades.Select(g => g.grade1).Distinct().ToList();
            

            allStudents = student.Local.ToList();
                        
            studentList.DataContext = allStudents;


        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            studentList.DataContext = student.Local.Where(stud => stud.studentname.Contains(SearchField.Text));
            foreach (student s in allStudents)
            {
                s.tempGrade = "--";
                s.tempCourse = "--";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new Editor(dx).ShowDialog();
        }

        private void EditCourseButton_Click(object sender, RoutedEventArgs e)
        {
            new CourseEditor(dx, allStudents, allCourses, allGrades).ShowDialog();
        }

        private void StudentList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            student s = (student)studentList.SelectedItem;

            new Editor(dx).ShowDialog();
        }

        private void FailedButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedGrade = "F";
            List<student> filteredStudents = new List<student>();


            List<grade> filteredGradeList = allGrades.Where(grade => grade.grade1.CompareTo(selectedGrade) >= 0).ToList();

            foreach (grade g in filteredGradeList)
            {
                student s = g.student;
                course c = g.course;

                if (s != null)
                {
                    filteredStudents.Add(s);
                    s.tempGrade = g.grade1;
                    s.tempCourse = c.coursename;
                }
            }

            studentList.DataContext = filteredStudents;
        }

        private void courseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected course
            course selectedCourse = (course)courseList.SelectedItem;

            if (selectedCourse != null)
            {
                List<student> filteredStudents = allStudents.Where(stud => stud.grade.Any(grade => grade.coursecode == selectedCourse.coursecode)).ToList();

                foreach (student s in filteredStudents)
                {
                    grade studGrade = allGrades.Where(g => g.coursecode == selectedCourse.coursecode && g.studentid == s.id).First();

                    s.tempCourse = selectedCourse.coursename + "";
                    s.tempGrade = studGrade.grade1 + "";
                }
                studentList.DataContext = filteredStudents;
            }

        }

        private void gradeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected course
            course selectedCourse = (course)courseList.SelectedItem;
            string selectedGrade = (string)gradeList.SelectedItem;
            List<student> studentGradeList = allStudents;
            List<student> filteredStudents = new List<student>();
            Boolean isCourseSelected = false;

            if (selectedCourse != null)
            {
                studentGradeList = allStudents.Where(stud => stud.grade.Any(grade => grade.coursecode == selectedCourse.coursecode)).ToList();
                isCourseSelected = true;
            }

            if (selectedGrade != null)
            {
                List<grade> filteredGradeList = allGrades.Where(grade => grade.grade1.CompareTo(selectedGrade) <= 0).ToList();

                foreach (grade g in filteredGradeList)
                {
                    student s = g.student;
                    course c = g.course;

                    if (s != null)
                    {
                        filteredStudents.Add(s);
                        s.tempGrade = g.grade1;
                        s.tempCourse = c.coursename;
                    }

                }


                studentList.DataContext = filteredStudents;

            }

        }
    }
}
