using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace r10
{
    public static class IOFile
    {
        public static string content = "";
        public static string path = "";
        public static Form1 form1 = new Form1();
        public static char[] listChar = new char[100];
        public static List<string> arrayList = new List<string>();
        public static void OpenSaveDialogForm()
        {
            if (form1.saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            path = form1.saveFileDialog1.FileName;
        }

        public static void OpenLoadDialogForm()
        {
            if (form1.openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            path = form1.openFileDialog1.FileName;
        }
        public static string InputInfoAboutComparison(int first, int second)
        {
            content += "Сравниваем " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
            return "Сравниваем " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
        }
        public static string InputInfoAboutTransposition(int first, int second)
        {
            content += "Перестановка " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
            return "Перестановка " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
        }
        public static void FillContent()
        {
            foreach (var i in Context.array)
            {
                content += Convert.ToString(i) + ' ';
            }
            content += '\n';
        }
        public static void ZeroingForSeparator()
        {

        }
        private static void Separator(StreamReader streamReader)
        {
            int i = 0;
            int a = 0;
            int a1 = 0;
            int l = 0;
            try
            {
                while (streamReader.Peek() != -1)
                {
                    if (streamReader.Peek() == 32)
                    {
                        char[] vs = new char[2 * i];
                        streamReader.Read(vs, i, 1);
                        i++;
                    }
                    else if (streamReader.Peek() >= 48 && streamReader.Peek() <= 57)
                    {
                        do
                        {
                            if (streamReader.Peek() == -1)
                            {
                                break;
                            }
                            streamReader.Read(listChar, i, 1);
                            int.TryParse(Convert.ToString(listChar[i]), out a);
                            a *= Convert.ToInt32(Math.Pow(10.0, l));
                            a1 += a;
                            i++;
                            l++;
                        }
                        while (streamReader.Peek() != 32);
                        string input = Convert.ToString(a1);
                        string output = new string(input.ToCharArray().Reverse().ToArray());
                        int.TryParse(output, out a1);
                        arrayList.Add(Convert.ToString(a1));
                        l = 0;
                        a = 0;
                        a1 = 0;
                    }
                    else
                    {
                        MessageBox.Show("Некорректный формат загружаемого файла.");
                        break;
                    }
                }
                Context.array = new int[arrayList.Count];
                for (int k = 0; k < arrayList.Count; k++)
                {
                    int.TryParse(arrayList[k], out Context.array[k]);
                }
                foreach (int j in Context.array)
                {
                    content += Convert.ToString(j) + " ";
                }
                form1.listBox1.Items.Add(content);
                form1.listBox1.Items.Add("");
            }
            catch
            {
                MessageBox.Show("Некорректный формат загружаемого файла.");
            }
        }
        public static void LoadData()
        {
            OpenLoadDialogForm();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                Separator(sr);
                sr.Close();
            }
        }
        public static void SaveData(string text = "", bool flag = false)
        {
            content += text;

            if (flag == false)
            {
                OpenSaveDialogForm();
            }

            try
            {
                System.IO.File.WriteAllText(path, IOFile.content);
            }
            catch (System.ArgumentException)
            {

            }
        }
    }
}
