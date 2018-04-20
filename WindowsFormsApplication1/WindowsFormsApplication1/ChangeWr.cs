using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ChangeWr : Form
    {
        public ChangeWr()
        {
            InitializeComponent();
        }

        private void ChangeWr_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.List[Form1.a].comand;
            textBox2.Text = Form1.List[Form1.a].Base;
            textBox3.Text = Form1.List[Form1.a].group;
            textBox4.Text = Form1.List[Form1.a].ColorForm;
            textBox5.Text = Form1.List[Form1.a].Capitan;
            textBox6.Text = Form1.List[Form1.a].Coach;
            textBox7.Text = Form1.List[Form1.a].NumberPlayers.ToString();
            textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numpl;

            if (textBox1.Text.Length == 0)
            {
                label1.ForeColor = Color.Red;
                label2.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                MessageBoxButtons perfomanceEmptyError = MessageBoxButtons.OK;
                MessageBox.Show(this, "Пустое значение в поле!", "Ошибка", perfomanceEmptyError, MessageBoxIcon.Error);
                textBox1.Select();
            }

            else if (textBox2.Text.Length == 0)
            {
                label2.ForeColor = Color.Red;
                label1.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                MessageBoxButtons perfomanceEmptyError = MessageBoxButtons.OK;
                MessageBox.Show(this, "Пустое значение в поле!", "Ошибка", perfomanceEmptyError, MessageBoxIcon.Error);
                textBox2.Select();
            }
            else if (textBox3.Text.Length == 0)
            {
                label3.ForeColor = Color.Red;
                label2.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                MessageBoxButtons perfomanceEmptyError = MessageBoxButtons.OK;
                MessageBox.Show(this, "Пустое значение в поле!", "Ошибка", perfomanceEmptyError, MessageBoxIcon.Error);
                textBox3.Select();               
            }
            else if (!int.TryParse(textBox7.Text, out numpl))
            {
                label7.ForeColor = Color.Red;
                label2.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                MessageBoxButtons perfomanceEmptyError = MessageBoxButtons.OK;
                MessageBox.Show(this, "В поле должно быть число!", "Ошибка", perfomanceEmptyError, MessageBoxIcon.Error);
                textBox7.Select();     
            }
            else if (textBox4.Text.Length == 0)
            {
                label4.ForeColor = Color.Red;
                label2.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                MessageBoxButtons perfomanceEmptyError = MessageBoxButtons.OK;
                MessageBox.Show(this, "Пустое значение в поле!", "Ошибка", perfomanceEmptyError, MessageBoxIcon.Error);
                textBox4.Select();
            }
            else if (textBox5.Text.Length == 0)
            {
                label5.ForeColor = Color.Red;
                label2.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                MessageBoxButtons perfomanceEmptyError = MessageBoxButtons.OK;
                MessageBox.Show(this, "Пустое значение в поле!", "Ошибка", perfomanceEmptyError, MessageBoxIcon.Error);
                textBox5.Select();
            }
            else if (textBox6.Text.Length == 0)
            {
                label6.ForeColor = Color.Red;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                MessageBoxButtons perfomanceEmptyError = MessageBoxButtons.OK;
                MessageBox.Show(this, "Пустое значение в поле!", "Ошибка", perfomanceEmptyError, MessageBoxIcon.Error);
                textBox6.Select();
            }

            else
            {
                Form1.List[Form1.a] = new WorldCup2018(textBox1.Text, textBox2.Text, textBox3.Text, int.Parse(textBox7.Text), textBox4.Text, textBox5.Text, textBox6.Text);
                Form1.FlagCheck = true;
                Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox2.Select();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button1.Select();
            }

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox3.Select();
            }
            if (e.KeyCode == Keys.Up)
            {
                textBox1.Select();
            }
            if (e.KeyCode == Keys.Right)
            {
                textBox4.Select();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button1.Select();
            }

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox7.Select();
            }
            if (e.KeyCode == Keys.Up)
            {
                textBox2.Select();
            }
            if (e.KeyCode == Keys.Right)
            {
                textBox5.Select();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button1.Select();
            }

        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Down))
            {
                button1.Select();
            }
            if (e.KeyCode == Keys.Up)
            {
                textBox3.Select();
            }
            if (e.KeyCode == Keys.Right)
            {
                textBox6.Select();
            }

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox5.Select();
            }
            if (e.KeyCode == Keys.Up)
            {
                textBox1.Select();
            }
            if (e.KeyCode == Keys.Left)
            {
                textBox2.Select();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button1.Select();
            }

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textBox6.Select();
            }
            if (e.KeyCode == Keys.Up)
            {
                textBox4.Select();
            }
            if (e.KeyCode == Keys.Left)
            {
                textBox3.Select();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button1.Select();
            }

        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Down))
            {
                button1.Select();
            }
            if (e.KeyCode == Keys.Up)
            {
                textBox5.Select();
            }
            if (e.KeyCode == Keys.Left)
            {
                textBox7.Select();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
