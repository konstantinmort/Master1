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
    public partial class Dobav : Form
    {
        static String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=DB1\\Pharmacy.mdb";
        OleDbConnection con = new OleDbConnection(connect);
        OleDbCommand command;
        public Dobav()
        {
            con.Open();
            string query;
            OleDbCommand command;
            OleDbDataReader reader;

            InitializeComponent();
            query = "SELECT ID_products FROM Products";
            command = new OleDbCommand(query, con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }

            query = "SELECT Title FROM Suppliers";
            command = new OleDbCommand(query, con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0]);
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
                string query;
                OleDbCommand command;
                OleDbDataReader reader;
                int KolvoNaSklade = 0;
                string post = comboBox2.SelectedItem.ToString();
                string prep = comboBox1.SelectedItem.ToString();
                string sum = textBox3.Text.ToString();
                string prod = textBox2.Text.ToString();
                string date1 = dateTimePicker1.Text.ToString();

                query = "SELECT [Remainder] FROM [Products] WHERE [Drugs] = \"" + prod + "\"";
                command = new OleDbCommand(query, con);
                KolvoNaSklade = Convert.ToInt32(command.ExecuteScalar());
                if (KolvoNaSklade > 0)
                {

                    query = "INSERT INTO [Sales] (ID_products, [Amount], [Price], [Date]) VALUES ('" + comboBox1.SelectedItem + "','" + "1" + "','" + textBox3.Text + "','" + dateTimePicker1.Value +  "')";
                    command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();

                    KolvoNaSklade--;
                    query = "UPDATE [Products] SET [Remainder] ='" + KolvoNaSklade + "' WHERE [ID_products] = " + comboBox1.SelectedItem;
                    command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();

                    Pechat cS = new Pechat();
                cS.label6.Text = post;
                cS.label8.Text = prod;
                cS.label9.Text = prep;
                cS.label11.Text = date1;
                cS.label19.Text = sum.ToString() + " р";
                cS.ShowDialog();

                }
                else MessageBox.Show("Данный товар закончился!");
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        public void Dobav_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT [ID_products] ,[Drugs], [Price] FROM Products WHERE [ID_products] =" + comboBox1.SelectedItem;
                command = new OleDbCommand(query, con);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text = reader[1].ToString();
                    textBox3.Text = reader[2].ToString();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
