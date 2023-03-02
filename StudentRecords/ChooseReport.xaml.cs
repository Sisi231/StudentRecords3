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
    /// Interaction logic for ChooseReport.xaml
    /// </summary>
    public partial class ChooseReport : Window
    {
        public string studentsID;
        public ChooseReport(string student)
        {
            studentsID = student;
            InitializeComponent();
            fill_combo();
        }

        void fill_combo()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=StudentRecords; Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = $"SELECT * FROM Report where Student_ID = '{studentsID}'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    var ReportID = dr.GetValue(0);
                    comboBox.Items.Add(ReportID);
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
        public string ReportNumber;
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReportNumber = comboBox.Items[comboBox.SelectedIndex].ToString();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Report OpenReport = new Report(ReportNumber, studentsID);
            OpenReport.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Menu OpenMenu4 = new Menu(studentsID);
            OpenMenu4.Show();
            this.Close();
        }
    }
}
