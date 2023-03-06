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
    /// Interaction logic for ChooseStudent.xaml
    /// </summary>
    
    public partial class ChooseStudent : Window
    {
        public ChooseStudent()
        {
            InitializeComponent();
            fill_combo();
        }

        void fill_combo(){
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=StudentRecords; Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = "SELECT * FROM Student";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read()) 
                {
                    string StudentID = dr.GetString(0);
                    comboBox.Items.Add(StudentID);
                }
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
            
            Student OpenStudent = new Student(StudentNumber);
            OpenStudent.Show();
            this.Close();
        }
        public string StudentNumber;
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StudentNumber = comboBox.Items[comboBox.SelectedIndex].ToString();
        }
    }
}
