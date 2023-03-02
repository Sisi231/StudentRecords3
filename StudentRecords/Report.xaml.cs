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
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public string currentReportNumber;
        public string studentsID;
        public Report(string report, string student)
        {
            currentReportNumber = report;
            studentsID = student;
            InitializeComponent();
            fill_Data();
        }
        void fill_Data()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=StudentRecords; Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = $"SELECT * FROM Report Where Report_ID = '{currentReportNumber}'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                dr.Read();
                txtReportID.Text = Convert.ToString(dr["Report_ID"]);
                txtStudentID.Text = Convert.ToString(dr["Student_ID"]);
                txtDate.Text = Convert.ToString(dr["DateOfCreation"]);
                txtContent.Text = Convert.ToString(dr["Content"]);
                txtSubjectID.Text = Convert.ToString(dr["Subject_ID"]);
                txtTeacherID.Text = Convert.ToString(dr["Teacher_ID"]);
                txtComments.Text = Convert.ToString(dr["Teacher_Comments"]);
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
            Menu OpenMenu3 = new Menu(studentsID);
            OpenMenu3.Show();
            this.Close();
        }
    }
}
