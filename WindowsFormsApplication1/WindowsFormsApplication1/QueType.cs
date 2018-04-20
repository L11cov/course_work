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
    public partial class QueType : Form
    {
        public QueType()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory + "\\" + "Team";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            Form1.filename = openFileDialog1.FileName;
            Form1.List = MySerial<List<WorldCup2018>>.Deserialize(Form1.filename);
            Form1.FlagCheck = false;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.filename = "";
            Form1.FlagCheck = false;
            Close();
        }

        private void QueType_Load(object sender, EventArgs e)
        {
            if (Registration.CheckReg == true)
                button1.Enabled = false;
            if (Directory.GetFiles(Environment.CurrentDirectory + "\\" + "Team\\").Contains(Environment.CurrentDirectory + "\\" + "Team\\" + MyReg.ValueGet()))
                button4.Enabled = true;
            else
            {
                button4.Enabled = false;
            }
                       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.filename = Environment.CurrentDirectory + "\\" + "Team\\" + MyReg.ValueGet();
            Form1.List = MySerial<List<WorldCup2018>>.Deserialize(Form1.filename);
            Form1.FlagCheck = false;
            Close();
        }
    }
}
