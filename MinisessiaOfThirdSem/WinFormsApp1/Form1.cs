using LogicOfApplication;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // ���� \\
        protected PeopleHandler? ph;

        // ������������ \\
        public Form1()
        {
            InitializeComponent();
        }

        // ������ \\
        // ������ "��������� �� �����" \\
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                ph = new PeopleHandler();
                ph.LoadFromFile(path);
                PrintInToTextBox(ph.GetAllPeopleInString);
            }
        }
        // ����� ������ � RichTextBox ������ text \\
        public void PrintInToTextBox(string text)
        {
            richTextBox1.Text = text;
        }
        // ������ "����������� �� ����" \\
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Information:";
            if (ph != null)
            {
                ph.SortByCode();
                PrintInToTextBox(ph.GetAllPeopleInString);
            }
            else
            {
                label1.Text = "Information: ���� �� ��������";
            }
        }
        // ������ "������� �� ���������" \\
        private void button3_Click(object sender, EventArgs e)
        {
            string type = textBox1.Text;
            float dollarValue = float.Parse(textBox2.Text);

            label1.Text = "Information:";

            if (ph != null)
            {
                PrintInToTextBox(ph.GetPeopleByCategory(type, dollarValue));
            }
            else
            {
                label1.Text = "Information: ���� �� ��������";
            }
        }
    }
}