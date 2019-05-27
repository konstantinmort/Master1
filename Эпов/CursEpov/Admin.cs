using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace CursSvet
{
    public partial class Admin : Form
    {
        static String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=DB1\\Pharmacy.mdb";
        OleDbConnection con = new OleDbConnection(connect);

        public Admin()
        {
            InitializeComponent();
            con.Open();
            LoadData();
            LoadData1();
            LoadData2();
            LoadData3();
            LoadData4();
        }

        private void LoadData()
        {

            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM JO ORDER BY ID_O";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }
        private void LoadData1()
        {

            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM Products ORDER BY ID_products";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[9]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
                data[data.Count - 1][8] = reader[8].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView2.Rows.Add(s);
        }

        private void LoadData2()
        {

            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM Suppliers ORDER BY ID_supplies ";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView3.Rows.Add(s);
        }

        private void LoadData3()
        {

            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM [Sales] ORDER BY ID_JO";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView4.Rows.Add(s);
        }
        private void LoadData4()
        {

            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM [Authorization]";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView5.Rows.Add(s);
        }

        private void Manager_Load(object sender, EventArgs e)
        {


        }

        private void DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "INSERT INTO JO (ID_O, Date_runtime, Amount, ID_products) VALUES ('" + textBox19.Text + "','" + textBox3.Text + "','" + textBox18.Text + "','" + textBox1.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Добавление успешно выполнено");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Manager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            con.Close();
        }

        private void FurnitureBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "INSERT INTO Suppliers (ID_supplies, Title, Contface, Phone, Address) VALUES ('" + textBox20.Text + "','" + textBox21.Text + "','" + textBox8.Text + "','" + textBox22.Text + "','" + textBox7.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Добавление успешно выполнено");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "INSERT INTO [Products] ([ID_products], [Drugs], [Amount], [Shelflife], [Dosage], [Category], [Price], [ID_suppliers], [Remainder]) VALUES ('" + textBox16.Text + "','" + textBox15.Text + "','" + textBox6.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox24.Text + "','" + textBox25.Text + "','" + textBox26.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Добавление успешно выполнено");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "INSERT INTO [Sales] (ID_JO, ID_products, Amount, Price, [Date]) VALUES ('" + textBox23.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox27.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Добавление успешно выполнено");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void ПечатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeJO cS = new ChangeJO();
            cS.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            //string query = "DELETE from JO where ID_O ="+textBox28;

            //OleDbCommand command = new OleDbCommand(query, con);

            //command.ExecuteNonQuery();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM JO ORDER BY ID_O";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
   
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM Products ORDER BY ID_products";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[9]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
                data[data.Count - 1][8] = reader[8].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView2.Rows.Add(s);
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM Suppliers ORDER BY ID_supplies ";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView3.Rows.Add(s);
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM [Sales] ORDER BY ID_JO";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView4.Rows.Add(s);
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "INSERT INTO [Authorization] ([ID_employees], [Login], [Password], [Preffix]) VALUES ('" + textBox17.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Добавление успешно выполнено");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            dataGridView5.Rows.Clear();
            OleDbConnection con = new OleDbConnection(connect);
            con.Open();
            string query = "SELECT * FROM [Authorization]";
            OleDbCommand command = new OleDbCommand(query, con);

            OleDbDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }
            reader.Close();
            con.Close();

            foreach (string[] s in data)
                dataGridView5.Rows.Add(s);
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "INSERT INTO Employees ([ID_employees], [Firstname], [Lastname], [Salary1]) VALUES ('" + textBox24.Text + "','" + textBox25.Text + "','" + textBox26.Text + "','" + textBox27.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Добавление успешно выполнено");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
        }

        private void Button19_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Employees S = new Employees();
            S.ShowDialog();
        }
    }
}
