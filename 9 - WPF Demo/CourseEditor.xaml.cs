using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common;
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
using System.Windows.Shapes;

namespace _8___WPF_Demo
{
    /// <summary>
    /// Interaction logic for CourseEditor.xaml
    /// </summary>
    public partial class CourseEditor : Window
    {
        private dat154Entities dx = new dat154Entities();

        private List<student> allStudents;
        private List<course> allCourses;
        private List<grade> allGrades;


        public CourseEditor()
        {
            InitializeComponent();
        }

        public CourseEditor(dat154Entities context, List<student> studList, List<course> courseList, List<grade> gradeList) : this()
        {
            dx = context;
            allStudents = studList;
            allCourses = courseList;
            allGrades = gradeList;
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            grade g = new grade();
            int studId = -1;
            string courseCode = cCode.Text;
            string gChar = grade.Text;

            try
            {
                studId = int.Parse(sid.Text);
            }
            catch { }

            if (studId != -1 && courseCode != null && gChar != null)
            {
                student s = allStudents.Where(student => student.id == studId).First();
                course c = allCourses.Where(course => course.coursecode == courseCode).First();

                grade newGrade = new grade();
                newGrade.student = s;
                newGrade.course = c;
                gChar = gChar.ToUpper();

                //Making sure that the grade is uppercase and Between "A" and "F".
                if (gChar.Length == 1 && gChar.CompareTo("A") >= 0 && gChar.CompareTo("F") <= 0)
                {
                    newGrade.grade1 = gChar;
                }

                dx.grade.Add(newGrade);
                s.grade.Add(newGrade);

                dx.SaveChanges();


            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            int studId = -1;
            string courseCode = cCode.Text;


            try
            {
                studId = int.Parse(sid.Text);
            }
            catch { }


            if (studId != -1 && courseCode != null)
            {
                course c = allCourses.Where(course => course.coursecode.Equals(courseCode)).First();
                grade delGrade = allGrades.Where(grade => grade.studentid == studId && grade.coursecode.Equals(courseCode)).First();

                dx.grade.Remove(delGrade);
                dx.SaveChanges();
                sid.Text = cCode.Text = grade.Text = "";
            }

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {



            int studId = -1;
            string courseCode = cCode.Text;
            string gChar = grade.Text;

            try
            {
                studId = int.Parse(sid.Text);
            }
            catch { }

            if (studId != -1 && courseCode != null && gChar != null)
            {
                student s = allStudents.Where(student => student.id == studId).First();
                course c = allCourses.Where(course => course.coursecode == courseCode).First();

                grade updateGrade = dx.grade.Where(g => g.studentid == s.id && g.coursecode == c.coursecode).First();
                updateGrade.student = s;
                updateGrade.course = c;
                gChar = gChar.ToUpper();

                //Making sure that the grade is uppercase and Between "A" and "F".
                if (gChar.Length == 1 && gChar.CompareTo("A") >= 0 && gChar.CompareTo("F") <= 0)
                {
                    updateGrade.grade1 = gChar;
                }

                dx.SaveChanges();




                /*
                int id = int.Parse(sid.Text);
                student s = dx.student.Where(st => st.id == id).FirstOrDefault();

                if (s != null) {

                    if (!sage.Text.Equals("")) s.studentage = int.Parse(sage.Text);
                    if (!sname.Text.Equals("")) s.studentname = sname.Text;

                    dx.SaveChanges();
                }

                sid.Text = sname.Text = sage.Text = "";
            */
            }

        }
    }
}
