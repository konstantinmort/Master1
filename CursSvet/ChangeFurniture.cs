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
    public partial class ChangeFurniture : Form
    {
        static String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=DB1\\Furniture1.mdb";
        OleDbConnection con = new OleDbConnection(connect);
        public ChangeFurniture()
        {
            InitializeComponent();
            con.Open();
            try
            {
                comboBox1.Items.Clear();
                string query = "SELECT ID_furniture FROM Furniture";
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

        private void Button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string query = "UPDATE Furniture SET [ID_stock]='" + textBox1.Text + "',[Title]='" + textBox2.Text + "',[Price]='" + textBox3.Text + "',[Amount]='" + textBox4.Text + "',[Opisanie]='" + textBox5.Text + "' WHERE ID_furniture=" + comboBox1.Text;

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

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT ID_furniture, [ID_stock], [Title]," +
                    " [Price], [Amount], Opisanie FROM Furniture WHERE ID_furniture =" + comboBox1.SelectedItem;
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader[1].ToString();
                    textBox2.Text = reader[2].ToString();
                    textBox3.Text = reader[3].ToString();
                    textBox4.Text = reader[4].ToString();
                    textBox5.Text = reader[5].ToString();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
