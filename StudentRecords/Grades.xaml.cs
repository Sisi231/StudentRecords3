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
    /// Interaction logic for Grades.xaml
    /// </summary>
    public partial class Grades : Window
    {
        public string studentsID;
        public Grades(string student)
        {
            studentsID = student;
            InitializeComponent();
            fill_data();
        }
        void fill_data() 
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LABSCIFIPC07\LOCALHOST; Initial Catalog=StudentRecords; Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string[] myArr = { txt1.Text, txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text, txt7.Text, txt8.Text, txt9.Text, txt10.Text, txt11.Text, txt12.Text };
                for(int i = 0, j = 1; j<=12; i++, j++)
                {
                    string query = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID={j}";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    SqlDataReader dr = sqlCmd.ExecuteReader();
                    dr.Read();
                    myArr[i] = Convert.ToString(dr["Grade"]);
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
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Menu OpenMenu1 = new Menu(studentsID);
            OpenMenu1.Show();
            this.Close();
        }
    }
}
