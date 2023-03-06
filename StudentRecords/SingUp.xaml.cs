﻿
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    /// Interaction logic for SingUp.xaml
    /// </summary>
    public partial class SingUp : Window
    {
        public SingUp()
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
            if (PasswordBox.Password.Length < 10 || PasswordBox.Password.Length > 10)
            {
                MessageBox.Show("Your password should be at least 10 symbols long! Try again");
            }
            else if (txtFirstName.Text.Equals(""))
            {
                MessageBox.Show("You cannot leave this field empty!");
            }
            else if (txtLastName.Text.Equals(""))
            {
                MessageBox.Show("You cannot leave this field empty!");
            }
            else if (txtUsername.Text.Equals(""))
            {
                MessageBox.Show("You cannot leave this field empty!");
            }
            else if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("You cannot have an email without '@'!");
            }
            else if (!(PasswordBox.Password == RePasswordBox.Password))
            {
                MessageBox.Show("The passwords don't match!Try again.");
            }
            else
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=LABSCIFIPC07\LOCALHOST; Initial Catalog=StudentRecords; Integrated Security=True");

                try
                {


                    //opening the connection to the db 

                    sqlCon.Open();

                    //Build our actual query 

                    string query = "INSERT INTO SignUpTable([First Name],[Last Name],[Email],[Username],[password], [repeat password])values ('" + this.txtFirstName.Text + "','" + this.txtLastName.Text + "','" + this.txtEmail.Text + "','" + this.txtUsername.Text + "','" + this.PasswordBox.Password +"','" + this.RePasswordBox.Password + "') ";

                    //Establish a sql command

                    SqlCommand cmd = new SqlCommand(query, sqlCon);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully saved");

                    LogIn lg = new LogIn();
                    lg.Show();
                    this.Close();

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
}
