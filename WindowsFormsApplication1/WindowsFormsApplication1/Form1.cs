using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        public static List<WorldCup2018> List = new List<WorldCup2018>(); 
        public static int a; // Индекс выбранного элемента в Таблице
        public static string filename; // Путь к текущему выбранному файлу
        public static bool FlagCheck; // Проверка, изменялся ли файл
        public static string NameForm; // Динамичное название формы

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("Manual"))
            {
                Directory.CreateDirectory("Manual");
                System.IO.StreamWriter textFile = new System.IO.StreamWriter("Manual\\Help.txt");
                textFile.WriteLine("Эта программа создана в учебных целях! Создатель, студент ПИ2-3, Левенцов Иван.");
                textFile.Close();
            }

            if (!Directory.Exists("Team"))
                Directory.CreateDirectory("Team");

            // Меню выбора, что загрузить первым, либо новый файл, либо существующий
            QueType queType = new QueType();
            queType.ShowDialog();
            worldCup2018BindingSource.DataSource = List;

            // Режим работы программы: Изменение, Чтение
            if (Registration.CheckReg == true)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                создатьToolStripMenuItem.Enabled = false;
                сохранитьToolStripMenuItem.Enabled = false;
                NameForm = "Чемпионат мира 2018 - Режим чтения -- ";
            }
            else
                NameForm = "Чемпионат мира 2018 - Режим записи -- ";

            // Изменение названия формы, в зависимости от открытого файла
            if (filename == "")
                this.Text = NameForm + "Новый файл";
            else
                this.Text = NameForm + filename.Substring(filename.LastIndexOf("\\") + 1);

            // Проверка наличия папок или их создание
            

            // Блокировка кнопок "Изменение", "Удаление", если в таблице нет записей
            if (List.Count() == 0)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void справкаToolStripButton_Click(object sender, EventArgs e)
        {
            Process.Start("NotePad.exe", "Manual\\Instr.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            worldCup2018BindingSource.ResetBindings(false);
            worldCup2018BindingSource.DataSource = List;
            if (List.Count() == 0)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
            if (filename != "")
                this.Text = NameForm + filename.Substring(filename.LastIndexOf("\\") + 1);
        }
            

        private void button2_Click(object sender, EventArgs e)
        {
            a = dataGridView1.CurrentRow.Index;
            ChangeWr changewr = new ChangeWr();
            changewr.ShowDialog();
            worldCup2018BindingSource.ResetBindings(false);
            if (filename != "")
                this.Text = NameForm + filename.Substring(filename.LastIndexOf("\\") + 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Вы уверены, что хотитие удалить эту запись?",
            "Warning",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2,
            MessageBoxOptions.DefaultDesktopOnly);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow.Index != null)
                {
                    a = dataGridView1.CurrentRow.Index;
                    List.RemoveAt(a);
                    Form1.FlagCheck = true;
                }
                else
                    return;        
            }
            if (List.Count() == 0)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
            worldCup2018BindingSource.ResetBindings(false);
            if (filename != "")
                this.Text = NameForm + filename.Substring(filename.LastIndexOf("\\") + 1);
        }

        private bool RowFind(int i)
        {
            if (textBox1.Text != "")
                if (dataGridView1["comandDataGridViewTextBoxColumn", i].Value!= null)
                    if (dataGridView1["comandDataGridViewTextBoxColumn", i].Value.ToString() != textBox1.Text)
                        return false;

            if (textBox2.Text != "")
                if (dataGridView1["baseDataGridViewTextBoxColumn", i].Value != null)
                    if (dataGridView1["baseDataGridViewTextBoxColumn", i].Value.ToString() != textBox2.Text)
                        return false;

            if (textBox3.Text != "")
                if (dataGridView1["groupDataGridViewTextBoxColumn", i].Value != null)
                    if (dataGridView1["groupDataGridViewTextBoxColumn", i].Value.ToString() != textBox3.Text)
                        return false;
            if (textBox4.Text != "")
                if (dataGridView1["numberPlayersDataGridViewTextBoxColumn", i].Value != null)
                    if (dataGridView1["numberPlayersDataGridViewTextBoxColumn", i].Value.ToString() != textBox4.Text)
                        return false;

            if (textBox5.Text != "")
                if (dataGridView1["colorFormDataGridViewTextBoxColumn", i].Value != null)
                    if (dataGridView1["colorFormDataGridViewTextBoxColumn", i].Value.ToString() != textBox5.Text)
                        return false;

            if (textBox6.Text != "")
                if (dataGridView1["capitanDataGridViewTextBoxColumn", i].Value != null)
                    if (dataGridView1["capitanDataGridViewTextBoxColumn", i].Value.ToString() != textBox6.Text)
                        return false;
            if (textBox7.Text != "")
                if (dataGridView1["coachDataGridViewTextBoxColumn", i].Value != null)
                    if (dataGridView1["coachDataGridViewTextBoxColumn", i].Value.ToString() != textBox7.Text)
                        return false;
            return true;
        }

        // Работа фильтров
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (RowFind(i))
                    dataGridView1.Rows[i].Visible = true;
                else
                    dataGridView1.Rows[i].Visible = false;
            }
        }

        // Нажатие клавииши Enter
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button4.PerformClick();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button4.PerformClick();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button4.PerformClick();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button4.PerformClick();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button4.PerformClick();
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button4.PerformClick();
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button4.PerformClick();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("NotePad.exe", "Manual\\Help.txt");
        }

        private void сохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveMetodFile();               
        }

        // Общий метод сохранения
        public void SaveMetodFile()
        {
            if (filename == "") // Если это Новый файл
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = Environment.CurrentDirectory + "\\" + "Team"; // Получаем путь директории, куда сохранять
                saveFileDialog1.Filter = "xml files (*.xml)|*.xml"; // Маска файла

                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    this.Text = NameForm + "Новый файл";
                    return;
                } 
                filename = saveFileDialog1.FileName; // Получаем путь текущего файла
                MySerial<List<WorldCup2018>>.Serialize(filename, List);
                this.Text = NameForm + filename.Substring(filename.LastIndexOf("\\") + 1) + " - Сохранено";
                //MessageBox.Show("Файл сохранен");
            }
            else
            {
                File.Delete(filename);
                MySerial<List<WorldCup2018>>.Serialize(filename, List);
                this.Text = NameForm + filename.Substring(filename.LastIndexOf("\\") + 1) + " - Сохранено";
                //MessageBox.Show("Файл сохранен");
            }
            FlagCheck = false;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlagCheck) // Если были изменения в файле
            {
                DialogResult result = MessageBox.Show(
                    "Вы хотите сохранить изменения в текущем файле?", 
                    "Подтвердить действие",
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveMetodFile();
                }
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory + "\\" + "Team";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            // получаем выбранный файл
            filename = openFileDialog1.FileName;
            List = MySerial<List<WorldCup2018>>.Deserialize(filename);
            FlagCheck = false;
            this.Text = NameForm + filename.Substring(filename.LastIndexOf("\\") + 1);
            worldCup2018BindingSource.DataSource = List;
            if (List.Count() == 0)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        // Кнопка "Показать все"
        private void button5_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.Rows.Count;

            for (int i = 0; i < count; i++)
                dataGridView1.Rows[i].Visible = true;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FlagCheck)
            {
                DialogResult result = MessageBox.Show("Вы хотите сохранить изменения?", 
                    "Подтвердить действие",
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                    SaveMetodFile();
            }
            Form1.filename = "";
            this.Text = NameForm + "Новый файл";
            List = new List<WorldCup2018>();
            worldCup2018BindingSource.DataSource = List;
            if (List.Count() == 0)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FlagCheck == true)
            {
                DialogResult result = MessageBox.Show(
                    "Вы хотите сохранить изменения?", 
                    "Подтвердить действие",
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                    SaveMetodFile();
            }
            if (filename == null)
                return;
            if (filename != "")
                MyReg.ValueSet(filename.Substring(filename.LastIndexOf("\\") + 1));
        }

        private void тестовыйСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Registration.CheckReg != true)
            {
                DialogResult result = MessageBox.Show(
                "Вы действительно хотите загрузить тестовый список?",
                "Подтвердить действие",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    List = new List<WorldCup2018>();
                    worldCup2018BindingSource.DataSource = List;
                    List.Clear();
                    List = new List<WorldCup2018>();
                    List.Add(new WorldCup2018("Испания", "Краснодар", "B", 22, "Белая", "Иньеста", "Дель Боске"));
                    List.Add(new WorldCup2018("Аргентина", "Броницы", "D", 24, "Голубая", "Месси", "Сампаоли"));
                    List.Add(new WorldCup2018("Германия", "Ваутинки", "F", 24, "Черная", "Нойер", "Лев"));
                    List.Add(new WorldCup2018("Польша", "Сочи", "H", 27, "Белая", "Левандовски", ""));
                    List.Add(new WorldCup2018("Россия", "Новогорск", "A", 22, "Красная", "Акинфеев", "Черчесов"));
                    List.Add(new WorldCup2018("Египет", "Грозный", "A", 19, "Красная", "Салах", "Купер"));
                    worldCup2018BindingSource.DataSource = List;
                    if (List.Count() == 0)
                    {
                        button2.Enabled = false;
                        button3.Enabled = false;
                    }
                    else
                    {
                        button2.Enabled = true;
                        button3.Enabled = true;
                    }
                    FlagCheck = true;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(
                "Тестовый список нельзя загрузить в режиме чтения!",
                "Предупреждение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop);
            }
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.S))
            {
                SaveMetodFile();  
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                button3.PerformClick();
            }
        }   
    }
}
