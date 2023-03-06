using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
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
    /// Interaction logic for Subject.xaml
    /// </summary>
    public partial class Subject : Window
    {
        public string studentsID;
        public string subjectName;
        public Subject(string student, string subject)
        {
            subjectName = subject;
            studentsID = student;
            InitializeComponent();
            fill();
        }
        void fill() 
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=StudentRecords; Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = $"SELECT * FROM Subject Where SubjectName = '{subjectName}'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                dr.Read();
                txtSubjectName.Text = Convert.ToString(dr["SubjectName"]);
                txtDescription.Text = Convert.ToString(dr["SubjectDescription"]);
                txtTeacherID.Text = Convert.ToString(dr["Teacher_ID"]);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Menu OpenMenu5= new Menu(studentsID);
            OpenMenu5.Show();
            this.Close();
        }
    }
}
