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
    /// Interaction logic for ChooseSubject.xaml
    /// </summary>
    public partial class ChooseSubject : Window
    {
        public string studentId;
        public ChooseSubject(string student)
        {
            studentId = student;
            InitializeComponent();
            fill_combo();
        }
        void fill_combo() 
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LABSCIFIPC07\LOCALHOST; Initial Catalog=StudentRecords; Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = $"SELECT * FROM Subject";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    var SubjectName = dr.GetValue(1);
                    comboBox.Items.Add(SubjectName);
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
        public string ChoosenSubject;
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChoosenSubject = comboBox.Items[comboBox.SelectedIndex].ToString();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Subject OpenSubject = new Subject(studentId, ChoosenSubject);
            OpenSubject.Show();
            this.Close();
        }
    }
}
