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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Opening OpenOpening = new Opening();
            OpenOpening.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=StudentRecords; Integrated Security=True");

            try
            {




                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = "SELECT COUNT(1) FROM SignUpTable Where Username=@Username and Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", PasswordBox.Password);

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    ChooseStudent OpenchooseStudent = new ChooseStudent();
                    OpenchooseStudent.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password are not correct!");
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
    }
}
