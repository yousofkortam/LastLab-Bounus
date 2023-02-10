using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastLab_Bounus_
{
    public partial class Form2 : Form
    {
        public static int Id = 1;
        public Form2()
        {
            InitializeComponent();
            List<string> list = new List<string>();
            list.Add("student"); list.Add("teacher");
            cb_role.DataSource = list;
            cb_role.DisplayMember = "name";
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text, email = txt_email.Text, password = txt_password.Text;
            if (name == "" || email == "" || password == "")
            {
                MessageBox.Show("Please enter all valid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSTA0SB\\SQLEXPRESS;Initial Catalog=my_db;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert into user_table (name, email, password, role) values (@name, @email, @password, @role)", con);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("role", cb_role.SelectedValue);

            con.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            if (affectedRows > 0)
            {
                Form1 login = new Form1();
                this.Hide();
                login.Show();
            }
            con.Close();
        }
    }
}
