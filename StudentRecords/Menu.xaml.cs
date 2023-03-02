using System;
using System.Collections.Generic;
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

namespace StudentRecords
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public string studentNumber1;
        public Menu(string student)
        {

            studentNumber1 = student;
            InitializeComponent();
        }

        private void Submit_Click1(object sender, RoutedEventArgs e)
        {
            ChooseSubject openSubjects = new ChooseSubject(studentNumber1);
            openSubjects.Show();
            this.Close();
        }

        private void Submit_Click2(object sender, RoutedEventArgs e)
        {

        }

        private void Submit_Click4(object sender, RoutedEventArgs e)
        {
            StudentFees OpenFees = new StudentFees(studentNumber1);
            OpenFees.Show();
            this.Close();
        }

        private void Submit_Click5(object sender, RoutedEventArgs e)
        {
            ChooseStudent newStudent = new ChooseStudent();
            newStudent.Show();
            this.Close();
        }

        private void Submit_Click3(object sender, RoutedEventArgs e)
        {
            var openreports = new ChooseReport(studentNumber1);
            openreports.Show();
            this.Close();
        }
    }
}
