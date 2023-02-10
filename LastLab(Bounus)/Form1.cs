using System.Data.SqlClient;
using System.Runtime.InteropServices.ObjectiveC;

namespace LastLab_Bounus_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Form2 register = new Form2();
            this.Hide();
            register.Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string email = txt_email.Text, password = txt_password.Text;
            if (email == "" || password == "")
            {
                MessageBox.Show("Please enter all valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSTA0SB\\SQLEXPRESS;Initial Catalog=my_db;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select id from user_table where email=@email and password=@pass", con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pass", password);
            con.Open();
            object obj = cmd.ExecuteScalar();
            if (obj != null)
            {
                MessageBox.Show("Email And Password is CORRECT!", "Inoframtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Email And Password is NOT CORRECT!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }
    }
}