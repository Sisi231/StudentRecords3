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
                string query1 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=1";
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon);
                SqlDataReader dr = sqlCmd1.ExecuteReader();
                dr.Read();
                txt1.Text = Convert.ToString(dr["Grade"]);
                dr.Close();
                string query2 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=2";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                SqlDataReader dr1 = sqlCmd2.ExecuteReader();
                dr1.Read();
                txt2.Text = Convert.ToString(dr1["Grade"]);
                dr1.Close();
                string query3 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=3";
                SqlCommand sqlCmd3 = new SqlCommand(query3, sqlCon);
                SqlDataReader dr2 = sqlCmd3.ExecuteReader();
                dr2.Read();
                txt3.Text = Convert.ToString(dr2["Grade"]);
                dr2.Close();
                string query4 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=4";
                SqlCommand sqlCmd4 = new SqlCommand(query4, sqlCon);
                SqlDataReader dr3 = sqlCmd4.ExecuteReader();
                dr3.Read();
                txt4.Text = Convert.ToString(dr3["Grade"]);
                dr3.Close();
                string query5 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=5";
                SqlCommand sqlCmd5 = new SqlCommand(query5, sqlCon);
                SqlDataReader dr4 = sqlCmd5.ExecuteReader();
                dr4.Read();
                txt5.Text = Convert.ToString(dr4["Grade"]);
                dr4.Close();
                string query6 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=6";
                SqlCommand sqlCmd6 = new SqlCommand(query6, sqlCon);
                SqlDataReader dr5 = sqlCmd6.ExecuteReader();
                dr5.Read();
                txt6.Text = Convert.ToString(dr5["Grade"]);
                dr5.Close();
                string query7 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=7";
                SqlCommand sqlCmd7 = new SqlCommand(query7, sqlCon);
                SqlDataReader dr6 = sqlCmd7.ExecuteReader();
                dr6.Read();
                txt7.Text = Convert.ToString(dr6["Grade"]);
                dr6.Close();
                string query8 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=8";
                SqlCommand sqlCmd8 = new SqlCommand(query8, sqlCon);
                SqlDataReader dr7 = sqlCmd8.ExecuteReader();
                dr7.Read();
                txt8.Text = Convert.ToString(dr7["Grade"]);
                dr7.Close();
                string query9 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=9";
                SqlCommand sqlCmd9 = new SqlCommand(query9, sqlCon);
                SqlDataReader dr8 = sqlCmd9.ExecuteReader();
                dr8.Read();
                txt9.Text = Convert.ToString(dr8["Grade"]);
                dr8.Close();
                string query10 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=10";
                SqlCommand sqlCmd10 = new SqlCommand(query10, sqlCon);
                SqlDataReader dr9 = sqlCmd10.ExecuteReader();
                dr9.Read();
                txt10.Text = Convert.ToString(dr9["Grade"]);
                dr9.Close();
                //string[] myArr = { txt1.Text, txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text, txt7.Text, txt8.Text, txt9.Text, txt10.Text, txt11.Text, txt12.Text };
                //for(int i = 0, j = 1; j<=12; i++, j++)
                //{
                //    string query = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID={j}";
                //    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                //    SqlDataReader dr = sqlCmd.ExecuteReader();
                //    dr.Read();
                //    myArr[i] = Convert.ToString(dr["Grade"]);
                //}
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
/* string query1 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=1";
                    SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon);
                    SqlDataReader dr = sqlCmd1.ExecuteReader();
                    dr.Read();
                    txt1.Text = Convert.ToString(dr["Grade"]);
                    string query2 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=2";
                    SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                    SqlDataReader dr = sqlCmd2.ExecuteReader();
                    dr.Read();
                    txt2.Text = Convert.ToString(dr["Grade"]);
                    string query3 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=3";
                    SqlCommand sqlCmd3 = new SqlCommand(query3, sqlCon);
                    SqlDataReader dr = sqlCmd3.ExecuteReader();
                    dr.Read();
                    txt3.Text = Convert.ToString(dr["Grade"]);
                    string query4 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=4";
                    SqlCommand sqlCmd4 = new SqlCommand(query4, sqlCon);
                    SqlDataReader dr = sqlCmd4.ExecuteReader();
                    dr.Read();
                    txt4.Text = Convert.ToString(dr["Grade"]);
                    string query5 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=5";
                    SqlCommand sqlCmd5 = new SqlCommand(query5, sqlCon);
                    SqlDataReader dr = sqlCmd5.ExecuteReader();
                    dr.Read();
                    txt5.Text = Convert.ToString(dr["Grade"]);
                    string query6 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=6";
                    SqlCommand sqlCmd6 = new SqlCommand(query6, sqlCon);
                    SqlDataReader dr = sqlCmd6.ExecuteReader();
                    dr.Read();
                    txt6.Text = Convert.ToString(dr["Grade"]);
                    string query7 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=7";
                    SqlCommand sqlCmd7 = new SqlCommand(query7, sqlCon);
                    SqlDataReader dr = sqlCmd7.ExecuteReader();
                    dr.Read();
                    txt7.Text = Convert.ToString(dr["Grade"]);
                    string query8 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=8";
                    SqlCommand sqlCmd8 = new SqlCommand(query8, sqlCon);
                    SqlDataReader dr = sqlCmd8.ExecuteReader();
                    dr.Read();
                    txt8.Text = Convert.ToString(dr["Grade"]);
                    string query9 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=9";
                    SqlCommand sqlCmd9 = new SqlCommand(query9, sqlCon);
                    SqlDataReader dr = sqlCmd9.ExecuteReader();
                    dr.Read();
                    txt9.Text = Convert.ToString(dr["Grade"]);
                    string query10 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=10";
                    SqlCommand sqlCmd10 = new SqlCommand(query10, sqlCon);
                    SqlDataReader dr = sqlCmd10.ExecuteReader();
                    dr.Read();
                    txt10.Text = Convert.ToString(dr["Grade"]);
                    string query11 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=11";
                    SqlCommand sqlCmd11 = new SqlCommand(query11, sqlCon);
                    SqlDataReader dr = sqlCmd11.ExecuteReader();
                    dr.Read();
                    txt11.Text = Convert.ToString(dr["Grade"]);
                    string query12 = $"SELECT * FROM Grades Where Student_ID = '{studentsID}' and Subject_ID=12";
                    SqlCommand sqlCmd12 = new SqlCommand(query12, sqlCon);
                    SqlDataReader dr = sqlCmd12.ExecuteReader();
                    dr.Read();
                    txt12.Text = Convert.ToString(dr["Grade"]);
                    */
