using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Registration : Form
    {
        public static bool CheckReg;
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            textBox1.Text = " Логин";
            textBox1.ForeColor = Color.Gray;
            textBox2.PasswordChar = '\0';
            textBox2.Text = " Пароль";
            textBox2.ForeColor = Color.Gray;

            if (!Directory.Exists("Manual"))
            {
                Directory.CreateDirectory("Manual");
                System.IO.StreamWriter textFile = new System.IO.StreamWriter("Manual\\Help.txt");
                textFile.WriteLine("Эта программа создана в учебных целях! Создатель, студент ПИ2-3, Левенцов Иван.");
                textFile.Close();
            }

            if (!Directory.Exists("Team"))
                Directory.CreateDirectory("Team");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == " Логин")
            {
                textBox1.Text = null;
                textBox1.ForeColor = Color.Black;
            }
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = " Логин";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == " Пароль")
            {
                textBox2.Text = null;
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = '*';
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                textBox2.PasswordChar = '\0';
                textBox2.Text = " Пароль";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Select();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                CheckReg = checkBox1.Checked;
                Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                Close();
                return;
            }
 
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                CheckReg = checkBox1.Checked;
                Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show(
                "Неправильно введен логин или пароль!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                label1.Location = new System.Drawing.Point(21, 80);
                label2.Location = new System.Drawing.Point(21, 114);
                label2.Text = "Нажмите войти, чтобы открыть \nпрограмму в режиме чтения";
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                label1.Location = new System.Drawing.Point(15, 30);
                label2.Location = new System.Drawing.Point(16, 64);
                label2.Text = "Введите ваши регистрационные \nданные для входа в личный кабинет";
                
            }
        }




    }
}
