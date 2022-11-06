using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            load();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-N2QSADA; Database= dms; Integrated Security= true;");
        SqlCommand cmd;
        SqlDataReader dr;
        bool Mode = true;
        string sql;



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            string address = addressTxt.Text;
            string number = contact.Text;
            string email = emailTxt.Text;
            string project = description.Text;

                if (Mode == true) {



                sql = "insert into Client_table(name,address,phone,email,description)values(@name,@address,@phone,@email,@description)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phone", number);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@description", project);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Details Added Succsessfully");

            }

            con.Close();


        }


        public void load() {

            sql = "select * from Client_table";
            cmd = new SqlCommand(sql, con);
            con.Open();

            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while(dr.Read())
            {

                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }

            con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
 