using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace r10
{
    public partial class Form1 : Form
    {
        public Context context;
        public int count = 0;
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|Allfiles(*.*) | *.* ";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|Allfiles(*.*) | *.* ";
            IOFile.form1 = this;
           KrutoyArbuz.form1 = this;
            Arbuz.form1 = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Context.array != null)
            {
                if (radioButton1.Checked == true)
                {
                    this.context = new Context(new Arbuz());
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    IOFile.SaveData();
                    button1.Enabled = false;
                }
                if (radioButton2.Checked == true)
                {
                    this.context = new Context(new KrutoyArbuz());
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    IOFile.SaveData();
                    button1.Enabled = false;
                }
                IOFile.content = "";
            }
            else
            {
                MessageBox.Show("Ошибка! Массив пуст, сортировка невозможна!");
            }
        
    }

         private void toolStripDropDownButton1_Click(object sender, EventArgs e)
         {
             
         }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Context.array == null)
            {
                Form2 setGenerator = new Form2();
                Form2.form1 = this;
                setGenerator.Show();

                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ошибка! Массив уже сгенерирован. Необходимо очистить старый набор и повторите попытку!");
            }
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        public void AddItemsListBox(int first = -1, int second = -1)
        {
            listBox1.Items.Add("");
            foreach (var item in Context.array)
            {
                if (item == first || item == second)
                {
                    listBox1.Items[count] += '[' + Convert.ToString(item) + ']' + " ";
                }
                else
                {
                    listBox1.Items[count] += Convert.ToString(item) + " ";
                }
            }
            count++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            listBox1.Items.Clear();
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            ComparativeAnalysis.NumberOfPermutations = 0;
            ComparativeAnalysis.Comparison = 0;
            Context.array = null;
            this.count = 0;

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOFile.LoadData();
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void выводСтатистикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComparativeAnalysis comparativeAnalysis = new ComparativeAnalysis();
            comparativeAnalysis.Show();
        }

        private void сгенерироватьНаборToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Context.array == null)
            {
                Form2 setGenerator = new Form2();
                Form2.form1 = this;
                setGenerator.Show();

                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ошибка! Массив уже сгенерирован. Необходимо очистить старый набор и повторите попытку!");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button2.Enabled = true;
            listBox1.Items.Clear();
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            ComparativeAnalysis.NumberOfPermutations = 0;
            ComparativeAnalysis.Comparison = 0;
            Context.array = null;
            this.count = 0;
        }
    }
}

