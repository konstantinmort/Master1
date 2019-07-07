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
    public partial class ChangeCustomer : Form
    {
        static String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=DB1\\Furniture1.mdb";
        OleDbConnection con = new OleDbConnection(connect);

        public ChangeCustomer()
        {
            InitializeComponent();
            con.Open();
            try
            {
                comboBox1.Items.Clear();
                string query = "SELECT ID_customer FROM Customer";
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "UPDATE Customer SET [FIO]='" + textBox1.Text + "',[Address]='" + textBox2.Text + "',[Phone]='" + textBox3.Text + "',[ID_employees]='" + textBox4.Text + "' WHERE ID_customer=" + comboBox1.Text;

                    OleDbCommand command = new OleDbCommand(query, con);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Изменение успешно выполнено");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT ID_customer, [FIO], [Address]," +
                    " [Phone], [ID_employees] FROM Customer WHERE ID_customer =" + comboBox1.SelectedItem;
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader[1].ToString();
                    textBox2.Text = reader[2].ToString();
                    textBox3.Text = reader[3].ToString();
                    textBox4.Text = reader[4].ToString();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
