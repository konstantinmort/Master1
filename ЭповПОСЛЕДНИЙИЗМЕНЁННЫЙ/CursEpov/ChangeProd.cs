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
    public partial class ChangeProd : Form
    {
        static String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=DB1\\Pharmacy.mdb";
        OleDbConnection con = new OleDbConnection(connect);
        public ChangeProd()
        {
            InitializeComponent();
            con.Open();
            try
            {
                comboBox2.Items.Clear();
                string query = "SELECT ID_products FROM Products";
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0]);
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
            try
            {
                string enterprice, job, education, zp, education1, education2;
                enterprice = textBox1.Text;
                job = textBox2.Text;
                education = textBox3.Text;
                education1 = comboBox1.Text;
                education2 = textBox6.Text;
                zp = textBox4.Text;
                string query = "UPDATE Products SET [Drugs] ='" + enterprice + "'," +
                               "[Shelflife] ='" + job + "'," +
                               "[Dosage] ='" + education + "'," +
                               "[Category] ='" + education1 + "'," +
                               "[Price] ='" + education2 + "'," +
                               "[ID_suppliers] ='" + zp + "' WHERE ID_products = " + comboBox2.SelectedItem;
                OleDbCommand command = new OleDbCommand(query, con);
                command.ExecuteNonQuery();
                MessageBox.Show("Изменение успешно выполнено");
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT ID_products, [Drugs], [Shelflife]," +
                    " [Dosage], [Category], [Price], [ID_suppliers] FROM Products WHERE ID_products =" + comboBox2.SelectedItem;
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text  = reader[1].ToString();
                    textBox2.Text  = reader[2].ToString();
                    textBox3.Text  = reader[3].ToString();
                    comboBox1.Text = reader[4].ToString();
                    textBox6.Text  = reader[5].ToString();
                    textBox4.Text  = reader[6].ToString();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
