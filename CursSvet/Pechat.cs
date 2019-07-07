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

    public partial class Pechat : Form
    {
        static String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=DB1\\Furniture1.mdb";
        OleDbConnection con = new OleDbConnection(connect);
        OleDbCommand command;
        public Pechat()
        {
            con.Open();
            InitializeComponent();
            string query;
            OleDbCommand command;
            OleDbDataReader reader;


            comboBox4.Items.Clear();
            query = "SELECT ID_furniture FROM Furniture";
            command = new OleDbCommand(query, con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox4.Items.Add(reader[0]);
            }

            query = "SELECT Lastname FROM [Employees]";
            command = new OleDbCommand(query, con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }


            query = "SELECT [FIO] FROM [Customer]";
            command = new OleDbCommand(query, con);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox3.Items.Add(reader[0]);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query;
                OleDbCommand command;
                OleDbDataReader reader;
                int KolvoNaSklade = 0;
                string prep = textBox2.Text.ToString();
                string prep1 = comboBox3.SelectedItem.ToString();
                string cat = comboBox1.SelectedItem.ToString();
                string sum = textBox3.Text.ToString();
                query = "SELECT [Amount] FROM Furniture WHERE Title = \"" + prep + "\"";
                command = new OleDbCommand(query, con);
                KolvoNaSklade = Convert.ToInt32(command.ExecuteScalar());
                if (KolvoNaSklade > 0)
                {
                    KolvoNaSklade--;
                    query = "UPDATE Furniture SET [Amount] ='" + KolvoNaSklade + "' WHERE ID_furniture = " + comboBox4.SelectedItem;
                    command = new OleDbCommand(query, con);
                    command.ExecuteNonQuery();

                    dobav cS = new dobav();
                    cS.label5.Text = prep1;
                    cS.label6.Text = cat;
                    cS.label9.Text = prep;
                    cS.label11.Text = sum.ToString() + " р";
                    cS.ShowDialog();
                }
                else MessageBox.Show("Данный товар закончился!");
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

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT ID_furniture ,[Title], [Price] FROM Furniture WHERE [ID_furniture] =" + comboBox4.SelectedItem;
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
