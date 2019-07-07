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
    public partial class Authorization : Form
    {
        // Подключение бд
        static String connect = "Provider=Microsoft.JET.OLEDB.4.0;data source=DB1\\Furniture1.mdb";
        OleDbConnection con = new OleDbConnection(connect);

        public Authorization()
        {

            InitializeComponent();

            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            // открываем соединение с БД
            con.Open();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Считываю введенный логин и пароль пользователем.
            string Login, Password;
            Login = textBox2.Text;
            Password = textBox1.Text;
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                //Запрос к БД с получением пароля, логина и тип доступа.
                string autori = "SELECT Login, Password, Preffix FROM [Authorization] ORDER BY ID_employees";
                OleDbCommand command = new OleDbCommand(autori, con);
                OleDbDataReader reader = command.ExecuteReader();

                //Проверяю есть ли такой пользователь.
                while (reader.Read())
                {

                    //Если есть, то заходит под менеджера.
                    if (Login == reader[0].ToString() && Password == reader[1].ToString() && reader[2].ToString() == "1")
                    {
                        Admin a = new Admin();
                        a.Show();
                        this.Hide();
                        con.Close();
                        break;

                    }
                    //Если тип доступа другой то под администратором.
                    else if (Login == reader[0].ToString() && Password == reader[1].ToString() && reader[2].ToString() == "2")
                    {
                        Employees b = new Employees();
                        b.Show();
                        this.Hide();
                        con.Close();
                        break;
                    }
                    else
                    {
                        //Если введен неверный логин или пароль выдасть ошибку
                        label4.Text = "Неправильный логин или пароль!";
                        label4.Visible = true;
                    }
                }
            }
            else
            {
                label4.Text = "Все поля должны быть заполнены!";
                label4.Visible = true;
            }
        }
        //При закрытии программы закрывает БД
        private void Authorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
            Application.Exit();
        }
        private void TextBox1_Click(object sender, EventArgs e)
        {
     
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
        }

        private void Authorization_FormClosing_1(object sender, FormClosingEventArgs e)
        {
         
        }

        private void Authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            con.Dispose();
        }

        //При нажатии на 1 из 2 текстбоксов пропадает ошибка о неверном логине или пароле.
        private void TextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            label4.Visible = false;
        }

        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label4.Visible = false;
        }
    }   
}
