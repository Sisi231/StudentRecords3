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
    /// Interaction logic for StudentFees.xaml
    /// </summary>
    public partial class StudentFees : Window
    {
        public string studentsID;
        
        public StudentFees(string student)
        {
            studentsID = student;
            InitializeComponent();
            Fill_data();
        }
        void Fill_data() 
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=StudentRecords; Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = $"SELECT * FROM StudentFees Where Student_ID = '{studentsID}'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                dr.Read();
                txtStudentID.Text = Convert.ToString(dr["Student_ID"]);
                txtAmount.Text = Convert.ToString(dr["Amount"]);
                txtPaid.Text = Convert.ToString(dr["FeesPaid"]);
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
            Menu OpenMenu1 = new Menu(studentsID);
            OpenMenu1.Show();
            this.Close();
        }
    }
}
