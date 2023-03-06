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
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class Student : Window
    {
        public string currentStudent;
        public Student(string student)
        {
            currentStudent = student;
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
                string query = $"SELECT * FROM Student Where Student_ID = '{currentStudent}'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                dr.Read();
                txtFirstName.Text = dr.GetString(1);
                txtLastName.Text = dr.GetString(2);
                txtGender.Text = dr.GetString(3);
                txtAddress.Text = dr.GetString(4);
                txtPhoneNumber.Text = dr.GetString(5);
                txtSection.Text = dr.GetString(6);
                txtYear.Text = dr.GetString(7);
                txtAddInfo.Text = dr.GetString(8);
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
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Menu OpenMenu2 = new Menu(currentStudent);
            OpenMenu2.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Menu OpenMenu = new Menu(currentStudent);
            OpenMenu.Show();
            this.Close();
        }
    }
}
