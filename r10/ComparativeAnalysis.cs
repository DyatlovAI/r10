using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace r10
{
    public partial class ComparativeAnalysis : Form
    {
        private Random random = new Random();
        public static int Comparison = 0;
        public static int NumberOfPermutations = 0;
        public static string elapsedTime = "";
        public static int timeSort = 0;
        public static List<SortingResultsInformation> sortingResults = new List<SortingResultsInformation>();
        private Context context = new Context();
        public ComparativeAnalysis()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Volume", "Объем выборки");
            dataGridView1.Columns.Add("Arbuz", "Метод выбора");
            dataGridView1.Columns.Add("KrutoyArbuz", "Метод Шелла");
            dataGridView1.Rows.Add("10");
            dataGridView1.Rows.Add("100");
            dataGridView1.Rows.Add("1000");
            dataGridView1.Rows.Add("10000");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].ReadOnly = true;
            }

        }
        private void FillArray(int[] vs)
        {
            for (int i = 0; i < vs.Length; i++)
            {
                vs[i] = random.Next(0, 100000);
            }
        }
        private void Sort(int n, int number)
        {
            this.context = new Context(new Arbuz());
            Context.array = new int[n];
            FillArray(Context.array);
            context.ExecuteAlgorithm(false);
            dataGridView1.Rows[number].Cells[1].Value += "Сравн: " + Convert.ToString(Comparison) + " ";
            dataGridView1.Rows[number].Cells[1].Value += "Перест: " + Convert.ToString(NumberOfPermutations) + " ";
            dataGridView1.Rows[number].Cells[1].Value += "Время: " + Convert.ToString(elapsedTime);
            sortingResults.Add(new SortingResultsInformation(Comparison, NumberOfPermutations, elapsedTime, new Arbuz(), timeSort, n));
            Comparison = 0;
            NumberOfPermutations = 0;
            timeSort = 0;
            elapsedTime = "";
            Context.array = null;

            this.context = new Context(new KrutoyArbuz());
            Context.array = new int[n];
            FillArray(Context.array);
            context.ExecuteAlgorithm(false);
            dataGridView1.Rows[number].Cells[2].Value += "Сравн: " + Convert.ToString(Comparison) + " ";
            dataGridView1.Rows[number].Cells[2].Value += "Перест: " + Convert.ToString(NumberOfPermutations) + " ";
            dataGridView1.Rows[number].Cells[2].Value += "Время: " + Convert.ToString(elapsedTime);
            sortingResults.Add(new SortingResultsInformation(Comparison, NumberOfPermutations, elapsedTime, new KrutoyArbuz(), timeSort, n));
            Comparison = 0;
            NumberOfPermutations = 0;
            timeSort = 0;
            elapsedTime = "";
            Context.array = null;
        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }

            Sort(10, 0);
            Sort(100, 1);
            Sort(1000, 2);
            Sort(10000, 3);

            sortingResults.Clear();
        }
    }
}
